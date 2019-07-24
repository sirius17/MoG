using System;
using FluentAssertions;
using Xunit;

namespace MoG.Tests
{
    public class ItemFixture
    {
        [Fact]
        public void Every_item_must_have_a_name_and_price()
        {
            var item = new Item("gold", 10f);
            item.Name.Should().Be("gold");
            item.Price.Should().Be(10f);
        }
    }


}
