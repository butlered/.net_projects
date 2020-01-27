using RomanNumeralKata.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumeralKata
{
    public class Program
    {
        private static RomanNumeralConverterService _romanService;
        private static ArabicNumeralConverterService _arabicService;
        
        static void Main(string[] args)
        {

            Console.WriteLine("Enter a number for conversion. Arabic numbers will be converted to Roman numerals. Roman numerals will be converted to Arabic numbers.\nYour Input:");
            var input = Console.ReadLine();
            if (int.TryParse(input, out  var intInput))
            {
                _arabicService = new ArabicNumeralConverterService();
                var stringResult = _arabicService.ConvertToRoman(intInput);
                if (stringResult != string.Empty)
                {
                    Console.WriteLine($"{intInput} in Roman numerals is {stringResult}");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
            else
            {
                _romanService = new RomanNumeralConverterService();
                var intResult = _romanService.ConvertToArabic(input);
                if (intResult != 0)
                {
                    Console.WriteLine($"{intInput} in Roman numerals is {intResult}");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
            Console.ReadKey();

        }
    }
}