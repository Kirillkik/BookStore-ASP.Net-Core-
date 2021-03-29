using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Store.Tests
{
    public class OrederItemTests
    {
        [Fact]
        public void OrderItem_WithZeroCount_TrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new OrderItem(1, 0, 0m); 
            });
        }

        [Fact]
        public void OrderItem_WithNegativeCount_TrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new OrderItem(1, -2, 0m);
            });
        }

        [Fact]
        public void OrderItem_WithPositiveCount_TrowsArgumentOutOfRangeException()
        {
            var orderitem = new OrderItem(2, 10, 5m);
            Assert.Equal(2, orderitem.BookId);
            Assert.Equal(10, orderitem.Count);
            Assert.Equal(5m, orderitem.Price);
        }
    }
}
