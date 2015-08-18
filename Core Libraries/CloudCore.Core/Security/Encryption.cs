using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using CloudCore.Configuration.ConfigFile;

namespace CloudCore.Core.Security
{
    public sealed class Encryption
    {

        private static readonly string PassPhrase = ReadConfig.CommonCloudCoreApplicationSettings.Keys.EncryptionKey;
        public static string Encrypt(string plainSourceStringToEncrypt)
        {
            return Encrypt(plainSourceStringToEncrypt, string.Empty);
        }

        public static string Encrypt(string plainSourceStringToEncrypt, string salt)
        {
            string newPassPhrase = PassPhrase;

            if (string.IsNullOrWhiteSpace(plainSourceStringToEncrypt))
            {
                return string.Empty;
            }

            if (!string.IsNullOrEmpty(salt))
            {
                newPassPhrase = Encrypt(newPassPhrase + salt, string.Empty);
            }

            using (AesCryptoServiceProvider acsp = GetProvider(Encoding.Default.GetBytes(newPassPhrase)))
            {
                byte[] sourceBytes = Encoding.ASCII.GetBytes(plainSourceStringToEncrypt);
                ICryptoTransform ictE = acsp.CreateEncryptor();
                var msS = new MemoryStream();
                var csS = new CryptoStream(msS, ictE, CryptoStreamMode.Write);
                csS.Write(sourceBytes, 0, sourceBytes.Length);
                csS.FlushFinalBlock();
                byte[] encryptedBytes = msS.ToArray();
                return Convert.ToBase64String(encryptedBytes);
            }
        }

        public static string Decrypt(string base64StringToDecrypt)
        {
            return Decrypt(base64StringToDecrypt, string.Empty);
        }

        public static string Decrypt(string base64StringToDecrypt, string salt)
        {
            //base64StringToDecrypt = HttpUtility.UrlDecode(base64StringToDecrypt);

            if (string.IsNullOrWhiteSpace(base64StringToDecrypt))
            {
                return string.Empty;
            }

            string newPassPhrase = PassPhrase;

            if (!string.IsNullOrEmpty(salt))
            {
                newPassPhrase = Encrypt(newPassPhrase + salt, string.Empty);
            }

            //Set up the encryption objects
            using (AesCryptoServiceProvider acsp = GetProvider(Encoding.Default.GetBytes(newPassPhrase)))
            {
                byte[] RawBytes = Convert.FromBase64String(base64StringToDecrypt);
                ICryptoTransform ictD = acsp.CreateDecryptor();

                //RawBytes now contains original byte array, still in Encrypted state

                //Decrypt into stream
                MemoryStream msD = new MemoryStream(RawBytes, 0, RawBytes.Length);
                CryptoStream csD = new CryptoStream(msD, ictD, CryptoStreamMode.Read);
                //csD now contains original byte array, fully decrypted

                //return the content of msD as a regular string

                return (new StreamReader(csD)).ReadToEnd();
            }
        }

        private static AesCryptoServiceProvider GetProvider(byte[] key)
        {
            AesCryptoServiceProvider result = new AesCryptoServiceProvider();
            result.BlockSize = 128;
            result.KeySize = 128;
            result.Mode = CipherMode.CBC;
            result.Padding = PaddingMode.PKCS7;

            result.GenerateIV();
            result.IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            byte[] RealKey = GetKey(key, result);
            result.Key = RealKey;
            // result.IV = RealKey;
            return result;
        }

        private static byte[] GetKey(byte[] suggestedKey, SymmetricAlgorithm p)
        {
            byte[] kRaw = suggestedKey;
            List<byte> kList = new List<byte>();

            for (int i = 0; i < p.LegalKeySizes[0].MinSize; i += 8)
            {
                kList.Add(kRaw[(i / 8) % kRaw.Length]);
            }
            byte[] k = kList.ToArray();
            return k;
        }


    }
}
