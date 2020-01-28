using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using RomanNumeralKata.Interfaces;
using RomanNumeralKata.Services;

namespace RomanNumeralKataTest
{
    [TestFixture]
    public class Tests
    {
        IRomanNumeralConverterService romanConverter;
        IArabicNumeralConverterService arabicConverter;
        ServiceProvider serviceProvider;


        [SetUp]
        public void Init()
        {
            serviceProvider = new ServiceCollection()
                 .AddSingleton<IRomanNumeralConverterService, RomanNumeralConverterService>()
                 .AddSingleton<IArabicNumeralConverterService, ArabicNumeralConverterService>()
                 .BuildServiceProvider();

            romanConverter = serviceProvider.GetService<IRomanNumeralConverterService>();
            arabicConverter = serviceProvider.GetService<IArabicNumeralConverterService>();
        }        

        [Test]
        public void OneEqualsI()
        {
            Assert.IsTrue(arabicConverter.ConvertToRoman(1) == "I");
        }

        [Test]
        public void XEqualsTen()
        {
            Assert.IsTrue(romanConverter.ConvertToArabic("X") == 10);
        }

        [TestCase("L", 50)]
        [TestCase("D", 500)]
        [TestCase("IV", 4)]
        [TestCase("IX", 9)]
        [TestCase("X", 10)]
        [TestCase("C", 100)]
        [TestCase("M", 1000)]
        public void RomanInputThatExistsInDictionaryIsValid(string input, int expectedValue)
        {
            Assert.AreEqual(romanConverter.ConvertToArabic(input), expectedValue);
        }

        [TestCase(1000, "M")]
        [TestCase(900, "CM")]
        [TestCase(500, "D")]
        [TestCase(400, "CD")]
        [TestCase(100, "C")]
        [TestCase(90, "XC")]
        [TestCase(50, "L")]
        [TestCase(40, "XL")]
        [TestCase(10, "X")]
        [TestCase(9, "IX")]
        [TestCase(5, "V")]
        [TestCase(4, "IV")]
        [TestCase(1, "I")]
        public void ArabicInputThatExistsInDictionaryIsValid(int input, string expectedValue)
        {
            Assert.AreEqual(arabicConverter.ConvertToRoman(input), expectedValue);
        }

        [TestCase(900, "CM")]
        [TestCase(3400, "MMMCD")]
        [TestCase(1190, "MCXC")]
        [TestCase(640, "DCXL")]
        [TestCase(2419, "MMCDXIX")]
        [TestCase(846, "DCCCXLVI")]
        [TestCase(1024, "MXXIV")]
        public void ArabicInputThatDoesNotExistInDictionaryIsConvertedCorrectly(int input, string expectedValue)
        {
            Assert.AreEqual(arabicConverter.ConvertToRoman(input), expectedValue);
        }

        [TestCase("MCMXCIX", 1999)]
        [TestCase("CM", 900)]
        [TestCase("MMMCD", 3400)]
        [TestCase("MCXC", 1190)]
        [TestCase("DCXL", 640)]
        [TestCase("MMCDXIX", 2419)]
        [TestCase("DCCCXLVI", 846)]
        [TestCase("MXXIV", 1024)]
        public void RomanInputThatDoesNotExistInDictionaryIsConvertedCorrectly(string input, int expectedValue)
        {
            Assert.AreEqual(romanConverter.ConvertToArabic(input), expectedValue);
        }

        [TestCase("Angela", 765)]
        public void InvalidRomanInputIsRejected(string input, int expectedValue)
        {
            Assert.AreNotEqual(romanConverter.ConvertToArabic(input), expectedValue);
            Assert.AreEqual(romanConverter.ConvertToArabic(input), 0);
        }
    }
}