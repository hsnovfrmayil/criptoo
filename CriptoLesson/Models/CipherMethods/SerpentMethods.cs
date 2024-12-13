using System;
using System.Text;

namespace CriptoLesson.Models.CipherMethods;

public class SerpentMethods
{
    // A placeholder for Serpent encryption (use your actual encryption logic here)
    public string SerpentEncrypt(string input)
    {
        StringBuilder encryptedText = new StringBuilder();

        foreach (var character in input)
        {
            encryptedText.Append((char)(character + 3)); // Simple Caesar shift for illustration
        }

        return encryptedText.ToString();
    }

    // A placeholder for Serpent decryption (use your actual decryption logic here)
    public string SerpentDecrypt(string input)
    {
        StringBuilder decryptedText = new StringBuilder();

        foreach (var character in input)
        {
            decryptedText.Append((char)(character - 3)); // Simple Caesar shift for illustration
        }

        return decryptedText.ToString();
    }
}
