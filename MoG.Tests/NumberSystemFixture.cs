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

    }
}
