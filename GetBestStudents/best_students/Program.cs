using System;
using System.Text.Json;

namespace HelloWorld
{
    public class Person
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
    }

    class Program
    {
        static void Main(string[] args)
        {
            var item = new Person() { FirstName = "Foo", LastName = "Bar"};
            var serializedItem = JsonSerializer.Serialize(item);
            Console.WriteLine(serializedItem);
        }
    }
}