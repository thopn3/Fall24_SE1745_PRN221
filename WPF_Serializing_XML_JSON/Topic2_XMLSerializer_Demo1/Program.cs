using System.IO;
using System.Xml.Serialization;

[XmlRoot("Candidate")]
public class Person
{
    [XmlElement("FirstName")]
    public string Name { get; set; }
    [XmlElement("RoughAge")]
    public int Age { get; set; }
}

class Program
{
    public static void Main(string[] args)
    {
        Person p = new Person { Name="David", Age=20 };

        var xs = new XmlSerializer(typeof(Person));
        // Serialize
        using Stream s = File.Create("person.xml");
        xs.Serialize(s, p);
        s.Close();

        // Deserialize
        using Stream s1 = File.OpenRead("person.xml");
        var p1 = xs.Deserialize(s1) as Person;

        Console.WriteLine("--- Person Information ---");
        Console.WriteLine($"Name: {p1.Name}; Age: {p1.Age}");

        Console.WriteLine("--- person.xml ---");
        string xmlData = File.ReadAllText("person.xml");
        Console.WriteLine(xmlData);
        s1.Close();
        Console.ReadLine();
    }
}