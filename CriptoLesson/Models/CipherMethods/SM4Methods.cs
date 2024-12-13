using System.Text;

public class SM4Methods
{
    public string SM4Encrypt(string inputText, string key)
    {
        if (string.IsNullOrEmpty(inputText) || string.IsNullOrEmpty(key))
        {
            throw new ArgumentNullException("Input text or key cannot be null or empty.");
        }

        byte[] inputBytes = Encoding.UTF8.GetBytes(inputText);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key.PadRight(16, ' ')); // 16 bayt uzunluğunda açar təmin et

        byte[] encryptedBytes = SimpleSM4Encrypt(inputBytes, keyBytes);
        return Convert.ToBase64String(encryptedBytes);
    }

    public string SM4Decrypt(string inputText, string key)
    {
        //if (string.IsNullOrEmpty(inputText) || string.IsNullOrEmpty(key))
        //{
        //    throw new ArgumentNullException("Input text or key cannot be null or empty.");
        //}

        byte[] inputBytes = Convert.FromBase64String(inputText);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key.PadRight(16, ' ')); // 16 bayt uzunluğunda açar təmin et

        byte[] decryptedBytes = SimpleSM4Decrypt(inputBytes, keyBytes);
        return Encoding.UTF8.GetString(decryptedBytes);
    }

    private byte[] SimpleSM4Encrypt(byte[] input, byte[] key)
    {
        for (int i = 0; i < input.Length; i++)
        {
            input[i] ^= key[i % key.Length];
        }
        return input;
    }

    private byte[] SimpleSM4Decrypt(byte[] input, byte[] key)
    {
        return SimpleSM4Encrypt(input, key);
    }
}
