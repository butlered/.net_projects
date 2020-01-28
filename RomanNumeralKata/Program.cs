using Microsoft.Extensions.DependencyInjection;
using RomanNumeralKata.Interfaces;
using RomanNumeralKata.Services;
using System;
using System.Text;
using System.Threading;

namespace RomanNumeralKata
{
    public class Program
    {
        private static IRomanNumeralConverterService _romanService;
        private static IArabicNumeralConverterService _arabicService;
        private static ServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            //set up dependency injection
            _serviceProvider = new ServiceCollection()
                 .AddSingleton<IRomanNumeralConverterService, RomanNumeralConverterService>()
                 .AddSingleton<IArabicNumeralConverterService, ArabicNumeralConverterService>()
                 .BuildServiceProvider();

            //Trap the CTRL + C keypress and close the application
            Console.CancelKeyPress += new ConsoleCancelEventHandler(HandleClose);

            while(true)
            {
                Console.WriteLine("Enter a number for conversion. " +
                    "Arabic numbers will be converted to Roman numerals. " +
                    "Roman numerals will be converted to Arabic numbers. " +
                    "Press CTRL + C to exit.\n\n" +
                    "Your Input:");

                var input = Console.ReadLine();
                try
                {
                    var output = new StringBuilder().Append("Output:\n");
                    if (int.TryParse(input, out var intInput))
                    {
                        output.Append(ProcessArabic(intInput));
                    }
                    else
                    {
                        output.Append(ProcessRoman(input));
                    }
                    Console.WriteLine(output);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An exception occurred while processing your input. Please see below for information:\n{ex.Message}");
                }
                
                Console.WriteLine("Press any key to continue, or CTRL + C to exit.");
                Console.ReadKey();
            }
        }

        private static string ProcessArabic(int input)
        {
            _arabicService = _serviceProvider.GetService<IArabicNumeralConverterService>();
            var stringResult = _arabicService.ConvertToRoman(input);
            if (stringResult != string.Empty)
            {
                return $"{input} in Roman numerals is {stringResult}\n";
               
            }
            else
            {
                return "Invalid input. Please try again.\n";
            }
        }

        private static string ProcessRoman(string input)
        {
            _romanService = _serviceProvider.GetService<IRomanNumeralConverterService>();
            var intResult = _romanService.ConvertToArabic(input.ToUpper());
            if (intResult != 0)
            {
                return $"{input} in Arabic numerals is {intResult}\n";
            }
            else
            {
                return "Invalid input. Please try again.\n";
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