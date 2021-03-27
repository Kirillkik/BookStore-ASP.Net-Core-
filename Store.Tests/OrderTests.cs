using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Store.Tests
{
    public class OrderTests
    {
        [Fact]
        public void Order_WithNullItems_ThrowNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Order(0, null));
        }

        [Fact]
        public void TotalCount_WithEmptyItems_ReturnsZero()
        {
            var order = new Order(0, new OrderItem[0]);
            Assert.Equal(0, order.TotalCount);
        }

        [Fact]
        public void TotalPrice_WithEmptyItems_ReturnsZero()
        {
            var order = new Order(0, new OrderItem[0]);
            Assert.Equal(0, order.TotalPrice);
        }

        [Fact]
        public void TotalCount_WithNoEmptyItems_ReturnsTotalCount()
        {
            var order = new Order(0, new[]
            {
                new OrderItem(0, 3, 10m),
                new OrderItem(1, 5, 200m),
            });
            Assert.Equal(3 + 5, order.TotalCount);
        }

        [Fact]
        public void TotalPrice_WithNoEmptyItems_ReturnsTotalPrice()
        {
            var order = new Order(0, new[]
            {
                new OrderItem(0, 3, 10m),
                new OrderItem(1, 5, 200m),
            });
            Assert.Equal(3 * 10m + 5 * 200m, order.TotalPrice);
        }
    }
}
