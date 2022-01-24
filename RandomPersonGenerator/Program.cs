using Datamodel;
using System;

namespace RandomPersonGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 20; i++)
            {
                Person person = Person.GetRandomPerson();
                Console.WriteLine($"{person.FirstName} {person.LastName}, born {person.Birthday.ToShortDateString() } in {person.PlaceOfBirth}");
            }

            Console.ReadLine();
        }
    }
}
