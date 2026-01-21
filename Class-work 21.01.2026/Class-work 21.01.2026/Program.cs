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
        public double Salary { get; set; }

        public Developer(string name, int age, string country, double salary)
        {
            Name = name;
            Age = age;
            Country = country;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"{Name}, Age: {Age}, Country: {Country}, Salary: {Salary:C}, Languages: {string.Join(", ", Languages)}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Developer p1 = new Developer("Alex", 25, "Ukraine", 4500);
            Developer p2 = new Developer("Marie", 30, "France", 5200);
            Developer p3 = new Developer("John", 19, "USA", 3800);
            Developer p4 = new Developer("Oleg", 28, "Ukraine", 4700);
            Developer p5 = new Developer("Sophie", 22, "Germany", 4000);

            p1.Languages.AddRange(new[] { "C#", "Java", "SQL" });
            p2.Languages.AddRange(new[] { "Java", "Python" });
            p3.Languages.AddRange(new[] { "C++", "C#" });
            p4.Languages.AddRange(new[] { "Python", "JavaScript" });
            p5.Languages.AddRange(new[] { "C#", "Java" });

            List<Developer> developers = new List<Developer> { p1, p2, p3, p4, p5 };

            Console.WriteLine("1) Developers from Ukraine or France (LINQ query):");
            var query1 = from d in developers
                         where d.Country == "Ukraine" || d.Country == "France"
                         select d;
            foreach (var dev in query1) Console.WriteLine(dev);

            Console.WriteLine("\n1) Developers from Ukraine or France (LINQ extension):");
            var method1 = developers.Where(d => d.Country == "Ukraine" || d.Country == "France");
            foreach (var dev in method1) Console.WriteLine(dev);

            Console.WriteLine("\n2) Developers who know Java and C# (LINQ query):");
            var query2 = from d in developers
                         where d.Languages.Contains("Java") && d.Languages.Contains("C#")
                         select d;
            foreach (var dev in query2) Console.WriteLine(dev);

            Console.WriteLine("\n2) Developers who know Java and C# (LINQ extension):");
            var method2 = developers.Where(d => d.Languages.Contains("Java") && d.Languages.Contains("C#"));
            foreach (var dev in method2) Console.WriteLine(dev);

            Console.WriteLine("\n3) Developers who do NOT know C++ and are older than 20 (LINQ query):");
            var query3 = from d in developers
                         where !d.Languages.Contains("C++") && d.Age > 20
                         select d;
            foreach (var dev in query3) Console.WriteLine(dev);

            Console.WriteLine("\n3) Developers who do NOT know C++ and are older than 20 (LINQ extension):");
            var method3 = developers.Where(d => !d.Languages.Contains("C++") && d.Age > 20);
            foreach (var dev in method3) Console.WriteLine(dev);

            Console.WriteLine("\n4) Developers sorted by Age descending (LINQ query):");
            var query4 = from d in developers
                         orderby d.Age descending
                         select d;
            foreach (var dev in query4) Console.WriteLine(dev);

            Console.WriteLine("\n4) Developers sorted by Age descending (LINQ extension):");
            var method4 = developers.OrderByDescending(d => d.Age);
            foreach (var dev in method4) Console.WriteLine(dev);

            int countCSharpQuery = (from d in developers
                                    where d.Languages.Contains("C#")
                                    select d).Count();
            Console.WriteLine($"\n5) Number of developers who know C# (LINQ query): {countCSharpQuery}");

            int countCSharpMethod = developers.Count(d => d.Languages.Contains("C#"));
            Console.WriteLine($"5) Number of developers who know C# (LINQ extension): {countCSharpMethod}");

            double avgSalaryQuery = (from d in developers select d.Salary).Average();
            Console.WriteLine($"\n6) Average salary (LINQ query): {avgSalaryQuery:C}");

            double avgSalaryMethod = developers.Average(d => d.Salary);
            Console.WriteLine($"6) Average salary (LINQ extension): {avgSalaryMethod:C}");
        }
    }
}
