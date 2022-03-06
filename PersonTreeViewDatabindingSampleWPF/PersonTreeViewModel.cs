using Datamodel;
using PersonSimpleDatabindingSampleWPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTreeViewDatabindingSampleWPF
{
    public class PersonTreeViewModel : PersonViewModel
    {
        public ObservableCollection<PersonTreeViewModel> Children { get; set; }

        public PersonTreeViewModel(Person person) : base(person)
        {
        }
    }
}
