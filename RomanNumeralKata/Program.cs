using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumeralKata
{
    public class Program
    {
        //Initial list of Roman numerals and their Arabic equivalents.
        static Dictionary<int, string> numerals = new Dictionary<int, string>
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
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter a number for conversion. Arabic numbers will be converted to Roman numerals. Roman numerals will be converted to Arabic numbers.\nYour Input:");
            var input = Console.ReadLine();
            var intInput = int.MinValue;
            if(int.TryParse(input, out intInput))
            {
                var stringResult = ArabicToRoman(intInput);
                if(stringResult != string.Empty)
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
                var intResult = RomanToArabic(input);
                if(intResult != 0)
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
        public static int RomanToArabic(string romanInput)
        {
            var retVal = numerals.FirstOrDefault(n => n.Value == romanInput).Key;
            return retVal;
        }

        public static string ArabicToRoman(int arabicInput)
        {
            var retVal = string.Empty;
            foreach(var key in numerals.Keys)
            {
                //Start with the highest number in the numerals list that can be subtracted from the input
                //and continue until the remaining value of the input falls below that of the 
                //selected key, then repeat the process with the remainder until we reach the end of the list
                while (arabicInput >= key)
                {
                    //Concatenate the corresponding Roman numeral to the return value
                    //and reduce the input by the amount contained in the key
                    retVal += numerals[key];
                    arabicInput -= key;
                }
            }
            return retVal;
        }
    }
}