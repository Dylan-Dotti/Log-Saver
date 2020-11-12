using System;
using System.IO;
using System.IO.Compression;

namespace FileUtilities
{
    public static class ByteCompression
    {
        public static byte[] GZipCompress(byte[] inputBytes,
            CompressionLevel compLevel = CompressionLevel.Fastest)
        {
            using (var result = new MemoryStream())
            {
                var lengthBytes = BitConverter.GetBytes(inputBytes.Length);
                result.Write(lengthBytes, 0, 4);

                using (var compressionStream = new GZipStream(result, compLevel))
                {
                    compressionStream.Write(inputBytes, 0, inputBytes.Length);
                    compressionStream.Flush();

                }
                return result.ToArray();
            }
        }

        public static byte[] GZipDecompress(byte[] inputBytes)
        {
            using (var source = new MemoryStream(inputBytes))
            {
                byte[] lengthBytes = new byte[4];
                source.Read(lengthBytes, 0, 4);

                var length = BitConverter.ToInt32(lengthBytes, 0);
                using (var decompressionStream = new GZipStream(source,
                    CompressionMode.Decompress))
                {
                    var result = new byte[length];
                    decompressionStream.Read(result, 0, length);
                    return result;
                }
            }
        }
    }
}
