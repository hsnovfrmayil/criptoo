using System;
using System.Text;

namespace CriptoLesson.Models.CipherMethods
{
    public class FeistelMethods
    {
        // Feistel Round Function
        private string FeistelRound(string left, string right, string key)
        {
            // Burada sağ ve sol parçaların uzunluklarının eşit olduğundan emin olun
            if (left.Length != right.Length)
            {
                throw new ArgumentException("Left and right parts must have the same length.");
            }

            StringBuilder roundResult = new StringBuilder();
            for (int i = 0; i < right.Length; i++)
            {
                char leftChar = left[i];
                char rightChar = (char)(right[i] ^ key[i % key.Length]); // XOR operation (simplified)
                roundResult.Append(rightChar);
            }

            return roundResult.ToString();
        }

        public string FeistelEncrypt(string text, string key)
        {
            // Metnin uzunluğunu kontrol et
            int halfLength = text.Length / 2;

            // Eğer metin uzunluğu tekse, sağ tarafı bir karakter fazla yap
            if (text.Length % 2 != 0) halfLength++;

            // Metni ikiye ayır
            string left = text.Substring(0, halfLength);
            string right = text.Substring(halfLength);

            // Feistel fonksiyonu ile şifreleme işlemi
            for (int i = 0; i < 16; i++) // 16 tur
            {
                string newLeft = right;
                string newRight = FeistelRound(left, right, key);

                left = newLeft;
                right = newRight;
            }

            // Sonuçları birleştir
            return left + right;
        }

        public string FeistelDecrypt(string text, string key)
        {
            // Metnin uzunluğunu kontrol et
            int halfLength = text.Length / 2;

            // Eğer metin uzunluğu tekse, sağ tarafı bir karakter fazla yap
            if (text.Length % 2 != 0) halfLength++;

            // Metni ikiye ayır
            string left = text.Substring(0, halfLength);
            string right = text.Substring(halfLength);

            // Feistel fonksiyonu ile çözme işlemi (tersine sırayla)
            for (int i = 0; i < 16; i++) // 16 tur
            {
                string newLeft = right;
                string newRight = FeistelRound(left, right, key);

                left = newLeft;
                right = newRight;
            }

            // Sonuçları birleştir
            return left + right;
        }
    }
}
