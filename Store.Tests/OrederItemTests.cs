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
        public void OrderItem_WithPositiveCount_SetsCount()
        {
            var orderitem = new OrderItem(2, 10, 5m);
            Assert.Equal(2, orderitem.BookId);
            Assert.Equal(10, orderitem.Count);
            Assert.Equal(5m, orderitem.Price);
        }

        [Fact]
        public void Count_WithNegativeValue_ThrowArgumentOutOfRangeException()
        {
            var orderitem = new OrderItem(2, 10, 5m);
            Assert.Throws<ArgumentOutOfRangeException>(() => orderitem.Count = -1);
        }

        [Fact]
        public void Count_WithZeroValue_ThrowArgumentOutOfRangeException()
        {
            var orderitem = new OrderItem(2, 10, 5m);
            Assert.Throws<ArgumentOutOfRangeException>(() => orderitem.Count = -1);
        }

        [Fact]
        public void Count_WithPositiveValue_SetsCount()
        {
            var orderitem = new OrderItem(2, 10, 5m);
            orderitem.Count = 5;
            Assert.Equal(5, orderitem.Count);
        }
    }
}
