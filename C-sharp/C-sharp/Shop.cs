using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lesson_11.NewDirectory1
{
    public class Shop : IEnumerable<Product>
    {
        public string Name { get; set; }
        private IList<Product> products = new List<Product>();

        public Shop(string name)
        {
            Name = name;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void SortByPrice(bool ascending = true)
        {
            products = ascending
                ? products.OrderBy(p => p.Price).ToList()
                : products.OrderByDescending(p => p.Price).ToList();
        }

        public void SortByName(bool ascending = true)
        {
            products = ascending
                ? products.OrderBy(p => p.Name).ToList()
                : products.OrderByDescending(p => p.Name).ToList();
        }

        public override string ToString()
        {
            return $"Shop: {Name}";
        }

        public IEnumerator<Product> GetEnumerator() => products.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
