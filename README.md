# design-patterns-study

A very simple API project, built objectively with Mocks and a faster implementation.
In this project I practiced some concepts about the Design Patterns: Repository Pattern, Facade Pattern and Singleton Pattern.
I made some comments in the code indicating some actions and reasons why I made some decisions, the main objective of this project was to study and practice about Design Patterns, so validations and some good practices were not so relevant when I created this code.
The goal was to be simple enough to practice different concepts without having to work hard on parts that has no relation with the purpose of the project.

=====================================================================

- Singleton Pattern

A simple controller (SingletonController) that has three GET methods exactly the same, all three return an ID (Guid.NewGuid())

* The first method does not implement the Singleton Pattern, so every time we make the request the generated ID must be different, as it is instantiated every time.
* The second method implements the Singleton Pattern in a basic way, and every time we make a request it must return the same ID.
* The third method also implements the Singleton Pattern and works like the second one, but in this method using containers with dependency injection, with much cleaner code and best practices.

=====================================================================

- Repository Pattern

A simple controller with CRUD methods(PersonController): 'Create', 'Update', 'GetById', 'GetAll' and 'Delete'

The requests call the IPersonRepository abstraction, which makes a connection with the Infra layer where we have the PersonRepository class, which implements this abstraction and has the corresponding methods for each CRUD action and a Mock of the database.
The database Mock is a list of Persons, so the 'Create' method adds an element to the list, the 'Delete' method removes an element from the list, the 'Update' method changes the properties of the list elements by ID, the 'GetAll' method returns the complete list and the 'GetById' method returns a record of the list by Id.

=====================================================================

- Facade Pattern

A very simple controller(PersonActionsController) with just one PUT method which calls the PersonActions class, located in the Infra layer, sending the ID of a Person.
PersonActions is a class that has actions that a person can do, in this case we implement the DepositMoney method, which consists of a person making a deposit in their bank account, this class has the following responsibilities:

* Get the Person by Id on repository (using the repository and database mock created before).
* Create a DepositMoney, which is a model with customer (person) information and bank information for the deposit.
* Create an HttpClient to configure the request and the Mock API.
* Send a post to the External API (Mock API).

When a request is sent to the controller, the ID is obtained by param and passed to the PersonActions class, that is called by controller,
In the class PersonActions the Person is obtained through the repository (GetById), after that we need to create the DepositMoney(model) which is created with bank data and customer information(person),
after that, the HttpClient is created to configure the request and the information of the external API, finally the POST request is made to register the deposit in the external API.

If sucessful, you will be able to see the details of your deposit in the Mock API (https://632c58791aabd8373999e31d.mockapi.io/api/v1/bank/deposit)

=====================================================================
