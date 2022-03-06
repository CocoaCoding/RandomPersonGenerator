using Datamodel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTreeViewDatabindingSampleWPF
{
    public class MainWindowViewModel
    {

        public ObservableCollection<PersonTreeViewModel> Children { get; set; }

        public MainWindowViewModel()
        {
            Children = new ObservableCollection<PersonTreeViewModel>();

            // First Root Person
            PersonTreeViewModel rootPersionVM = new PersonTreeViewModel(Person.GetRandomPerson());
            this.Children.Add(rootPersionVM);

            PersonTreeViewModel personVM1 = new PersonTreeViewModel(Person.GetRandomPerson());
            PersonTreeViewModel personVM2 = new PersonTreeViewModel(Person.GetRandomPerson());
            rootPersionVM.Children = new ObservableCollection<PersonTreeViewModel>();
            rootPersionVM.Children.Add(personVM1);
            rootPersionVM.Children.Add(personVM2);

            PersonTreeViewModel personVM3 = new PersonTreeViewModel(Person.GetRandomPerson());
            PersonTreeViewModel personVM4 = new PersonTreeViewModel(Person.GetRandomPerson());
            personVM1.Children = new ObservableCollection<PersonTreeViewModel>();
            personVM1.Children.Add(personVM3);
            personVM1.Children.Add(personVM4);

            PersonTreeViewModel personVM5= new PersonTreeViewModel(Person.GetRandomPerson());
            personVM2.Children = new ObservableCollection<PersonTreeViewModel>();
            personVM2.Children.Add(personVM5);

            PersonTreeViewModel personVM6 = new PersonTreeViewModel(Person.GetRandomPerson());
            personVM5.Children = new ObservableCollection<PersonTreeViewModel>();
            personVM5.Children.Add(personVM6);

            // Second Root Person
            PersonTreeViewModel rootPersionVM2 = new PersonTreeViewModel(Person.GetRandomPerson());
            this.Children.Add(rootPersionVM2);

            PersonTreeViewModel personVM7 = new PersonTreeViewModel(Person.GetRandomPerson());
            rootPersionVM2.Children = new ObservableCollection<PersonTreeViewModel>();
            rootPersionVM2.Children.Add(personVM7);

            PersonTreeViewModel personVM8 = new PersonTreeViewModel(Person.GetRandomPerson());
            personVM7.Children = new ObservableCollection<PersonTreeViewModel>();
            personVM7.Children.Add(personVM8);
        }
    }
}
