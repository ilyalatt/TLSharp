using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using Ionic.Crc;
using TLSharp.Utils;

namespace TLSharp.Rpc
{
    class TcpTransport : IDisposable
    {
        readonly TcpClient _tcpClient;
        int _sendCounter;

        public TcpTransport(TcpClient tcpClient) => _tcpClient = tcpClient;

        public async Task Send(byte[] packet)
        {
            if (!_tcpClient.Connected)
                throw new InvalidOperationException("Client not connected to server.");

            // https://core.telegram.org/mtproto#tcp-transport
            /*
                4 length bytes are added at the front
                (to include the length, the sequence number, and CRC32; always divisible by 4)
                and 4 bytes with the packet sequence number within this TCP connection
                (the first packet sent is numbered 0, the next one 1, etc.),
                and 4 CRC32 bytes at the end (length, sequence number, and payload together).
            */

            var bts = BtHelpers.UsingMemBinWriter(bw =>
            {
                var seqNum = _sendCounter++;

                var lenBts = BitConverter.GetBytes(packet.Length + 12);
                var seqNumBts = BitConverter.GetBytes(seqNum);

                bw.Write(lenBts);
                bw.Write(seqNumBts);
                bw.Write(packet);

                var crc32 = new CRC32();
                crc32.SlurpBlock(lenBts, 0, lenBts.Length);
                crc32.SlurpBlock(seqNumBts, 0, seqNumBts.Length);
                crc32.SlurpBlock(packet, 0, packet.Length);
                bw.Write(crc32.Crc32Result);
            });

            await _tcpClient.GetStream().WriteAsync(bts, 0, bts.Length);
        }

        public async Task<(int, byte[])> Receive()
        {
            var stream = _tcpClient.GetStream();

            var packetLengthBytes = new byte[4];
            if (await stream.ReadAsync(packetLengthBytes, 0, 4) != 4)
                throw new InvalidOperationException("Couldn't read the packet length");
            var packetLength = BitConverter.ToInt32(packetLengthBytes, 0);

            var seqBytes = new byte[4];
            if (await stream.ReadAsync(seqBytes, 0, 4) != 4)
                throw new InvalidOperationException("Couldn't read the sequence");
            var seq = BitConverter.ToInt32(seqBytes, 0);

            var readBytes = 0;
            var bodyLen = packetLength - 12;
            var body = new byte[bodyLen];

            while (readBytes != bodyLen)
            {
                readBytes += await stream.ReadAsync(body, readBytes, bodyLen - readBytes);
            }

            var crcBytes = new byte[4];
            if (await stream.ReadAsync(crcBytes, 0, 4) != 4)
                throw new InvalidOperationException("Couldn't read the crc");
            var checksum = BitConverter.ToInt32(crcBytes, 0);

            var crc32 = new CRC32();
            crc32.SlurpBlock(packetLengthBytes, 0, packetLengthBytes.Length);
            crc32.SlurpBlock(seqBytes, 0, seqBytes.Length);
            crc32.SlurpBlock(body, 0, body.Length);
            var validChecksum = crc32.Crc32Result;

            if (checksum != validChecksum)
            {
                throw new InvalidOperationException("invalid checksum! skip");
            }

            return (seq, body);
        }

        public bool IsConnected => _tcpClient.Connected;
        public void Dispose() => _tcpClient.Dispose();
    }
}
