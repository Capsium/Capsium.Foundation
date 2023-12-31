# Capsium.Foundation.Sensors.Moisture.Capacitive

**Analog capacitive soil moisture sensor**

The **Capacitive** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
Capacitive capacitive;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    capacitive = new Capacitive(
        Device.Pins.A00,
        minimumVoltageCalibration: new Voltage(2.84f),
        maximumVoltageCalibration: new Voltage(1.63f)
    );

    // Example that uses an IObservable subscription to only be notified when the humidity changes by filter defined.
    var consumer = Capacitive.CreateObserver(
        handler: result =>
        {
            string oldValue = (result.Old is { } old) ? $"{old:n2}" : "n/a"; // C# 8 pattern matching
            Resolver.Log.Info($"Subscribed - " +
                $"new: {result.New}, " +
                $"old: {oldValue}");
        },
        filter: null
    );
    capacitive.Subscribe(consumer);

    // classical .NET events can also be used:
    capacitive.HumidityUpdated += (sender, result) =>
    {
        string oldValue = (result.Old is { } old) ? $"{old:n2}" : "n/a"; // C# 8 pattern matching
        Resolver.Log.Info($"Updated - New: {result.New}, Old: {oldValue}");
    };

    //==== One-off reading use case/pattern
    ReadSensor().Wait();

    capacitive.StartUpdating(TimeSpan.FromMilliseconds(1000));

    return Task.CompletedTask;
}

protected async Task ReadSensor()
{
    var humidity = await capacitive.Read();
    Resolver.Log.Info($"Initial humidity: {humidity:N2}C");
}

```
