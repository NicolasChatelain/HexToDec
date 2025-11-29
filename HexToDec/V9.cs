// SCORE 9/10
// Clean, efficient, single-pass, no redundant work. You're in the final stretch now.
// The remaining points are genuinely pedantic territory — things like how exceptions are handled, or alternative data structures for the lookup.

namespace ConsoleApp2
{
    internal class V9
    {
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
                char x = hexadecimal[i];
                decimal_sum = decimal_sum * hex_base + Hextodec(x);
            }

            return decimal_sum;
        }
    }
}
