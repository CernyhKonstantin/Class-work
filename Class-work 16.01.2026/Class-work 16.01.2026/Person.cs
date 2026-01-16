using System;

namespace FileSystem;

internal class Person
{
    private static int nextId = 1;

    public int Id { get; private set; }
    public string Name { get; set; }
    public short Age { get; set; }

    public Person()
    {
        Id = nextId++;
        Name = "default";
        Age = 0;
    }

    public Person(string name, short age)
    {
        Id = nextId++;
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"Id: {Id} | Name: {Name}, Age: {Age}";
    }

    public static void SetNextId(int id)
    {
        nextId = id;
    }
}
