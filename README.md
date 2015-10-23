# Traceo
Trace proxy to switch easily between Raygun / Xamarin Insights.

## Install

1. Reference Traceo.dll
2. Reference Traceo.*platform*.Raygun.dll to use raygun, or Traceo.*platform*.XamarinInsights.dll

## Usage

1. Resolve ITracerProxy using your favorite dependency injection library, or instanciate the Traceo class.
2. Assign the tracing implementation

###Setup

```c#
var tracerProxy = new Traceo();
tracerProxy.SetTracer(new Tracer());
tracerProxy.Init( /* your api key here */);
```

###Report an exception

```c#
tracerProxy.Report(exception);
```

###Assign traits to an user

```c#
tracerProxy.IdentifyUser(/* user unique id */);
```
