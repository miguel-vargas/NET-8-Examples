# Service Interface Example
We will take our DI a bit further by exploring interfaces, which are a more generic version of a
concrete class. These interfaces describe a contract that implementors will uphold, but they do not
describe exactly how it will achieve its logic.

## NOTES Sections Found in this Solution
* Startup.cs
* WeatherController.cs
* IWeatherService.cs
* WeatherService.cs

## Startup.cs
Here we register a service to the service collection by providing the service class to AddSingleton
along with its interface. This means that classes dependent on this service can simply request "Hey I
need a service that handles these types of requests" without knowing exactly which service it needs.

This helps us out in the future when we want to completely change the implementation of a service, but
do not want to break the existing service.

## WeatherController.cs
We have updated a consumer of the service to only request the interface. .NET will handle the rest since
it knows that a certain implementation of the interface has been registered to that interface.

## IWeatherService.cs
This is our interface file. By convention all interface files in .NET are prefixed with a capital `I`.
An interface describes what a class **will** implement, but it will **not** have the actual implementation.

## WeatherService.cs
We can now denote that the `WeatherService` **implements** the `IWeatherService` interface with the
following syntax: `class WeatherService : IWeatherService`. You can read that colon in the middle as 
implements or extends. In this case it mean implements as `IWeatherService` is an interface, but
sometimes it can mean that a class extends another class.

### Bonus: Extends
Lets say we had an `Animal` class that just had one property `string Name`. As our project evolves we
may find that we want to extend that class to accomodate for other properties that may not be shared
across **all** animals. So we can create a `Dog` class that **extends** `Animal` and has an additional
property `string BarkLoudness`. Now a dog can have a name and bark loudness since it extends Animal. It
inherited the `Name` property.

```
public class Animal
{
    public string Name { get; set; }
}

public class Dog : Animal
{
    public string BarkLoudness { get; set; }

    // Notice we can still use the Name property because we extend the parent class Animal.
    public string AboutMe()
    {
        return $"Hi my name is {Name} and my bark loudness lever is {BarkLoudness}"
    }
}
```

### Bonus: Interface
Keeping on with the `Animal` class example. Let's say we want all our animals to implement a sound. We
can create an `IAnimal` interface that looks something like this.
```
public interface IAnimal
{
    public string Sound();
}
```

Our `Dog` and `Cat` classes can implement the `IAnimal` interface and detail their own implementation of
the sound method.

```
public class Dog : IAnimal
{
    public string Sound()
    {
        return "Woof!";
    }
}

public class Cat : IAnimal
{
    public string Sound()
    {
        return "Meow";
    }
}
```