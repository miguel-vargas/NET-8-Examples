# Top Level Statements Example
Starting with .NET 6 we can have a singular **Main** file per project. Instead of all the hoopla of
namespace, class, and main method we can simply write the logic in a flat file. This allows us to have
a much smaller main program file.

## BONUS: File Scoped Namespaces
Starting with C# 10 (associated with .NET 6) we can declare namespaces right above our class and skip the
brackets that surrond the entire class. This saves us from having brackets around it all and we no longer
have to indent the majority of the file just to conform to the old standard.

## NOTES Sections Found in this Solution
* Program.cs
* Startup.cs
* WeatherController.cs

## Program.cs
Our file that uses the top level statements feature does not need to declare a namespace for itself. If
it is using other namespaces to import classes they must be done at the top before any logic takes place.

## Startup.cs
An example of File Scoped namespaces can be seen here. We no longer have to surround the entire class
with brackets and the class as a whole does not need to be indented.

## WeatherController.cs
An example of tradition namespaces can be seen here. The entire class is surrounded by brackets and we
have to indent all of the class.