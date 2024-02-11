# Multi Project Example
We use multiple projects for a couple of reasons. We can keep the concerns of each project limited.

## MultiProjectExample
This project will serve as the MAIN project for our WebAPI solution. It will have all the services
it needs registered and any addons like Swagger. Other than that we will have the controller classes
and that's it. This keeps the "API" project clean and devs can clearly see the goals of the project.

## MultiProjectExample.Core
This project will hold the core logic of our application. This includes services, models, and interfaces.
Any infrastructure like databases or files on a computer can be exposed via these services in the future.

## (Theoretical) MultiProjectExample.Data
We can imagine another project that deals with anything related to databases. Typically in .NET we use ORMs
like Entity Framework Core (EF Core) or Dapper instead of running raw SQL queries.

## (Theoretical) MultiProjectExample.Console
We can imagine another project that is just a console app. Instead of an API project we can interact with
the services project (and Data project if we had one) to get our data to the console. This is helpful if we
want to demo a certain method or set of methods without spinning up an API.