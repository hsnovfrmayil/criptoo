using System;
using System.Text;

namespace CriptoLesson.Models.CipherMethods;

public class VigenereMethods
{
    private string GenerateKey(string text, string key)
    {
        int keyIndex = 0;
        char[] keyChars = new char[text.Length];
        for (int i = 0; i < text.Length; i++)
        {
            keyChars[i] = key[keyIndex];
            keyIndex = (keyIndex + 1) % key.Length;
        }
        return new string(keyChars);
    }

    public string VigenereEncrypt(string text)
    {
        string key = "KEY";  // Use any key here, or get it dynamically from the UI
        text = text.ToUpper();
        key = GenerateKey(text, key);

        StringBuilder encryptedText = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            char letter = text[i];
            if (char.IsLetter(letter))
            {
                char keyChar = key[i];
                int shift = keyChar - 'A';
                char encryptedChar = (char)((((letter - 'A') + shift) % 26) + 'A');
                encryptedText.Append(encryptedChar);
            }
            else
            {
                encryptedText.Append(letter);
            }
        }

        return encryptedText.ToString();
    }

    public string VigenereDecrypt(string text)
    {
        string key = "KEY";  // Use the same key for decryption
        text = text.ToUpper();
        key = GenerateKey(text, key);

        StringBuilder decryptedText = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            char letter = text[i];
            if (char.IsLetter(letter))
            {
                char keyChar = key[i];
                int shift = keyChar - 'A';
                char decryptedChar = (char)((((letter - 'A') - shift + 26) % 26) + 'A');
                decryptedText.Append(decryptedChar);
            }
            else
            {
                decryptedText.Append(letter);
            }
        }

        return decryptedText.ToString();
    }
}

