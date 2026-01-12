using System;

namespace Lesson_11.NewDirectory1
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"ID: {Id} | Name: {Name} | Price: {Price}";
        }
    }
}
