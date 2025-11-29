// SCORE 6/10
// Functional but has issues: no lowercase support, no input validation, inefficient Math.Pow in loop,
// misleading default case, unnecessary intermediate array.

namespace ConsoleApp2
{
    internal class V1
    {
        private static int hextodec(char c)
        {
            switch (c)
            {
                case '0' or '1' or '2' or '3' or '4' or '5' or '6' or '7' or '8' or '9':
                    return c - '0';
                case 'A': return 10;
                case 'B': return 11;
                case 'C': return 12;
                case 'D': return 13;
                case 'E': return 14;
                case 'F': return 15;
                default: return Convert.ToInt32(c);
            }
        }

        public static int ConvertHexToDec(string hexadecimal)
        {
            var hex_array = hexadecimal.Select(hextodec).ToArray<int>();
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
