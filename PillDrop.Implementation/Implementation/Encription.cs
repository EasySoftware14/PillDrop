using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PillDrop.Implementation.Implementation
{
    public class Encription
    {
        public static string DesEncrypt(string originalString)
        {
            byte[] key1 = ASCIIEncoding.ASCII.GetBytes("TheHouse");
            byte[] key2 = ASCIIEncoding.ASCII.GetBytes("TheHouse");
            if (String.IsNullOrEmpty(originalString))
                return string.Empty;

            DESCryptoServiceProvider cryptoProvider;
            MemoryStream memoryStream = null;
            CryptoStream cryptoStream = null;
            StreamWriter writer = null;
            try
            {
                cryptoProvider = new DESCryptoServiceProvider();
                memoryStream = new MemoryStream();
                cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(key1, key2), CryptoStreamMode.Write);
                writer = new StreamWriter(cryptoStream);
                writer.Write(originalString);
                writer.Flush();
                cryptoStream.FlushFinalBlock();
                writer.Flush();
                return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                    writer.Dispose();
                }
                if (cryptoStream != null)
                {
                    cryptoStream.Close();
                    cryptoStream.Dispose();
                }
                if (memoryStream != null)
                {
                    memoryStream.Close();
                    memoryStream.Dispose();
                }
            }
        }

        public static string DesDecrypt(string cryptedString)
        {
            byte[] key1 = ASCIIEncoding.ASCII.GetBytes("TheHouse");
            byte[] key2 = ASCIIEncoding.ASCII.GetBytes("TheHouse");
            if (String.IsNullOrEmpty(cryptedString))
                return string.Empty;

            DESCryptoServiceProvider cryptoProvider;
            MemoryStream memoryStream = null;
            CryptoStream cryptoStream = null;
            StreamReader reader = null;
            try
            {
                cryptoProvider = new DESCryptoServiceProvider();
                memoryStream = new MemoryStream(Convert.FromBase64String(cryptedString));
                cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(key1, key2), CryptoStreamMode.Read);
                reader = new StreamReader(cryptoStream);
                return reader.ReadToEnd();
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
                if (cryptoStream != null)
                {
                    cryptoStream.Close();
                    cryptoStream.Dispose();
                }
                if (memoryStream != null)
                {
                    memoryStream.Close();
                    memoryStream.Dispose();
                }
            }
        }

        private Encription()
        {
        }


        public static string GenerateEncryption(string email, DateTime linkdate)
        {
            string holder = email + "$" + Convert.ToString(linkdate);
            return DesEncrypt(holder);
        }

        public static string GenerateEncryption(string token, string hash)
        {
            string holder = string.Format("{0}${1}", token, hash);
            return DesEncrypt(holder);
        }

        public static string GenerateEncryptionForEmail(string email)
        {
            return DesEncrypt(email);
        }

        public static string GenerateDecryption(string userkey)
        {
            return DesDecrypt(userkey);
        }
    }
}