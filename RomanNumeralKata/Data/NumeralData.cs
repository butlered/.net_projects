using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RomanNumeralKata.Data
{
    //Class used to simulate data store
    public class NumeralData
    {
        public static Dictionary<int, string> Numerals = new Dictionary<int, string>
        {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 6, "VI" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" }
        };

        public static Dictionary<char, char> PreviousValues = new Dictionary<char, char>
        {
            { 'V', 'I' },
            { 'I', 'V' },
            { 'X', 'I' },
            { 'L', 'X' },
            { 'C', 'X' },
            { 'D', 'C' },
            { 'M', 'C' }
        };

        public static Dictionary<string, int> AmountsToAdjust = new Dictionary<string, int>
        {
            { "IV", -1 },
            { "VI", 5 },
            { "IX", -1 },
            { "XL", -10 },
            { "XC", -10 },
            { "CD", -100 },
            { "CM", -100 }
        };
    }
}
