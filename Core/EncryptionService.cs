using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Core
{
    public class EncryptionService
    {
        private readonly string key;
        private readonly string iv;

        public EncryptionService(string key, string iv)
        {
            this.key = key;
            this.iv = iv;
        }

        public byte[] Encrypt(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                        return ms.ToArray();
                    }
                }
            }
        }

        public string Decrypt(byte[] cipherText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                using (MemoryStream ms = new MemoryStream(cipherText))
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }

        public string ComputeSha512(string input)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = sha512.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public string ComputeHMAC(string message, string key)
        {
            using (HMACSHA512 hmac = new HMACSHA512(Encoding.UTF8.GetBytes(key)))
            {
                byte[] hashMessage = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
                return Convert.ToBase64String(hashMessage);
            }
        }
    }
}