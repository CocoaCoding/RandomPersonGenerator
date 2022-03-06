using Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSimpleDatabindingSampleWPF
{
    public class PersonViewModel
    {
        private Person _person;

        public string FullName
        {
            get { return $"{_person.FirstName} {_person.LastName}"; }
        }

        public string Born
        {
            get { return $"Born {_person.Birthday:yyyy-MM-dd} in {_person.PlaceOfBirth}"; }
        }

        public string Gender
        {
            get
            {
                switch (_person.Gender)
                {
                    case Person.GenderEnum.Male:
                        return "Male";
                    case Person.GenderEnum.Female:
                        return "Female";
                    default:
                        return "Other";
                }
            }
        }

        public PersonViewModel(Person person)
        {
            _person = person;
        }
    }
}
