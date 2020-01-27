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
        [TestCase("X", 10)]
        [TestCase("C", 100)]
        [TestCase("M", 1000)]
        public void RomanInputThatExistsInDictionaryIsValid(string input, int expectedValue)
        {
            Assert.AreEqual(Program.RomanToArabic(input), expectedValue);
        }

        [TestCase(5, "V")]
        [TestCase(40, "XL")]
        [TestCase(90, "XC")]
        [TestCase(500, "D")]
        public void ArabicInputThatExistsInDictionaryIsValid(int input, string expectedValue)
        {
            Assert.AreEqual(Program.ArabicToRoman(input), expectedValue);
        }

        [TestCase(1024, "MXXIV")]
        public void ArabicInputThatDoesNotExistInDictionaryIsConvertedCorrectly(int input, string expectedValue)
        {
            Assert.AreEqual(Program.ArabicToRoman(input), expectedValue);
        }

        [TestCase("MXXIV", 1024)]
        public void RomanInputThatDoesNotExistInDictionaryIsConvertedCorrectly(string input, int expectedValue)
        {
            Assert.AreEqual(Program.RomanToArabic(input), expectedValue);
        }
    }
}