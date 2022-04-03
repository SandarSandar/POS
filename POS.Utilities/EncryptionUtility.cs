using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace POS.Utilities
{
    public static class EncryptionUtility
    {
        public static string EncryptPlainTextToCipherText(string plainText, string encryptKey)
        {
            Byte[] results;
            UTF8Encoding utf8 = new UTF8Encoding();

            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] TEDSKey = mD5CryptoServiceProvider.ComputeHash(utf8.GetBytes(encryptKey));
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TEDSKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] DataToBeEncrypt = utf8.GetBytes(plainText);

            try
            {
                ICryptoTransform encryptor = TDESAlgorithm.CreateEncryptor();
                results = encryptor.TransformFinalBlock(DataToBeEncrypt, 0, DataToBeEncrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                mD5CryptoServiceProvider.Clear();
            }
            return Convert.ToBase64String(results);
        }

        public static string DecryptCipherTextToPlainText(string plainText, string encryptKey)
        {
            Byte[] results;
            UTF8Encoding utf8 = new UTF8Encoding();

            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] TEDSKey = mD5CryptoServiceProvider.ComputeHash(utf8.GetBytes(encryptKey));
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TEDSKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] DataToBeDecrypt = Convert.FromBase64String(plainText);

            try
            {
                ICryptoTransform decryptor = TDESAlgorithm.CreateEncryptor();
                results = decryptor.TransformFinalBlock(DataToBeDecrypt, 0, DataToBeDecrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                mD5CryptoServiceProvider.Clear();
            }
            return Convert.ToBase64String(results);
        }

    }
}
