using Datamodel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPFToolkit;

namespace PersonSimpleDatabindingSampleWPF
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<PersonViewModel> PersonVMs { get; set; }
        public PersonViewModel SelectedPersonVM { get; set; }

        public bool CanExecuteAddPerson => true; // always

        private ICommand _addPersonCommand;
        public ICommand AddPersonCommand => _addPersonCommand ?? (_addPersonCommand = new CommandHandler(AddPersonAction, () => CanExecuteAddPerson));

        public bool CanExecuteRemovePerson => SelectedPersonVM != null;

        private ICommand _removePersonCommand;
        public ICommand RemovePersonCommand => _removePersonCommand ?? (_removePersonCommand = new CommandHandler(RemovePersonAction, () => CanExecuteRemovePerson));


        public MainWindowViewModel()
        {
            PersonVMs = new ObservableCollection<PersonViewModel>();
            PersonVMs.Add(new PersonViewModel(Person.GetRandomPerson()));
            PersonVMs.Add(new PersonViewModel(Person.GetRandomPerson()));
            PersonVMs.Add(new PersonViewModel(Person.GetRandomPerson()));
            PersonVMs.Add(new PersonViewModel(Person.GetRandomPerson()));
            PersonVMs.Add(new PersonViewModel(Person.GetRandomPerson()));
            PersonVMs.Add(new PersonViewModel(Person.GetRandomPerson()));
            PersonVMs.Add(new PersonViewModel(Person.GetRandomPerson()));
            PersonVMs.Add(new PersonViewModel(Person.GetRandomPerson()));
            PersonVMs.Add(new PersonViewModel(Person.GetRandomPerson()));
        }

        public void AddPersonAction()
        {
            PersonVMs.Insert(0, new PersonViewModel(Person.GetRandomPerson()));
        }

        public void RemovePersonAction()
        {
            PersonVMs.Remove(this.SelectedPersonVM);
        }
    }
}
