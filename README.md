# BankSystemPOC
Requirement : "Using Clean Architecture with Domain-Driven Design (DDD), Command-Query Responsibility Segregation (CQRS), 
and event-driven architecture, how would you design a system for a bank that allows customers to check their account balance, 
transfer funds, and view transaction history. Please make use of unit testing and application testing."

Project Name : BankSystem
Database BackUp file : BankSystem.bak

Steps to run project:

- Restore backup DB.
- Load the project.
- Set connected string in appsettings.json file and set "DefaultConnection" key.
- Make 'Web' as the only startup project.
- Run the project.


Notes : 
- Currently, on register creating a new account and setting initial balance to 10,000.
- This is done so that we can transfer funds and test out those functionalities.


Project Setup: .NET Core 6
Architecture : Clean Architecture with Domain-Driven Design (DDD)
Approach : Command-Query Responsibility Segregation (CQRS)

Entities : Account, PaymentTransaction

Database : MS SQL Server
ORM : EFCore

Test : MSTest Project for Unit Testing


What more could have been done/improvements:
- Validations
- Need to improve application business logic to incorporate option to add Receiver Account and related functionalities.
- Transfer funds only if we have account number for receiver in our system as well.
- Event Driven approach using MediatR
- Encryption for security
