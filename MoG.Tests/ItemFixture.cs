using System;
using FluentAssertions;
using Xunit;

namespace MoG.Tests
{
    public class ItemFixture
    {
        [Fact]
        public void Every_item_has_a_name_test()
        {
            var item = new Item();
            item.Name = "Gold";
            item.Name.Should().Be("Gold");
        }

        [Fact]
        public void Every_item_has_a_price_test()
        {
            var item = new Item();
            item.Price = 10m;
            item.Price.Should().Be(10m);
        }
    }
}
