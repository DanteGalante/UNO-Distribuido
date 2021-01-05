using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace UNO_Server.Utilities
{
    public class DataManager
    {
        public string GenerateVerificationToken()
        {
            string charSet = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            var chars = charSet.ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            data = new byte[10];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(10);
            foreach(byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            Console.WriteLine(result);
            return result.ToString();
        }

        public string EncryptPassword(string txtToEncrypt)
        {
            string txtEncrypted = BCrypt.Net.BCrypt.HashPassword(txtToEncrypt);

            return txtEncrypted;
        }

        public bool VerifyPassword(string passwordToVerify, string password)
        {
            bool result = false;

            result = BCrypt.Net.BCrypt.Verify(passwordToVerify, password);

            return result;
        }
        /*
        [Obsolete]
        public byte[] EncryptAes(string txtToEncrypt)
        {
            byte[] encryptedTxt = null;
            try
            {
                using(AesManaged aes = new AesManaged())
                {
                    encryptedTxt = Encrypt(txtToEncrypt, aes.Key, aes.IV);
                }
            }catch(Exception exception)
            {
                Console.WriteLine(exception);
            }

            return encryptedTxt;
        }
        [Obsolete]
        private byte[] Encrypt(string txtToEncrypt, byte[] key, byte[] IV)
        {
            byte[] txtEncrypted = null;

            using(AesManaged aes = new AesManaged())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(key, IV);

                using(MemoryStream ms = new MemoryStream())
                {
                    using(CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using(StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(txtToEncrypt);
                        }

                        txtEncrypted = ms.ToArray();
                    }
                }
            }

            return txtEncrypted;
        }
        [Obsolete]
        public string Decrypt(byte[] cipherTxt, byte[] key, byte[] IV)
        {
            string txtDecrypted = "";

            using(AesManaged aes = new AesManaged())
            {
                ICryptoTransform decryptor = aes.CreateDecryptor(key, IV);

                using(MemoryStream ms = new MemoryStream(cipherTxt))
                {
                    using(CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using(StreamReader reader = new StreamReader(cs))
                        {
                            txtDecrypted = reader.ReadToEnd();
                        }
                    }
                }
            }

            return txtDecrypted;
        }
        */
    }
}
