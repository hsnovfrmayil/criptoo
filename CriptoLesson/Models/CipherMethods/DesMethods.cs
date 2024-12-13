using System;
using System.Security.Cryptography;
using System.Text;

namespace CriptoLesson.Models.CipherMethods
{
    public class DesMethods
    {
        public string DesEncrypt(string input, string key)
        {
            using (var des = DES.Create())
            {
                des.Key = Encoding.UTF8.GetBytes(key.PadRight(8, ' ')); // DES üçün 8 baytlıq açar
                des.IV = new byte[8]; // DES üçün IV (initialization vector) sıfır
                ICryptoTransform encryptor = des.CreateEncryptor(des.Key, des.IV);

                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] encryptedBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

                return Convert.ToBase64String(encryptedBytes);
            }
        }

        public string DesDecrypt(string input, string key)
        {
            using (var des = DES.Create())
            {
                des.Key = Encoding.UTF8.GetBytes(key.PadRight(8, ' ')); // DES üçün 8 baytlıq açar
                des.IV = new byte[8]; // DES üçün IV (initialization vector) sıfır
                ICryptoTransform decryptor = des.CreateDecryptor(des.Key, des.IV);

                byte[] inputBytes = Convert.FromBase64String(input);
                byte[] decryptedBytes = decryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
    }
}
