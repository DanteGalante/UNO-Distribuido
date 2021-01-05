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
    }
}
