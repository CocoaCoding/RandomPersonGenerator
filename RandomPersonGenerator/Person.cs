using System;
using System.Collections.Generic;

namespace Datamodel
{
    public class Person
    {
        public enum GenderEnum { Other, Male, Female }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public GenderEnum Gender { get; set; }
        public string Employer { get; set; }
        public List<Person> Childreen { get; set; }
        public Person Spouse { get; set; }

        private static DateTime _minBirthday;
        private static DateTime _maxBirthday;

        private static Random _random;

        private static List<string> _maleFirstNames;
        private static List<string> _femaleFirstNames;

        private static List<string> _lastNames;
        private static List<string> _employers;

        static Person()
        {
            _random = new Random(DateTime.Now.Millisecond);

            _maleFirstNames = new List<string>();
            _femaleFirstNames = new List<string>();
            _lastNames = new List<string>();
            _employers = new List<string>();

            _maleFirstNames.AddRange(new[] { "Ben", "Ken", "Michael", "Thomas", "Mike", "John", "Russel", "George", "Arnold" });
            _maleFirstNames.AddRange(new[] { "Bruce", "Steve", "Tom", "Bill", "Ted", "Peter", "David", "Reginald", "David" });
            _maleFirstNames.AddRange(new[] { "Peter", "Thomas", "Richard", "Paul", "Ian", "Martin", "Noel", "Adam" });

            _femaleFirstNames.AddRange(new[] { "Rose", "Billie", "Kenzie", "Jane", "Kagney", "May", "Gwen" });
            _femaleFirstNames.AddRange(new[] { "Linda", "Tracy", "Lena", "Katrina", "Samantha", "Suzi", "Nina" });
            _femaleFirstNames.AddRange(new[] { "Haruna", "Angelina", "Virginia", "Natasha", "Veronica", "Hana", "Jessica" });

            _lastNames.AddRange(new[] { "Swift", "Piper", "Steele", "Rogers", "Stark", "Hawkins", "Lee", "Kirby" });
            _lastNames.AddRange(new[] { "Cambell", "Hart", "Jordan", "Fielding", "Crispin", "Ford", "Jones" });
            _lastNames.AddRange(new[] { "Anderson", "Reeves", "Sagan", "Morgan", "Parker", "Watson" });
            _lastNames.AddRange(new[] { "Simpson", "King", "Abrams", "Suzuki", "Weller", "Summers" });

            _employers.AddRange(new[] { "ACME Inc.", "Big Kahuna", "Virtucon", "Cyberdyne Systems", "Duff Beer" });
            _employers.AddRange(new[] { "Bubba Gump", "Sterling Cooper", "Hooli", "Rainholm Industries", "Weyland Yutani" });
            _employers.AddRange(new[] { "Iron Bank of Braavos", "Los Pollos Hermanos", "Yoyodyne Propulsion Systems", "Wolfram & Hart" });

            _minBirthday = new DateTime(1960, 1, 1);
            _maxBirthday = new DateTime(2020, 12, 31);
        }

        public static Person GetRandomPerson()
        {
            int genderIndex = _random.Next(Enum.GetNames(typeof(GenderEnum)).Length - 1);
            int lastNameIndex = _random.Next(_lastNames.Count - 1);
            int employersIndex = _random.Next(_employers.Count - 1);

            Person person = new Person();
            person.Id = Guid.NewGuid();
            person.Gender = (GenderEnum)genderIndex;
            person.LastName = _lastNames[lastNameIndex];
            person.Employer = _employers[employersIndex];

            switch (person.Gender)
            {
                case GenderEnum.Male:
                    int indexM = _random.Next(_maleFirstNames.Count - 1);
                    person.FirstName = _maleFirstNames[indexM];
                    break;
                case GenderEnum.Female:
                    int indexF = _random.Next(_femaleFirstNames.Count - 1);
                    person.FirstName = _femaleFirstNames[indexF];
                    break;
                default:
                    List<string> allFirstName = new List<string>();
                    allFirstName.AddRange(_femaleFirstNames);
                    allFirstName.AddRange(_maleFirstNames);
                    int indexA = _random.Next(allFirstName.Count - 1);
                    person.FirstName = allFirstName[indexA];
                    break;
            }

            TimeSpan timeSpan = _maxBirthday - _minBirthday;
            TimeSpan newSpan = new TimeSpan(0, _random.Next(0, (int)timeSpan.TotalMinutes), 0);
            person.Birthday = _minBirthday + newSpan;

            return person;
        }
    }
}
