using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TLSharp.Rpc.Functions.Upload;
using TLSharp.Rpc.Types;

namespace TLSharp.Utils
{
    public static class UploadHelper
    {
        private static string GetFileHash(byte[] data)
        {
            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(data);
                var hashResult = new StringBuilder(hash.Length * 2);

                foreach (var t in hash)
                    hashResult.Append(t.ToString("x2"));

                return hashResult.ToString();
            }
        }

        public static async Task<InputFile> UploadFile(this TelegramClient client, string name, StreamReader reader)
        {
            const long tenMb = 10 * 1024 * 1024;
            return await UploadFile(name, reader, client, reader.BaseStream.Length >= tenMb);
        }

        private static byte[] GetFile(StreamReader reader)
        {
            var file = new byte[reader.BaseStream.Length];

            using (reader)
            {
                reader.BaseStream.Read(file, 0, (int)reader.BaseStream.Length);
            }

            return file;
        }

        private static Queue<byte[]> GetFileParts(byte[] file)
        {
            var fileParts = new Queue<byte[]>();

            const int maxFilePart = 512 * 1024;

            using (var stream = new MemoryStream(file))
            {
                while (stream.Position != stream.Length)
                {
                    if ((stream.Length - stream.Position) > maxFilePart)
                    {
                        var temp = new byte[maxFilePart];
                        stream.Read(temp, 0, maxFilePart);
                        fileParts.Enqueue(temp);
                    }
                    else
                    {
                        var length = stream.Length - stream.Position;
                        var temp = new byte[length];
                        stream.Read(temp, 0, (int)(length));
                        fileParts.Enqueue(temp);
                    }
                }
            }

            return fileParts;
        }

        private static async Task<InputFile> UploadFile(string name, StreamReader reader,
            TelegramClient client, bool isBigFileUpload)
        {
            var file = GetFile(reader);
            var fileParts = GetFileParts(file);

            var partNumber = 0;
            var partsCount = fileParts.Count;
            var fileId = BitConverter.ToInt64(Helpers.GenerateRandomBytes(8), 0);
            while (fileParts.Count != 0)
            {
                var part = fileParts.Dequeue();

                if (isBigFileUpload)
                {
                    await client.Call(new SaveBigFilePart(
                        fileId: fileId,
                        filePart: partNumber,
                        bytes: part.ToArr(),
                        fileTotalParts: partsCount
                    ));
                }
                else
                {
                    await client.Call(new SaveFilePart(
                        fileId: fileId,
                        filePart: partNumber,
                        bytes: part.ToArr()
                    ));
                }
                partNumber++;
            }

            return isBigFileUpload
                ? (InputFile) new InputFile.BigTag(
                    id: fileId,
                    name: name,
                    parts: partsCount
                )
                : (InputFile) new InputFile.Tag(
                    id: fileId,
                    name: name,
                    parts: partsCount,
                    md5Checksum: GetFileHash(file)
                );
        }
    }
}
