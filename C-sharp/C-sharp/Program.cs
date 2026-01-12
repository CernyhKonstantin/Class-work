using System;

namespace Lesson_11.NewDirectory1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop("Tech Store");

            shop.AddProduct(new Product("Laptop", 1200));
            shop.AddProduct(new Product("Smartphone", 850));
            shop.AddProduct(new Product("Headphones", 150));
            shop.AddProduct(new Product("Monitor", 300));

            Console.WriteLine(shop);
            Console.WriteLine("\nProducts (original order):");
            foreach (Product p in shop)
                Console.WriteLine(p);

            shop.SortByPrice();
            Console.WriteLine("\nProducts sorted by price (ascending):");
            foreach (Product p in shop)
                Console.WriteLine(p);

            shop.SortByName(false);
            Console.WriteLine("\nProducts sorted by name (descending):");
            foreach (Product p in shop)
                Console.WriteLine(p);
        }
    }
}
