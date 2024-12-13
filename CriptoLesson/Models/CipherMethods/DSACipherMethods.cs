using System.Text;

namespace CriptoLesson.Models.CipherMethods;

public class DSACipherMethods
{
    // Method to encrypt using Caesar cipher
    public string DsaEncrypt(string input, int shift)
    {
        StringBuilder encryptedText = new StringBuilder();

        foreach (char ch in input)
        {
            if (char.IsLetter(ch))
            {
                char offset = char.IsLower(ch) ? 'a' : 'A';
                char encryptedChar = (char)((((ch + shift) - offset) % 26) + offset);
                encryptedText.Append(encryptedChar);
            }
            else
            {
                encryptedText.Append(ch); // Keep non-letter characters unchanged
            }
        }

        return encryptedText.ToString();
    }

    // Method to decrypt using Caesar cipher
    public string DsaDecrypt(string input, int shift)
    {
        StringBuilder decryptedText = new StringBuilder();

        foreach (char ch in input)
        {
            if (char.IsLetter(ch))
            {
                char offset = char.IsLower(ch) ? 'a' : 'A';
                char decryptedChar = (char)((((ch - shift) - offset + 26) % 26) + offset);
                decryptedText.Append(decryptedChar);
            }
            else
            {
                decryptedText.Append(ch); // Keep non-letter characters unchanged
            }
        }

        return decryptedText.ToString();
    }
}
