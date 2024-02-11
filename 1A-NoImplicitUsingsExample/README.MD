# No Implicit Usings Example
This is a quick look at the impact of removing/disabling the ImplicitUsings flag in our csproj file. The flag was
added for us to use starting with C# 10 (which is associated with .NET 6). Enabling the flag adds commonly used
namespaces to our files by default. It chooses which ones to bring in by analyzing the project it is enabled in.

In this project we have removed the flag which means we have to explicitly add namespaces we use in our files.
**using System;** along with a lot of other **System** namespaces. This clouds up our files and in large
projects/files it can mean our first 50 lines are **using** statements. Some IDEs like Rider do us a favor by
hiding these until you click on the first using (ghosted gray text). Regardless, why not simplify our lives and
add less repetitive code to each of our files.

## NOTES Sections Found in this Solution
* NoImplicitUsingsExample.csproj
* WeatherController.cs

## WeatherController.csproj
Here we have omitted the ImplicitUsings flag.

## WeatherController.cs
Our first glimpse at what removing the flag can cause at the top of all of our files. If you compare it to the
first example project we go from 5 usings to 2 usings just by enabling the flag.