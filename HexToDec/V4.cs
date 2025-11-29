// SCORE 8/10
// Added null/empty check, replaced misleading default case with proper exception.
// Still has unnecessary intermediate array, O(n) string lookup for validation, and double iteration over input.

namespace ConsoleApp2
{
    internal class V4
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
                _ => throw new ArgumentException($"{c} is not a valid hexadecimal character."),
            };
        }

        public static int ConvertHexToDec(string hexadecimal)
        {
            if (string.IsNullOrEmpty(hexadecimal)) return 0;
            if (!IsValidHex(hexadecimal)) return 0;

            byte[] hex_array = hexadecimal.Select(Hextodec).ToArray();
            
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
