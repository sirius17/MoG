using FluentAssertions;
using Xunit;

namespace MoG.Tests
{
    public class NumberSystemFixture
    {
        [Fact]
        public void Number_system_should_allow_setting_aliases_for_digits()
        {
            var numberSystem = new GalacticNumberSystem();
            numberSystem.SetAlias(RomanDigit.I, "glob");
            numberSystem.GetAlias("glob").Should().Be(RomanDigit.I);
        }

        [Theory]
        [InlineData("I", 1)]
        [InlineData("V", 5)]
        [InlineData("X", 10)]
        [InlineData("L", 50)]
        [InlineData("M", 1000)]
        [InlineData("D", 500)]
        [InlineData("C", 100)]
        [InlineData("I I I", 3)]
        [InlineData("I V", 4)]
        [InlineData("V I", 6)]
        public void Number_system_should_be_able_to_convert_galactic_numbers_to_decimal_test(string number, int expected)
        {
            var numberSystem = new GalacticNumberSystem();
            numberSystem.SetAlias(RomanDigit.I, "I");
            numberSystem.SetAlias(RomanDigit.V, "V");
            numberSystem.SetAlias(RomanDigit.X, "X");
            numberSystem.SetAlias(RomanDigit.L, "L");
            numberSystem.SetAlias(RomanDigit.M, "M");
            numberSystem.SetAlias(RomanDigit.D, "D");
            numberSystem.SetAlias(RomanDigit.C, "C");
            numberSystem.GetDecimalValue(number).Should().Be(expected);
        }

        [Theory]
        [InlineData("pish pish", 2)]
        [InlineData("pish glob", 4)]
        [InlineData("pish tegj", 9)]
        public void Alternate_number_system_should_be_able_to_convert_galactic_numbers_to_decimal_test(string number, int expected)
        {
            var numberSystem = new GalacticNumberSystem();
            numberSystem.SetAlias(RomanDigit.I, "pish");
            numberSystem.SetAlias(RomanDigit.V, "glob");
            numberSystem.SetAlias(RomanDigit.X, "tegj");
            numberSystem.GetDecimalValue(number).Should().Be(expected);
        }
    }

}
