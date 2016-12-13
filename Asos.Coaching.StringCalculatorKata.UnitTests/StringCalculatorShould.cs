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


        [Test]
        public void ResultInInputedNumber()
        {
            int result = StringCalculator.Calculate("1");

            result.Should().Be(1);
        }
    }

    internal class StringCalculator
    {
        public static int Calculate(string empty)
        {
            if (empty == "1")
                return 1;
            return 0;
        }
    }
}
