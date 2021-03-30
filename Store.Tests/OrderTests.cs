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

        [Fact]
        public void GetItem_WithExistingItem_ReturnsItem()
        {
            var order = new Order(0, new[]
            {
                new OrderItem(0, 3, 10m),
                new OrderItem(1, 5, 200m),
            });

            var orderItem = order.GetItem(1);

            Assert.Equal(5, orderItem.Count);
        }

        [Fact]
        public void GetItem_WithNonExistingItem_ThrowInvalidOperationException()
        {
            var order = new Order(0, new[]
            {
                new OrderItem(0, 3, 10m),
                new OrderItem(1, 5, 200m),
            });

            Assert.Throws<InvalidOperationException>(() => order.GetItem(100));
        }

        [Fact]
        public void AddOrUpdateItem_WithExistingItem_UpdateCount()
        {
            var order = new Order(0, new[]
            {
                new OrderItem(0, 3, 10m),
                new OrderItem(1, 5, 200m),
            });

            var book = new Book(1, null, null, null, null, 0m);

            order.AddOrUpdateItem(book, 10);

            Assert.Equal(5 + 10, order.GetItem(1).Count);
        }

        [Fact]
        public void AddOrUpdateItem_WithNonExistingItem_AddCount()
        {
            var order = new Order(0, new[]
            {
                new OrderItem(0, 3, 10m),
                new OrderItem(1, 5, 200m),
            });

            var book = new Book(5, null, null, null, null, 0m);

            order.AddOrUpdateItem(book, 10);

            Assert.Equal(10, order.GetItem(5).Count);
        }

        [Fact]
        public void RemoveItem_WithExistingItem_RemovesItem()
        {
            var order = new Order(0, new[]
            {
                new OrderItem(0, 3, 10m),
                new OrderItem(1, 5, 200m),
            });

            order.RemoveItem(1);

            Assert.Equal(1, order.Items.Count);
        }

        [Fact]
        public void RemoveItem_WithNonExistingItem_ThrowInvalidOperationException()
        {
            var order = new Order(0, new[]
            {
                new OrderItem(0, 3, 10m),
                new OrderItem(1, 5, 200m),
            });

            Assert.Throws<InvalidOperationException>(() => order.RemoveItem(5));
        }

    }
}
