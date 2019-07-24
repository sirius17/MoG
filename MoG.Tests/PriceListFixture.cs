using FluentAssertions;
using Xunit;

namespace MoG.Tests
{
    public class PriceListFixture
    {
        [Fact]
        public void PriceList_should_allow_addition_of_items()
        {
            var prices = new PriceList();
            prices.AddItem(new Item("apple",10f));
            prices.GetUnitPrice("apple").Should().Be(10f);
        }
    }
}
