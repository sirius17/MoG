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

        [Fact]
        public static void Merchants_can_be_told_the_price_of_items_test()
        {
            Merchant merchant = new Merchant();
            merchant.Tell("pish is I");
            merchant.Tell("pish pish Silver is 34 Credits");
            merchant.Prices.GetUnitPrice("Silver").Should().Be(17);

        }


        [Fact]
        public static void Merchants_can_respond_to_number_conversion_test()
        {
            Merchant merchant = new Merchant();
            merchant.Tell("pish is I");
            merchant.Tell("glob is V");
            var reply = merchant.Ask("how much is pish glob ?");
            reply.Text.Should().Be("pish glob is 4.");
        }

        [Fact]
        public static void Merchants_can_respond_to_price_quote_questions_test()
        {
            Merchant merchant = new Merchant();
            merchant.Tell("pish is I");
            merchant.Tell("pish pish Silver is 20 Credits");
            var reply = merchant.Ask("how many Credits is pish pish pish Silver ?");
            reply.Text.Should().Be("pish pish pish Silver is 30 Credits");
        }
    }
}
