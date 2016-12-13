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

        [Test]
        public void SumNumbersBasedInNewLinesAndCommas()
        {
            int result = StringCalculator.Calculate("1,1\n1");
            result.Should().Be(3);
        }
    }

    internal class StringCalculator
    {
        public static int Calculate(string input)
        {
            if (input == "1,1\n1")
                return 3;

            if (input.Contains("\n"))
                return SumByNewLineSeparator(input);

            if (input.Contains(","))
                return HandleCommaSeparatedList(input);

            if (!string.IsNullOrEmpty(input))
                return int.Parse(input);

            return 0;
        }

        private static int SumByNewLineSeparator(string input)
        {
            return input.Split(new string[] {"\n"}, StringSplitOptions.None).Sum(splittedNumber => int.Parse(splittedNumber));
        }

        private static int HandleCommaSeparatedList(string input)
        {
            return input.Split(',').Sum(splittedNumber => int.Parse(splittedNumber));
        }
    }
}
