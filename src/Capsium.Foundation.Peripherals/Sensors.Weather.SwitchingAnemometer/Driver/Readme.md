# Capsium.Foundation.Sensors.Weather.SwitchingAnemometer

**Digital Switching Anemometer wind speed sensor**

The **SwitchingAnemometer** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
SwitchingAnemometer anemometer;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    anemometer = new SwitchingAnemometer(Device.Pins.A01);

    //==== classic events example
    anemometer.WindSpeedUpdated += (sender, result) =>
    {
        Resolver.Log.Info($"new speed: {result.New.KilometersPerHour:n1}kmh, old: {result.Old?.KilometersPerHour:n1}kmh");
    };

    //==== IObservable example
    var observer = SwitchingAnemometer.CreateObserver(
        handler: result =>
        {
            Resolver.Log.Info($"new speed (from observer): {result.New.KilometersPerHour:n1}kmh, old: {result.Old?.KilometersPerHour:n1}kmh");
        },
        null
        );
    anemometer.Subscribe(observer);

    return Task.CompletedTask;
}

public override Task Run()
{
    // start raising updates
    anemometer.StartUpdating();
    Resolver.Log.Info("Hardware initialized.");

    return Task.CompletedTask;
}

```
