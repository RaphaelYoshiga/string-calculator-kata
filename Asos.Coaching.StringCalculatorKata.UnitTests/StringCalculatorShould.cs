using System;
using FluentAssertions;
using NUnit.Framework;

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


        [Test]
        public void ResultInTheSumOfCommaSeparatedNumbers()
        {
            int result = StringCalculator.Calculate("1,2");

            result.Should().Be(3);
        }
    }

    internal class StringCalculator
    {
        public static int Calculate(string input)
        {
            if (input == "1,2")
                return 3;

            if (!string.IsNullOrEmpty(input))
                return int.Parse(input);

            return 0;
        }
    }
}
