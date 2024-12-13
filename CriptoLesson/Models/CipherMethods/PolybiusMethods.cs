using System;
using System.Text;

namespace CriptoLesson.Models.CipherMethods
{
    public class PolybiusMethods
    {
        // Polybius şifreleme fonksiyonu
        public string PolybiusEncrypt(string input)
        {
            input = input.ToUpper().Replace('J', 'I'); // 'J' harfini 'I' olarak kabul et
            StringBuilder encryptedText = new StringBuilder();

            // Polybius matrisinde harfleri çift sayılarla temsil et
            foreach (char c in input)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    int row = (c - 'A') / 5;
                    int col = (c - 'A') % 5;
                    encryptedText.Append((row + 1).ToString());
                    encryptedText.Append((col + 1).ToString());
                }
                else if (c == ' ')
                {
                    encryptedText.Append(" "); // Boşlukları olduğu gibi bırak
                }
            }

            return encryptedText.ToString();
        }

        // Polybius çözme fonksiyonu
        public string PolybiusDecrypt(string input)
        {
            StringBuilder decryptedText = new StringBuilder();

            // Girişin her iki karakterini alarak çözme işlemi
            for (int i = 0; i < input.Length; i += 2)
            {
                // Boşluk varsa, olduğu gibi ekleyelim
                if (input[i] == ' ')
                {
                    decryptedText.Append(' ');
                    continue;
                }

                // Eğer 'i + 1' geçerli bir indeks değilse, bu durumda sadece bir karakter kalmıştır
                // Bu durumu geçersiz olarak kabul edip devam ediyoruz
                if (i + 1 >= input.Length)
                {
                    break;
                }

                // Karakter çiftlerini alalım (Her iki karakteri birleştirerek sayıya dönüştür)
                int row = input[i] - '0' - 1;    // Satır (1-5 arası, '1' => 0, '2' => 1, ...)
                int col = input[i + 1] - '0' - 1; // Sütun (1-5 arası, '1' => 0, '2' => 1, ...)

                // Satır ve sütun geçerli değilse, geçerli bir format yok
                if (row < 0 || row > 4 || col < 0 || col > 4)
                {
                    continue; // Bu durumda geçerli bir harf yok, atla
                }

                // Polybius matrisine göre harfi çöz
                char decryptedChar = (char)('A' + row * 5 + col);
                decryptedText.Append(decryptedChar);
            }

            return decryptedText.ToString();
        }
    }
}
