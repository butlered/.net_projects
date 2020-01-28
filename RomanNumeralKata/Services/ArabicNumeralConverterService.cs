using RomanNumeralKata.Data;
using RomanNumeralKata.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumeralKata.Services
{
    public class ArabicNumeralConverterService : IArabicNumeralConverterService
    {
        public string ConvertToRoman(int input)
        {
            var retVal = new StringBuilder();
            foreach (var val in NumeralData.ArabicData.Keys)
            {
                //Start with the highest number in the numerals list that can be subtracted from the input
                //and continue until the remaining value of the input falls below that of the 
                //selected key, then repeat the process with the remainder until we reach the end of the list
                while (input >= val)
                {
                    //Concatenate the corresponding Roman numeral to the return value
                    //and reduce the input by the amount contained in the key
                    retVal.Append(NumeralData.ArabicData[val]);
                    input -= val;
                }
            }
            return retVal.ToString();
        }
    }
}
