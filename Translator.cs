using System.Text;

public class Translator
{
    public string HexToWords(string hex, List<string> dict)
    {
        hex = hex.Replace(" ", "").Replace("\n", "").Replace("\r", "");

        int bitLength = hex.Length * 4;   // OPTION 3

        List<int> bits = new List<int>();

        // Store bitLength (32 bits)
        for (int i = 31; i >= 0; i--)
            bits.Add((bitLength >> i) & 1);

        // Convert each hex char → 4 bits
        foreach (char c in hex)
        {
            int value = Convert.ToInt32(c.ToString(), 16);
            for (int i = 3; i >= 0; i--)
                bits.Add((value >> i) & 1);
        }

        int bitsPerWord = (int)Math.Log2(dict.Count);
        List<string> words = new List<string>();

        int current = 0;
        int currentBits = 0;

        // PACK FULL WORDS
        foreach (int bit in bits)
        {
            current = (current << 1) | bit;
            currentBits++;

            if (currentBits == bitsPerWord)
            {
                words.Add(dict[current]);
                current = 0;
                currentBits = 0;
            }
        }

        // ⭐⭐⭐ THIS IS THE CRITICAL PART ⭐⭐⭐
        // Flush leftover bits (pad with zeros)
        if (currentBits > 0)
        {
            current <<= (bitsPerWord - currentBits);
            words.Add(dict[current]);
        }
        // ⭐⭐⭐ END CRITICAL PART ⭐⭐⭐

        return string.Join(" ", words);
    }



    //to encode base 64 Encrypted messages
    public static string Base64ToHex(string base64)
    {
        byte[] bytes = Convert.FromBase64String(base64);
        StringBuilder sb = new StringBuilder(bytes.Length * 2);

        foreach (byte b in bytes)
            sb.AppendFormat("{0:X2}", b);

        return sb.ToString();
    }






    public string WordsToHex(string text, List<string> dict)
    {
        var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int bitsPerWord = (int)Math.Log2(dict.Count);

        // Step 1: Convert words → bitstream
        List<int> bits = new List<int>();

        foreach (var w in words)
        {
            int idx = dict.IndexOf(w);
            if (idx < 0)
                throw new Exception($"Word not found: {w}");

            for (int i = bitsPerWord - 1; i >= 0; i--)
                bits.Add((idx >> i) & 1);
        }

        // Step 2: Read first 32 bits → bitLength
        int bitLength = 0;
        for (int i = 0; i < 32; i++)
            bitLength = (bitLength << 1) | bits[i];

        // Step 3: Extract EXACT bitLength bits of hex data

        int start = 32;
        int end = start + bitLength;

        // SAFETY: ensure we don't go out of range
        if (end > bits.Count)
            end = bits.Count;


        // Step 4: Convert 4 bits → hex symbol
        int hexLength = bitLength / 4;
        char[] hexChars = new char[hexLength];

        for (int i = 0; i < hexLength; i++)
        {
            int value = 0;
            for (int b = 0; b < 4; b++)
                value = (value << 1) | bits[start + i * 4 + b];

            hexChars[i] = "0123456789ABCDEF"[value];
        }

        return new string(hexChars);
    }


    //hex pack to base 64 for encrypted messages
    public static string HexToBase64(string hex)
    {
        int len = hex.Length;
        byte[] bytes = new byte[len / 2];

        for (int i = 0; i < len; i += 2)
            bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);

        return Convert.ToBase64String(bytes);
    }






}
