using System;
using FluentAssertions;
using Xunit;

namespace MoG.Tests
{
    public class MerchantFixture
    {
        [Fact]
        public static void Merchants_can_be_told_the_aliases_of_their_number_system_test()
        {
            Merchant merchant = new Merchant();
            merchant.Tell("pish is I");
            merchant.NumberSystem.GetDecimalValue("pish").Should().Be(1);
        }
    }
}
