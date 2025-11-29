// SCORE 7.5/10
// Replaced Math.Pow with efficient multiply-and-add technique, changed to byte for appropriate sizing.
// Still has unnecessary intermediate array, misleading default case, and O(n) string lookup for validation.

namespace ConsoleApp2
{
    internal class V3
    {
        static readonly string ValidHexChars = "0123456789ABCDEFabcdef";

        private static bool IsValidHex(string hex)
        {
            foreach (char c in hex)
            {
                if (ValidHexChars.Contains(c))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }


        private static byte Hextodec(char c)
        {
            return c switch
            {
                '0' or '1' or '2' or '3' or '4' or '5' or '6' or '7' or '8' or '9' => (byte)(c - '0'),
                'A' or 'a' => 10,
                'B' or 'b' => 11,
                'C' or 'c' => 12,
                'D' or 'd' => 13,
                'E' or 'e' => 14,
                'F' or 'f' => 15,
                _ => Convert.ToByte(c),
            };
        }

        public static int ConvertHexToDec(string hexadecimal)
        {
            if (!IsValidHex(hexadecimal)) return 0;

            byte[] hex_array = hexadecimal.Select(Hextodec).ToArray<byte>();
            int hex_array_count = hex_array.Length;
            byte hex_base = 16;
            int decimal_sum = 0;

            for (int i = 0; i < hex_array_count; i++)
            {
                decimal_sum = decimal_sum * hex_base + hex_array[i];
            }

            return decimal_sum;
        }
    }
}
