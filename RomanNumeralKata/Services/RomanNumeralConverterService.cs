using RomanNumeralKata.Data;
using RomanNumeralKata.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumeralKata.Services
{
    public class RomanNumeralConverterService : IRomanNumeralConverterService
    {
        public int ConvertToArabic(string input)
        {
            //validate input
            if (!input.Any(s => NumeralData.Numerals.ContainsValue(s.ToString())))
            {
                return 0;
            }
            var retVal = 0;

            for (int i = (input.Length - 1); i >= 0; i--)
            {
                var current = input[i];
                if (i > 0)
                {
                    //Check the character immediately preceding the current one, and adjust the total value accordingly.
                    //If the value is adjusted, decrement the counter so that the preceding character is not processed.
                    var prev = input[i - 1];
                    if (NumeralData.PreviousValues.ContainsKey(current) && NumeralData.PreviousValues[current] == prev)
                    {
                        var key = prev.ToString() + current.ToString();
                        var valueToAdjust = NumeralData.AmountsToAdjust[key];
                        retVal += valueToAdjust;
                        i--;
                    }
                }
                retVal += NumeralData.Numerals.FirstOrDefault(x => x.Value == current.ToString()).Key;
            }
            return retVal;
        }
    }
}
