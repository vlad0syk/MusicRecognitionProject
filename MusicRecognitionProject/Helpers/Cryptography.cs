using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MusicRecognitionProject.Helpers
{
    public static class Cryptography
    {
        public static string Encrypt(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null!;
            }
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(str)));
        }
        public static byte[] Encrypt(byte[] key)
        {
            using (SymmetricAlgorithm symmetricAlgorithm = Aes.Create())
            {
                using (ICryptoTransform cryptoTransform = symmetricAlgorithm.CreateEncryptor(new PasswordDeriveBytes(CryptographyBase.Key, null).GetBytes(16), new byte[16]))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(key, 0, key.Length);
                        cryptoStream.FlushFinalBlock();
                        return memoryStream.ToArray();
                    }
                }
            }
        }
        public static string Decrypt(string str)
        {
            using (SymmetricAlgorithm symmetricAlgorithm = Aes.Create())
            {
                ICryptoTransform cryptoTransform = symmetricAlgorithm.CreateDecryptor((new PasswordDeriveBytes(CryptographyBase.Key, null)).GetBytes(16), new byte[16]);
                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(str)))
                using (CryptoStream cs = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Read))
                using (StreamReader sr = new StreamReader(cs))
                    return sr.ReadToEnd();
            }
        }
    }
}
