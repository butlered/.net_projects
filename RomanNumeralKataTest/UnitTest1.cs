using NUnit.Framework;
using RomanNumeralKata;
namespace RomanNumeralKataTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void OneEqualsI()
        {
            Assert.IsTrue(Program.ArabicToRoman(1) == "I");
        }

        [Test]
        public void XEqualsTen()
        {
            Assert.IsTrue(Program.RomanToArabic("X") == 10);
        }

        [TestCase("IV", 4)]
        [TestCase("IX", 9)]
        [TestCase("X", 10)]
        [TestCase("C", 100)]
        [TestCase("M", 1000)]
        public void RomanInputThatExistsInDictionaryIsValid(string input, int expectedValue)
        {
            Assert.AreEqual(Program.RomanToArabic(input), expectedValue);
        }

        [TestCase(5, "V")]
        [TestCase(6, "VI")]
        [TestCase(40, "XL")]
        [TestCase(90, "XC")]
        [TestCase(500, "D")]
        public void ArabicInputThatExistsInDictionaryIsValid(int input, string expectedValue)
        {
            Assert.AreEqual(Program.ArabicToRoman(input), expectedValue);
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
            Assert.AreEqual(Program.ArabicToRoman(input), expectedValue);
        }

        [TestCase("CM", 900)]
        [TestCase("MMMCD", 3400)]
        [TestCase("MCXC", 1190)]
        [TestCase("DCXL", 640)]
        [TestCase("MMCDXIX", 2419)]
        [TestCase("DCCCXLVI", 846)]
        [TestCase("MXXIV", 1024)]
        public void RomanInputThatDoesNotExistInDictionaryIsConvertedCorrectly(string input, int expectedValue)
        {
            Assert.AreEqual(Program.RomanToArabic(input), expectedValue);
        }
    }
}