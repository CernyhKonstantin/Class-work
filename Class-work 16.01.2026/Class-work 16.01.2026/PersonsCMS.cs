using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace FileSystem;

internal class PersonsCMS
{
    public string PathToFile { get; private set; }

    public PersonsCMS(string path)
    {
        PathToFile = path;

        if (!File.Exists(PathToFile))
        {
            File.WriteAllText(PathToFile, "[]");
        }
        else
        {
            string json = File.ReadAllText(PathToFile);
            var people = JsonConvert.DeserializeObject<List<Person>>(json) ?? new List<Person>();

            int maxId = people.Count > 0 ? people.Max(p => p.Id) : 0;
            Person.SetNextId(maxId + 1);
        }
    }

    public void addPersonToFile(Person person)
    {
        string json = File.ReadAllText(PathToFile);
        List<Person> people = JsonConvert.DeserializeObject<List<Person>>(json) ?? new List<Person>();

        people.Add(person);

        string updatedJson = JsonConvert.SerializeObject(people, Formatting.Indented);
        File.WriteAllText(PathToFile, updatedJson);

        Console.WriteLine($"Person '{person.Name}' added successfully!");
    }

    public void showAllPersons()
    {
        string json = File.ReadAllText(PathToFile);
        List<Person> people = JsonConvert.DeserializeObject<List<Person>>(json) ?? new List<Person>();

        Console.WriteLine("All persons in file:");
        foreach (var p in people)
        {
            Console.WriteLine(p.ToString());
        }
    }

    public bool removePersonToFile(int id)
    {
        string json = File.ReadAllText(PathToFile);
        List<Person> people = JsonConvert.DeserializeObject<List<Person>>(json) ?? new List<Person>();

        Person personToRemove = people.Find(p => p.Id == id);

        if (personToRemove != null)
        {
            people.Remove(personToRemove);
            string updatedJson = JsonConvert.SerializeObject(people, Formatting.Indented);
            File.WriteAllText(PathToFile, updatedJson);

            Console.WriteLine($"Person with Id {id} removed successfully!");
            return true;
        }
        else
        {
            Console.WriteLine($"Person with Id {id} not found!");
            return false;
        }
    }
}
