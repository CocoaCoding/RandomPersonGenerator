# Random Person Generator
A Person class for C# with the ability to automatically generate sample data.

![alt text](https://github.com/hinzberg/RandomPersonGenerator/blob/master/person_generator_product.jpg "Random Person Generator")

#### Introduction

A person is always a good example for a class in software development. A person has properties in different types, (like name and age) and can have a list of his own type as children. 
In addition, one can derive or inherit from them. A person can be a player in a sports club. Or an employee in a company.
All in all, a perfect sample for learning the basics of Object Oriented Software Development.
And very useful when you need sample data for a project.

Creating instances of a person class and then filling them with content is a tedious task. 
If a program requires a lot of persons, this can quickly lead to many lines of program code. 
Therefore, a class that can automatically create instances that are already filled with random data would be ideal.

Unfortunately, it is not easy for a program to generate names that do not consist of a random arrangement of letters. 
This class therefore contains arrays of first names and last names from which entries are randomly selected. 
It limits the possible names, but the arrays can be extended at any time and with little effort.
The generation of a random date of birth is somewhat more complex. 
A TimeInterval is formed from two dates and then a random value is determined from this range.

#### Properties

* Id // A Guid
* FirstName // string
* LastName // string
* Birthday // DateTime
* Gender // GenderEnum 
* PlaceOfBirth // string
* Children // A list of Persons, Kids these days ...
* Spouse // A Person, the significant other 

#### Updates

##### 2022-03-06
* CommonResources project added for shared resources
* ListBox sample project renamed
* TreeView Sample completed

##### 2022-02-07
* ListBox Sample added with CommandBindings (Add + Remove)
* ListBox Sample added Style Dictionary
* TreeView Sample Datamodel

##### 2022-02-06
* Bugfix random gender genration
* ListBox Sample with Datatemplate and ViewModel

##### 2022-02-01
* Added additional names and places of birth
* Added change for double first name and double last name
* Added testing for duplicate entries
* Added subproject "PersonSimpleDatabindingSampleWPF"
* Added subproject "PersonTreeViewDatabindingSampleWPF"
