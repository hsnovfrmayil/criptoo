using System;
using System.Text;

namespace CriptoLesson.Models.CipherMethods;

public class FealMethods
{
    // Feal Encrypt metodunu yazmaq
    public string FealEncrypt(string input)
    {
        // Burada Feal algoritması tətbiq edilir
        // Bu, sadəcə bir nümunədir. Gerçek Feal algoritmasını əlavə etmək lazımdır
        StringBuilder encryptedText = new StringBuilder();
        foreach (char c in input)
        {
            encryptedText.Append((char)(c + 3)); // Hər hərfi 3 artıra bilərik (sadə shift metodu ilə)
        }
        return encryptedText.ToString();
    }

    // Feal Decrypt metodunu yazmaq
    public string FealDecrypt(string input)
    {
        // Burada Feal algoritması ilə şifrəni açırıq
        StringBuilder decryptedText = new StringBuilder();
        foreach (char c in input)
        {
            decryptedText.Append((char)(c - 3)); // Hər hərfi 3 çıxara bilərik
        }
        return decryptedText.ToString();
    }
}
