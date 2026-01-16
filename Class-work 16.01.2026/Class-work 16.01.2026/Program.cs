using System;

namespace FileSystem;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = "people.json";
        PersonsCMS cms = new PersonsCMS(path);

        Person p1 = new Person("Alex", 25);
        Person p2 = new Person("Maria", 30);
        Person p3 = new Person("John", 40);

        cms.addPersonToFile(p1);
        cms.addPersonToFile(p2);
        cms.addPersonToFile(p3);

        Console.WriteLine("====================");
        cms.showAllPersons();

        Console.WriteLine("====================");
        cms.removePersonToFile(2);

        Console.WriteLine("====================");
        cms.showAllPersons();

        Console.ReadKey();
    }
}
