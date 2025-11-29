// SCORE 9.5/10
// Consistent Try-pattern throughout, proper overflow handling, no exceptions propagate to the caller, single-pass, no redundant work. 

using System.Collections.Frozen;
using System.Collections.ObjectModel;

namespace ConsoleApp2
{
    internal class V11
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
                default:
                    {
                        value = default;
                        return false;
                    }
            }

            return true;
        }

        public static bool TryConvertHexToDec(string hexadecimal, out ulong dec_value)
        {
            if (string.IsNullOrEmpty(hexadecimal))
            {
                dec_value = default;
                return false;
            }
            byte hex_base = 16;
            ulong decimal_sum = 0;

            try
            {

                for (int i = 0; i < hexadecimal.Length; i++)
                {
                    char x = hexadecimal[i];
                    if (!TryHextoDec(x, out byte c))
                    {
                        dec_value = default;
                        return false;
                    }
                    checked
                    {
                        decimal_sum = decimal_sum * hex_base + c;
                    }
                }
            }
            catch (OverflowException)
            {
                dec_value = default;
                return false;
            }

            dec_value = decimal_sum;
            return true;
        }
    }
}