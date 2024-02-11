# Service and Dependency Injection Example
A staple of .NET is being able to split our application into services and use them where necessary.
We register services to the service collection during startup and we use them, or **inject** them,
into classes that are dependent on them via their constructors.

This Dependency Injection (DI) looks almost entirely the same in Angular. This is almost certainly
because Microsoft developed TypeScript. In Angular you register providers in your app.module.ts, or
in newer version services are decorated with a

```
@Injectable({
    providedIn: 'root',
})
```

which automatically registers them.

## NOTES Sections Found in this Solution
* Startup.cs
* WeatherController.cs
* WeatherService.cs

## Startup.cs
Here we register a service to the service collection by providing the service class to AddSingleton.

There are other lifetime options for services apart from Singleton. These include Transient and Scoped.
There is no need to understand this concept right now and has been added purely for informational
purposes. Below is a TLDR found on Stack Overflow

> Transient objects are always different; a new instance is provided to every controller and every service.
> 
> Scoped objects are the same within a request, but different across different requests.
>
> Singleton objects are the same for every object and every request.

## WeatherController.cs
The controller's constructor now takes in the `WeatherService` as a parameter. .NET will see this and take
care of injecting the service into it. If the service is not registered to the service collection, then the
application will crash as it tries to create a `new WeatherController()`.

We can also see that our controller now contains very little logic. We have handed that responsibility off
to the service.

## WeatherService.cs
This service will have a method to handle each of the controller's request. The service can then do its
own operations to return a result. It can either hand it off to another service or directly execute logic.