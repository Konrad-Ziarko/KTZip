using System.Security.Cryptography;

namespace KTZipPresentation
{
    public static class Crypto
    {
        public static uint computeCRC32Checksum(byte[] bytes)
        {
            //Crc32 crc32 = new Crc32();
            //return Utility.ComputeCRC(bytes);
            return 0;
        }
        public static byte[] computeSHA256(byte[] bytes)
        {
            HashAlgorithm sha = new SHA256CryptoServiceProvider();
            return sha.ComputeHash(bytes);
        }

        public static byte[] computeMD5(byte[] bytes)
        {
            HashAlgorithm md5 = new MD5CryptoServiceProvider();
            return md5.ComputeHash(bytes);
        }
    }
}
