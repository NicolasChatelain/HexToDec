// SCORE 6.5/10
// Added lowercase support and input validation. Still has inefficient Math.Pow in loop,
// unnecessary intermediate array, and misleading default case.

namespace ConsoleApp2
{
    internal class V2
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


        private static int Hextodec(char c)
        {
            return c switch
            {
                '0' or '1' or '2' or '3' or '4' or '5' or '6' or '7' or '8' or '9' => c - '0',
                'A' or 'a' => 10,
                'B' or 'b' => 11,
                'C' or 'c' => 12,
                'D' or 'd' => 13,
                'E' or 'e' => 14,
                'F' or 'f' => 15,
                _ => Convert.ToInt32(c),
            };
        }

        public static int ConvertHexToDec(string hexadecimal)
        {

            if (!IsValidHex(hexadecimal)) return 0;

            var hex_array = hexadecimal.Select(Hextodec).ToArray<int>();
            var hex_array_count = hex_array.Length;
            var hex_base = 16;
            var decimal_sum = 0;

            for (int i = hex_array_count - 1, j = 0; i >= 0; i--, j++)
            {
                decimal_sum += (hex_array[j] * (int)Math.Pow(hex_base, i));
            }

            return decimal_sum;
        }
    }
}
