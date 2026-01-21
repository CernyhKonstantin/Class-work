using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Developers
{
    class Developer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public List<string> Languages { get; set; } = new List<string>();

        public Developer(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }

        public override string ToString()
        {
            return $"{Name}, Age: {Age}, Country: {Country}, Languages: {string.Join(", ", Languages)}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Developer p1 = new Developer("Alex", 25, "Ukraine");
            Developer p2 = new Developer("Marie", 30, "France");
            Developer p3 = new Developer("John", 19, "USA");
            Developer p4 = new Developer("Oleg", 28, "Ukraine");
            Developer p5 = new Developer("Sophie", 22, "Germany");

            p1.Languages.AddRange(new[] { "C#", "Java", "SQL" });
            p2.Languages.AddRange(new[] { "Java", "Python" });
            p3.Languages.AddRange(new[] { "C++", "C#" });
            p4.Languages.AddRange(new[] { "Python", "JavaScript" });
            p5.Languages.AddRange(new[] { "C#", "Java" });

            List<Developer> developers = new List<Developer> { p1, p2, p3, p4, p5 };

            Console.WriteLine("1) Developers from Ukraine or France (LINQ query):");
            var result1Query = from d in developers
                               where d.Country == "Ukraine" || d.Country == "France"
                               select d;
            foreach (var dev in result1Query)
                Console.WriteLine(dev);

            Console.WriteLine("\n1) Developers from Ukraine or France (LINQ extension):");
            var result1Method = developers.Where(d => d.Country == "Ukraine" || d.Country == "France");
            foreach (var dev in result1Method)
                Console.WriteLine(dev);

            Console.WriteLine("\n2) Developers who know Java and C# (LINQ query):");
            var result2Query = from d in developers
                               where d.Languages.Contains("Java") && d.Languages.Contains("C#")
                               select d;
            foreach (var dev in result2Query)
                Console.WriteLine(dev);

            Console.WriteLine("\n2) Developers who know Java and C# (LINQ extension):");
            var result2Method = developers.Where(d => d.Languages.Contains("Java") && d.Languages.Contains("C#"));
            foreach (var dev in result2Method)
                Console.WriteLine(dev);

            Console.WriteLine("\n3) Developers who do NOT know C++ and are older than 20 (LINQ query):");
            var result3Query = from d in developers
                               where !d.Languages.Contains("C++") && d.Age > 20
                               select d;
            foreach (var dev in result3Query)
                Console.WriteLine(dev);

            Console.WriteLine("\n3) Developers who do NOT know C++ and are older than 20 (LINQ extension):");
            var result3Method = developers.Where(d => !d.Languages.Contains("C++") && d.Age > 20);
            foreach (var dev in result3Method)
                Console.WriteLine(dev);
        }
    }
}
