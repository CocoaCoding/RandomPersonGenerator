using Datamodel;
using System.Collections.ObjectModel;

namespace PersonSimpleDatabindingSampleWPF
{

    public class MainWindowViewModel
    {
        public ObservableCollection<PersonViewModel> PersonVMs { get; set; }

        public MainWindowViewModel()
        {
            PersonVMs = new ObservableCollection<PersonViewModel>();
            PersonVMs.Add( new PersonViewModel(Person.GetRandomPerson()));
            PersonVMs.Add( new PersonViewModel(Person.GetRandomPerson()));
            PersonVMs.Add( new PersonViewModel(Person.GetRandomPerson()));
            PersonVMs.Add( new PersonViewModel(Person.GetRandomPerson()));
            PersonVMs.Add( new PersonViewModel(Person.GetRandomPerson()));
            PersonVMs.Add(new PersonViewModel(Person.GetRandomPerson()));
            PersonVMs.Add(new PersonViewModel(Person.GetRandomPerson()));
            PersonVMs.Add(new PersonViewModel(Person.GetRandomPerson()));
            PersonVMs.Add(new PersonViewModel(Person.GetRandomPerson()));            
        }
    }
}
