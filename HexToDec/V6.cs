// SCORE 8.5/10
// Eliminated intermediate array, processing characters directly.
// Still has double iteration over input (validation loop + conversion loop).

// NOTE: This version is well enough optimized for production, anything more is only necessary in high performance environments.

namespace ConsoleApp2
{
    internal class V6
    {
        static readonly HashSet<char> ValidHexChars = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'a', 'b', 'c', 'd', 'e', 'f'];

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

            byte hex_base = 16;
            int decimal_sum = 0;

            for (int i = 0; i < hexadecimal.Length; i++)
            {
                decimal_sum = decimal_sum * hex_base + Hextodec(hexadecimal[i]);
            }

            return decimal_sum;
        }
    }
}
