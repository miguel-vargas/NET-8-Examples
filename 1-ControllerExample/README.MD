# Controller Example
In this project we will take the scaffolded .NET 8 WebAPI project and change it to be a more traditional .NET
WebAPI project. The scaffolded projects are fine they just now default to a new way of doing things - Minimal API.
Coming from NodeJS it is very similar in the way API routes are declared. It is currently way more common to find
WebAPIs created in the traditional style of using Controllers.

## NOTES Sections Found in this Solution
* ControllerExample.csproj
* Program.cs
* WeatherController.cs
* WeatherForecast.cs

## ControllerExample.csproj
.csproj files describe our project, its target framework, and any package or project references.

## Program.cs
Program.cs is the main code that runs at the beginning of execution. Think of it like main.js or app.js in Node
projects. The notes here detail that we add controllers to our application as well as tell the app to map them.

## WeatherController.cs
This is the controller that will hold our routes for the API. Our GETs, POSTs, PUTs, DELETEs, etc. There is a lot
of "magic" in .NET that wires things up for us. Attributes are heavily used in controllers and can be easily
identified by Square Brackets []. Some attributes are simple and tell .NET that something is "this attribute" such
as [ApiController] denoting the WeatherController class is a .NET ApiController. More information about the 
[ApiController] attribute can be found in the official docs
[here](https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-8.0#apicontroller-attribute)