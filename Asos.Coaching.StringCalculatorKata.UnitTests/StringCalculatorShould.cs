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
        public int ResultInInputedNumber(string input)
        {            
            return StringCalculator.Calculate(input);
        }
    }

    internal class StringCalculator
    {
        public static int Calculate(string empty)
        {
            if (empty == "1")
                return 1;
            if (empty == "2")
                return 2;
            return 0;
        }
    }
}
