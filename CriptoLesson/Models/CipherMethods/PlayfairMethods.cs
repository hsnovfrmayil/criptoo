using System;
using System.Linq;
using System.Text;

namespace CriptoLesson.Models.CipherMethods
{
    public class PlayfairMethods
    {
        public string PlayfairEncrypt(string input)
        {
            input = FormatInput(input); // Giriş mətni formatlaşdırılır
            char[,] matrix = GenerateMatrix(); // 5x5 matrix yaradılır
            string encryptedText = string.Empty;

            for (int i = 0; i < input.Length; i += 2)
            {
                char firstChar = input[i];
                char secondChar = (i + 1 < input.Length) ? input[i + 1] : 'X'; // Əgər ikinci hərf yoxdursa, 'X' əlavə edilir
                var pair = EncryptPair(firstChar, secondChar, matrix);
                encryptedText += pair.Item1.ToString() + pair.Item2.ToString();
            }

            return encryptedText;
        }

        public string PlayfairDecrypt(string input)
        {
            input = FormatInput(input); // Giriş mətni formatlaşdırılır
            char[,] matrix = GenerateMatrix(); // 5x5 matrix yaradılır
            string decryptedText = string.Empty;

            for (int i = 0; i < input.Length; i += 2)
            {
                char firstChar = input[i];
                char secondChar = input[i + 1];
                var pair = DecryptPair(firstChar, secondChar, matrix);
                decryptedText += pair.Item1.ToString() + pair.Item2.ToString();
            }

            return decryptedText;
        }

        private string FormatInput(string input)
        {
            input = input.ToUpper().Replace("J", "I").Replace(" ", "");

            StringBuilder formattedInput = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                formattedInput.Append(input[i]);
                if (i + 1 < input.Length && input[i] == input[i + 1])
                {
                    formattedInput.Append('X');
                }
            }

            if (formattedInput.Length % 2 != 0)
            {
                formattedInput.Append('X');
            }

            return formattedInput.ToString();
        }

        private char[,] GenerateMatrix()
        {
            string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ"; // Removed array conversion
            char[,] matrix = new char[5, 5];
            int index = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = alphabet[index++]; // Now assigning a char to a char element
                }
            }

            return matrix;
        }

        private (char, char) EncryptPair(char firstChar, char secondChar, char[,] matrix)
        {
            int[] firstPos = FindPosition(firstChar, matrix);
            int[] secondPos = FindPosition(secondChar, matrix);

            if (firstPos[0] == secondPos[0]) // Same row
            {
                return (matrix[firstPos[0], (firstPos[1] + 1) % 5], matrix[secondPos[0], (secondPos[1] + 1) % 5]);
            }
            else if (firstPos[1] == secondPos[1]) // Same column
            {
                return (matrix[(firstPos[0] + 1) % 5, firstPos[1]], matrix[(secondPos[0] + 1) % 5, secondPos[1]]);
            }
            else // Rectangle case
            {
                return (matrix[firstPos[0], secondPos[1]], matrix[secondPos[0], firstPos[1]]);
            }
        }

        private (char, char) DecryptPair(char firstChar, char secondChar, char[,] matrix)
        {
            int[] firstPos = FindPosition(firstChar, matrix);
            int[] secondPos = FindPosition(secondChar, matrix);

            if (firstPos[0] == secondPos[0]) // Same row
            {
                return (matrix[firstPos[0], (firstPos[1] + 4) % 5], matrix[secondPos[0], (secondPos[1] + 4) % 5]);
            }
            else if (firstPos[1] == secondPos[1]) // Same column
            {
                return (matrix[(firstPos[0] + 4) % 5, firstPos[1]], matrix[(secondPos[0] + 4) % 5, secondPos[1]]);
            }
            else // Rectangle case
            {
                return (matrix[firstPos[0], secondPos[1]], matrix[secondPos[0], firstPos[1]]);
            }
        }

        private int[] FindPosition(char ch, char[,] matrix)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (matrix[i, j] == ch)
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return new int[] { -1, -1 }; // Return invalid position if not found
        }
    }
}
