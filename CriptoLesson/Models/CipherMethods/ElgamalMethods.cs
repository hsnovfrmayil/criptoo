using System;
using System.Numerics;
using System.Text;

namespace CriptoLesson.Models.CipherMethods;


public class ElgamalMethods
{
    public string ElgamalEncrypt(string inputText, string key)
    {
        if (string.IsNullOrEmpty(inputText) || string.IsNullOrEmpty(key))
        {
            throw new ArgumentNullException("Input text or key cannot be null or empty.");
        }

        byte[] inputBytes = Encoding.UTF8.GetBytes(inputText);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key.PadRight(16, ' ')); // 16 bayt uzunluğunda açar təmin et

        byte[] encryptedBytes = SimpleElgamalEncrypt(inputBytes, keyBytes);
        return Convert.ToBase64String(encryptedBytes);
    }

    public string ElgamalDecrypt(string inputText, string key)
    {
        byte[] inputBytes = Convert.FromBase64String(inputText);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key.PadRight(16, ' ')); // 16 bayt uzunluğunda açar təmin et

        byte[] decryptedBytes = SimpleElgamalDecrypt(inputBytes, keyBytes);
        return Encoding.UTF8.GetString(decryptedBytes);
    }

    private byte[] SimpleElgamalEncrypt(byte[] input, byte[] key)
    {
        // Elgamal şifrələməsi üçün sadə bir yanaşma
        // Real Elgamal şifrələməsi üçün daha mürəkkəb riyazi əməliyyatlar tələb olunur
        for (int i = 0; i < input.Length; i++)
        {
            input[i] ^= key[i % key.Length];
        }
        return input;
    }

    private byte[] SimpleElgamalDecrypt(byte[] input, byte[] key)
    {
        // Deşifrələmə də şifrələmə ilə eynidir
        return SimpleElgamalEncrypt(input, key);
    }
}
