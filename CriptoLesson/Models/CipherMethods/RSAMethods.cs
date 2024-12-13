using System;
using System.Security.Cryptography;
using System.Text;

namespace CriptoLesson.Models.CipherMethods;

public class RsaMethods
{
    public string PublicKey { get; set; }
    public string PrivateKey { get; set; }

    public RsaMethods()
    {
        // RSA parametrelerini yarat
        using (var rsa = new RSACryptoServiceProvider(2048))
        {
            PublicKey = rsa.ToXmlString(false); // Sadece public key
            PrivateKey = rsa.ToXmlString(true); // Public + private key
        }
    }

    public string RsaEncrypt(string inputText)
    {
        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(PublicKey);
            byte[] data = Encoding.UTF8.GetBytes(inputText);
            byte[] encryptedData = rsa.Encrypt(data, false); // Şifreleme işlemi
            return Convert.ToBase64String(encryptedData);
        }
    }

    public string RsaDecrypt(string encryptedText)
    {
        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(PrivateKey);
            byte[] encryptedData = Convert.FromBase64String(encryptedText);
            byte[] decryptedData = rsa.Decrypt(encryptedData, false); // Deşifreleme işlemi
            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}
