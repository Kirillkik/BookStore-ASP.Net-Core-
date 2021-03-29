﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
{
    public class Order
    {
        public int Id { get; }
        private List<OrderItem> items;
        public IReadOnlyCollection<OrderItem> Items => items;
        public int TotalCount => items.Sum(item => item.Count);
        public decimal TotalPrice => items.Sum(item => item.Count * item.Price);
        public Order(int id, IEnumerable<OrderItem> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            Id = id;
            this.items = new List<OrderItem>(items);
        }

        // TODO Cover unit tests
        public void AddItem(Book book, int count)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            var item = items.SingleOrDefault(_item => _item.BookId == book.Id);

            if(item == null)
            {
                items.Add(new OrderItem(book.Id, count, book.Price));
            }
            else
            {
                items.Remove(item);
                items.Add(new OrderItem(book.Id, item.Count + count, book.Price));
            }
        }
    }
}