// SCORE 10/10
// FrozenDictionary for optimal read-only lookups, Try-pattern throughout, proper overflow handling, single-pass, no redundant work, clean and maintainable.
using System.Collections.Frozen;

namespace ConsoleApp2
{
    internal class V12
    {

        static readonly FrozenDictionary<char, byte> hex_lookup_table = new Dictionary<char, byte>()
        {
            {'0',0},
            {'1',1},
            {'2',2},
            {'3',3},
            {'4',4},
            {'5',5},
            {'6',6},
            {'7',7},
            {'8',8},
            {'9',9},
            {'a',10},
            {'b',11},
            {'c',12},
            {'d',13},
            {'e',14},
            {'f',15},
            {'A',10},
            {'B',11},
            {'C',12},
            {'D',13},
            {'E',14},
            {'F',15},
        }.ToFrozenDictionary();

        private static bool TryHextoDec(char c, out byte value)
        {
            return hex_lookup_table.TryGetValue(c, out value);
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