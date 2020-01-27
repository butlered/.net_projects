using RomanNumeralKata.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanNumeralKata.Services
{
    public class ArabicNumeralConverterService
    {
        public string ConvertToRoman(int input)
        {
            var retVal = string.Empty;
            foreach (var key in NumeralData.Numerals.Keys)
            {
                //Start with the highest number in the numerals list that can be subtracted from the input
                //and continue until the remaining value of the input falls below that of the 
                //selected key, then repeat the process with the remainder until we reach the end of the list
                while (input >= key)
                {
                    //Concatenate the corresponding Roman numeral to the return value
                    //and reduce the input by the amount contained in the key
                    retVal += NumeralData.Numerals[key];
                    input -= key;
                }
            }
            return retVal;
        }
    }
}
