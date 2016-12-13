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
    }

    internal class StringCalculator
    {
        public static int Calculate(string empty)
        {
            return 0;
        }
    }
}
