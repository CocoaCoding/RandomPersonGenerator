using System;
using System.Collections.Generic;
using System.Diagnostics;

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
        public string PlaceOfBirth { get; set; }
        public List<Person> Children { get; set; }
        public Person Spouse { get; set; }

        private static DateTime _minBirthday;
        private static DateTime _maxBirthday;

        private static Random _random;

        public static List<string> _maleFirstNames;
        public static List<string> _femaleFirstNames;

        public static List<string> _lastNames;
        public static List<string> _placeOfBirth;

        private static double _chanceOfDoubleFirstNameInPercent;
        private static double _chanceOfDoubleLastNameInPercent;

        static Person()
        {
            _random = new Random(DateTime.Now.Millisecond);

            _maleFirstNames = new List<string>();
            _femaleFirstNames = new List<string>();
            _lastNames = new List<string>();
            _placeOfBirth = new List<string>();

            _maleFirstNames.AddRange(new[] { "Ben", "Ken", "Michael", "Thomas", "Mike", "John", "Russel", "George", "Arnold","Hans" });
            _maleFirstNames.AddRange(new[] { "Bruce", "Steve", "Tom", "Bill", "Ted", "Peter", "David", "Reginald", "Ronald", "Norman", "Ulrich" });
            _maleFirstNames.AddRange(new[] { "Pete", "Ricky", "Richard", "Paul", "Ian", "Martin", "Noel", "Adam", "Don", "Dan", "Fred" });
            _maleFirstNames.AddRange(new[] { "Jack", "Tobias", "Otto", "Kurt", "Wolfgang", "Andreas", "Josef", "Donald", "Frank", "Steven", "Adrian", "James" });
            _maleFirstNames.AddRange(new[] { "Eric", "Kenny", "Patrick", "Bret" ,"Isaac","Harry","Clark", "Barry", "Harald", "Boris", "Mario", "Luigi"});

            _femaleFirstNames.AddRange(new[] { "Rose", "Billie", "Kenzie", "Jane", "Kagney", "May", "Gwen", "Mary", "Rina" });
            _femaleFirstNames.AddRange(new[] { "Linda", "Tracy", "Lena", "Katrina", "Samantha", "Suzi", "Nina", "Brooke" });
            _femaleFirstNames.AddRange(new[] { "Haruna", "Angelina", "Virginia", "Natasha", "Veronica", "Hana", "Jessica" });
            _femaleFirstNames.AddRange(new[] { "Jill", "Sabrina", "Betty", "Anna", "Ute", "Angelika", "Natalie", "Eve", "Kelly", "Tia" });
            _femaleFirstNames.AddRange(new[] { "Allison", "Carrie", "Ivanka", "Sharon", "Mona", "Lucy", "Anny", "Pia", "Isabella", "Sara" });
            _femaleFirstNames.AddRange(new[] { "Pamela", "Beverly", "Madison" ,"Carmen", "Nicole","Joy", "Yaprak","Mio" });

            _lastNames.AddRange(new[] { "Swift", "Piper", "Steele", "Rogers", "Stark", "Hawkins", "Lee", "Kirby" });
            _lastNames.AddRange(new[] { "Cambell", "Hart", "Jordan", "Fielding", "Crispin", "Ford", "Jones" ,"Osborn", "Stane" });
            _lastNames.AddRange(new[] { "Anderson", "Reeves", "Sagan", "Morgan", "Parker", "Watson", "Schmidt" });
            _lastNames.AddRange(new[] { "Simpson", "King", "Abrams", "Suzuki", "Weller", "Summers", "Larson", "Rex" });
            _lastNames.AddRange(new[] { "Petty", "Bowie", "Gabriel", "Mueller", "Collins", "Rutherford", "Karter", "Olson", "Hanks" });
            _lastNames.AddRange(new[] { "Bogenhard", "Wayne", "Lane","Newton", "Lesch", "Fielding", "Allen" });
            _lastNames.AddRange(new[] { "Ewing", "Barns", "Knight","Miles", "Carrington", "Reynolds", "Ono" });
            _lastNames.AddRange(new[] { "Jackson", "Siegel", "Mills","Stacy", "Fischer", "Azuklu", "Pangborn" });

            _placeOfBirth.AddRange(new[] { "Berlin", "Paris", "Tokyo", "Oslo", "New York", "Denver", "Anchorage", "Taipeh" });
            _placeOfBirth.AddRange(new[] { "Saitama", "Valencia", "Tunis", "Catania", "Kairo", "Port Elizabeth", "Hiroshima" });
            _placeOfBirth.AddRange(new[] { "Dallas", "Vancouver", "Brasília", "Minsk", "Heidelberg", "Istanbul", "Dublin" });
            _placeOfBirth.AddRange(new[] { "Glasgow", "Amsterdam", "Rom", "Sarajevo", "Damaskus", "Dubai", "Colombo" });
            _placeOfBirth.AddRange(new[] { "Oberhausen", "Birmingham", "Liverpool", "Lyon", "Ankara", "Seoul", "Honolulu" });
            _placeOfBirth.AddRange(new[] { "Antwerpen", "Houston", "Milano", "Hannover", "Beirut", "Bagdad", "Athens", "Tehran" });

            _minBirthday = new DateTime(1960, 1, 1);
            _maxBirthday = new DateTime(2020, 12, 31);

            _chanceOfDoubleFirstNameInPercent = 5;
            _chanceOfDoubleLastNameInPercent = 5;

            CheckForDuplicates();
        }

        private static void CheckForDuplicates()
        {
            HashSet<string> testingHash = new HashSet<string>();
            foreach (var firstname in _maleFirstNames)
            {
                Debug.Assert(!testingHash.Contains(firstname), $"{firstname} duplicate");
                testingHash.Add(firstname);
            }
            testingHash.Clear();
            foreach (var firstname in _femaleFirstNames)
            {
                Debug.Assert(!testingHash.Contains(firstname), $"{firstname} duplicate");
                testingHash.Add(firstname);
            }
            testingHash.Clear();
            foreach (var place in _placeOfBirth)
            {
                Debug.Assert(!testingHash.Contains(place), $"{place} duplicate");
                testingHash.Add(place);
            }
        }

        public static Person GetRandomPerson()
        {
            int genderIndex = _random.Next(Enum.GetNames(typeof(GenderEnum)).Length);
            int placeOfBirthIndex = _random.Next(_placeOfBirth.Count - 1);

            Person person = new Person();
            person.Id = Guid.NewGuid();
            person.Gender = (GenderEnum)genderIndex;
            person.FirstName = GetRandomFirstName(person.Gender);
            person.LastName = GetRandomLastName();
            person.PlaceOfBirth = _placeOfBirth[placeOfBirthIndex];

            TimeSpan timeSpan = _maxBirthday - _minBirthday;
            TimeSpan newSpan = new TimeSpan(0, _random.Next(0, (int)timeSpan.TotalMinutes), 0);
            person.Birthday = _minBirthday + newSpan;

            return person;
        }

        private static string GetRandomLastName()
        {
            string lastName = string.Empty;
            bool hasDoubleLastName = _random.Next(100) <=  _chanceOfDoubleLastNameInPercent;
            int index = _random.Next(_lastNames.Count - 1);
            lastName = $"{_lastNames[index]}";
            if (hasDoubleLastName)
            {
                index = _random.Next(_lastNames.Count - 1);
                lastName = $"{lastName}-{_lastNames[index]}";
            }

            return lastName;
        }


        private static string GetRandomFirstName(GenderEnum gender)
        {
            int index = 0;
            string firstName = string.Empty;
            bool hasDoubleFirstName = _random.Next(100) <= _chanceOfDoubleFirstNameInPercent;

            switch (gender)
            {
                case GenderEnum.Male:
                    index = _random.Next(_maleFirstNames.Count - 1);
                    firstName = $"{_maleFirstNames[index]}";
                    if (hasDoubleFirstName)
                    {
                        index = _random.Next(_maleFirstNames.Count - 1);
                        firstName = $"{firstName}-{_maleFirstNames[index]}" ; 
                    }
                    break;
                case GenderEnum.Female:
                    index = _random.Next(_femaleFirstNames.Count - 1);
                    firstName = $"{_femaleFirstNames[index]}";
                    if (hasDoubleFirstName)
                    {
                        index = _random.Next(_femaleFirstNames.Count - 1);
                        firstName = $"{firstName}-{_femaleFirstNames[index]}";
                    }
                    break;
                default:
                    List<string> allFirstName = new List<string>();
                    allFirstName.AddRange(_femaleFirstNames);
                    allFirstName.AddRange(_maleFirstNames);

                    index = _random.Next(allFirstName.Count - 1);
                    firstName = $"{allFirstName[index]}";
                    if (hasDoubleFirstName)
                    {
                        index = _random.Next(allFirstName.Count - 1);
                        firstName = $"{firstName}-{allFirstName[index]}";
                    }
                    break;
            }
            return firstName;
        }
    }
}
