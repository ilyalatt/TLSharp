using System;
using System.IO;
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
        public void Dispose() => _tcpClient.Dispose();


        async Task SendImpl(byte[] packet)
        {
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

        public async Task Send(byte[] packet)
        {
            try
            {
                await SendImpl(packet);
            }
            catch (IOException exc)
            {
                throw new TlTransportException("TcpTransport.Send IO exception.", exc);
            }
        }


        async Task<byte[]> ReadBytes(Stream stream, int count)
        {
            var res = new byte[count];

            var totalReceived = 0;
            while (totalReceived < count)
            {
                var received = await stream.ReadAsync(res, totalReceived, count - totalReceived);
                if (received == 0) throw new TlClosedConnectionException();
                totalReceived += received;
            }

            return res;
        }

        async Task<byte[]> ReceiveImpl()
        {
            var stream = _tcpClient.GetStream();

            var packetLengthBytes = await ReadBytes(stream, 4);
            var packetLength = BitConverter.ToInt32(packetLengthBytes, 0);

            var seqBytes = await ReadBytes(stream, 4);
            var seqNo = BitConverter.ToInt32(seqBytes, 0);

            var bodyLen = packetLength - 12;
            var body = await ReadBytes(stream, bodyLen);

            var crcBytes = await ReadBytes(stream, 4);
            var checksum = BitConverter.ToInt32(crcBytes, 0);

            var crc32 = new CRC32();
            crc32.SlurpBlock(packetLengthBytes, 0, packetLengthBytes.Length);
            crc32.SlurpBlock(seqBytes, 0, seqBytes.Length);
            crc32.SlurpBlock(body, 0, body.Length);
            var validChecksum = crc32.Crc32Result;
            if (checksum != validChecksum) Helpers.Assert(checksum == validChecksum, "TcpTransport.Receive bad checksum");

            return body;
        }

        public async Task<byte[]> Receive()
        {
            try
            {
                return await ReceiveImpl();
            }
            catch (IOException exc)
            {
                throw new TlTransportException("TcpTransport.Receive IO exception.", exc);
            }
        }
    }
}
