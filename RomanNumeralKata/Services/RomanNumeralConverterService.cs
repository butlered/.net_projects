using RomanNumeralKata.Data;
using RomanNumeralKata.Interfaces;
using System.Linq;

namespace RomanNumeralKata.Services
{
    public class RomanNumeralConverterService : IRomanNumeralConverterService
    {
        public int ConvertToArabic(string input)
        {
            //validate input
            if (!input.All(s => NumeralData.RomanData.ContainsKey(s)))
            {
                return 0;
            }

            var retVal = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var current = input[i];
                var next = (i + 1) < input.Length ? input[i + 1] : input[i];
                //Subtract the value of the current character from the return value if the following one has a larger value, or else add it.
                if (i + 1 < input.Length && NumeralData.RomanData[current] < NumeralData.RomanData[next])
                {
                    retVal -= NumeralData.RomanData[current];
                }
                else
                {
                    retVal += NumeralData.RomanData[current];
                }
            }
            return retVal;
        }
    }
}
