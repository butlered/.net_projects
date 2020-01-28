using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RomanNumeralKata.Interfaces;
using RomanNumeralKata.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RomanNumeralKata
{
    public class Program
    {
        private static IRomanNumeralConverterService _romanService;
        private static IArabicNumeralConverterService _arabicService;
        
        static void Main(string[] args)
        {
            //set up dependency injection
            var serviceProvider = new ServiceCollection()
                 .AddSingleton<IRomanNumeralConverterService, RomanNumeralConverterService>()
                 .AddSingleton<IArabicNumeralConverterService, ArabicNumeralConverterService>()
                 .BuildServiceProvider();

            //Trap the CTRL + C keypress and close the application
            Console.CancelKeyPress += new ConsoleCancelEventHandler(HandleClose);
            while(true)
            {
                Console.WriteLine("\nEnter a number for conversion. " +
                    "Arabic numbers will be converted to Roman numerals. " +
                    "Roman numerals will be converted to Arabic numbers. " +
                    "Press CTRL + C to exit.\n" +
                    "Your Input:");

                var input = Console.ReadLine();

                if (int.TryParse(input, out var intInput))
                {
                    _arabicService = serviceProvider.GetService<IArabicNumeralConverterService>();
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
                    _romanService = serviceProvider.GetService<IRomanNumeralConverterService>();
                    var intResult = _romanService.ConvertToArabic(input.ToUpper());
                    if (intResult != 0)
                    {
                        Console.WriteLine($"{input} in Arabic numerals is {intResult}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                    }
                }
                Console.WriteLine("Press any key to continue, or CTRL + C to exit.");
                Console.ReadKey();
            }
        }

        private static void HandleClose(object sender, ConsoleCancelEventArgs args)
        {
            //Simulate cleanup and close
            Console.WriteLine("Exiting...");
            Thread.Sleep(2000);
            Environment.Exit(0);
        }
    }
}