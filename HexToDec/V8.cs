// SCORE 8.75/10
// Switched to FrozenSet for optimized read-only lookups.
// Small incremental gain since the set is tiny, but it's the right choice for this pattern.

using System.Collections.Frozen;

namespace ConsoleApp2
{
    internal class V8
    {
        static readonly FrozenSet<char> ValidHexChars = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'a', 'b', 'c', 'd', 'e', 'f'];

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

            byte hex_base = 16;
            int decimal_sum = 0;

            for (int i = 0; i < hexadecimal.Length; i++)
            {
                if (!ValidHexChars.Contains(hexadecimal[i])) return 0;
                decimal_sum = decimal_sum * hex_base + Hextodec(hexadecimal[i]);
            }

            return decimal_sum;
        }
    }
}
