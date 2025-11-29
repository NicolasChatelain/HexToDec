// SCORE 9.25/10
// Clean Try-pattern, no exceptions for expected failures, single-pass, no redundant work. This is solid, production-quality code.

namespace ConsoleApp2
{
    internal class V10
    {
        private static bool TryHextoDec(char c, out byte value)
        {
            switch (c)
            {
                case '0' or '1' or '2' or '3' or '4' or '5' or '6' or '7' or '8' or '9': value = (byte)(c - '0'); break;
                case 'A' or 'a': value = 10; break;
                case 'B' or 'b': value = 11; break;
                case 'C' or 'c': value = 12; break;
                case 'D' or 'd': value = 13; break;
                case 'E' or 'e': value = 14; break;
                case 'F' or 'f': value = 15; break;
                default :
                    {
                        value = default;
                        return false;
                    }
            }

            return true;
        }

        public static int ConvertHexToDec(string hexadecimal)
        {
            if (string.IsNullOrEmpty(hexadecimal)) return 0;

            byte hex_base = 16;
            int decimal_sum = 0;

            for (int i = 0; i < hexadecimal.Length; i++)
            {
                char x = hexadecimal[i];
                if (!TryHextoDec(x, out byte c)) return 0;
                decimal_sum = decimal_sum * hex_base + c;
            }

            return decimal_sum;
        }
    }
}
