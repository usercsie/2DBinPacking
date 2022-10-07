using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2DBinPackingTest.PackingImplementation
{
    [TestClass]
    public class AESTest
    {
        private string Encrypt(string toEncrypt, string key)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        private string Decrypt(string toDecrypt, string key)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = null;
            byte[] resultArray = null;
            try
            {
                toEncryptArray = Convert.FromBase64String(toDecrypt);
            }
            catch { };
            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateDecryptor();

            try
            {
                resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            }
            catch
            {
                resultArray = new byte[] { 0x00 };
            }

            return UTF8Encoding.UTF8.GetString(resultArray);
        }


        public static string Encrypt(string toEncrypt)
        {
            string key = "@abcdefg.com";
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.CBC;
            rDel.Padding = PaddingMode.PKCS7;
            rDel.IV = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return BitConverter.ToString(resultArray);//.Replace("-", string.Empty);
        }

        private static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public static string Decrypt(string toDecrypt)
        {
            string key = "@abcdefg.com";
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toDecryptArray = StringToByteArray(toDecrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.CBC;
            rDel.Padding = PaddingMode.PKCS7;
            rDel.IV = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
            //return Convert.to(resultArray, 0, resultArray.Length);
        }

        [TestMethod]
        public void Encrypt()
        {
            string cKey = "1234567890123456";
            string msg = "abcdefghijklmnopqrstuvwxyz";

            string encrypted = Encrypt(msg, cKey);
            
            string decrypted = Decrypt(encrypted, cKey);

            Assert.AreEqual(msg, decrypted);
        }

        [TestMethod]
        public void Encrypt_CBC()
        {
            string msg = "abcdefghijk";

            string encrypted = Encrypt(msg);

            string decrypted = Decrypt(encrypted);

            Assert.AreEqual(msg, decrypted);
        }
    }
}
