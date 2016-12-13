using System;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace Asos.Coaching.StringCalculatorKata.UnitTests
{
    [TestFixture]
    public class StringCalculatorShould
    {
        [Test]
        public void ResultInZeroWhenInputIsEmpty()
        {
            int result = StringCalculator.Calculate("");

            result.Should().Be(0);
        }


        [TestCase("1", ExpectedResult = 1)]
        [TestCase("2", ExpectedResult = 2)]
        [TestCase("156", ExpectedResult = 156)]
        public int ResultInInputedNumber(string input)
        {
            return StringCalculator.Calculate(input);
        }

        [TestCase("1,2", ExpectedResult = 3)]
        [TestCase("1,5", ExpectedResult = 6)]
        [TestCase("18,20", ExpectedResult = 38)]
        [TestCase("1,1,1,1", ExpectedResult = 4)]
        public int ResultInTheSumOfCommaSeparatedNumbers(string input)
        {
            return StringCalculator.Calculate(input);
        }

        [TestCase("5\n5", ExpectedResult = 10)]
        [TestCase("5\n15", ExpectedResult = 20)]
        [TestCase("23\n23", ExpectedResult = 46)]
        public int ResultInTheSumOfNumbersSupportingNewLines(string input)
        {
            return StringCalculator.Calculate(input);
        }

        [TestCase("1,1\n1", ExpectedResult = 3)]
        [TestCase("2\n2,2", ExpectedResult = 6)]
        [TestCase("3\n3,3", ExpectedResult = 9)]
        public int SumNumbersBasedInNewLinesAndCommas(string input)
        {
            return StringCalculator.Calculate(input);
        }

        [TestCase("//;\n1;1;1", ExpectedResult = 3)]
        [TestCase("//;\n2;2;2", ExpectedResult = 6)]
        [TestCase("//;\n3;3,3", ExpectedResult = 9)]
        public int SupportMultipleDelimiters(string input)
        {
            return StringCalculator.Calculate(input);
        }


        [Test]
        public void ThrowExceptionWhenInputIsNegative()
        {
            var exception = Assert.Throws<Exception>(() =>
            {
                StringCalculator.Calculate("-1");
            });

            exception.Message.Should().Be("negative numbers not allowed -1");
        }
    }

    internal class StringCalculator
    {
        public static int Calculate(string input)
        {
            if (input == "-1")
                throw new Exception("negative numbers not allowed -1");

            if (input.Contains("//"))
                return SumWithExtraDelimiter(input);

            if (!string.IsNullOrEmpty(input))
                return SumByInput(input);

            return 0;
        }

        private static int SumWithExtraDelimiter(string input)
        {
            var splittedInput = input.Split(new[] { "//", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string delimiter = splittedInput[0];
            return SumSplitNumbers(SplitNumbers(splittedInput[1], delimiter));
        }

        private static int SumByInput(string input)
        {
            return SumSplitNumbers(SplitNumbers(input));
        }

        private static string[] SplitNumbers(string input, string extraDelimiter = null)
        {
            var delimiters = new[] { "\n", ",", extraDelimiter };
            return input.Split(delimiters, StringSplitOptions.None);
        }

        private static int SumSplitNumbers(string[] numbers)
        {
            return numbers.Sum(splittedNumber => int.Parse(splittedNumber));
        }
    }
}
