# Capsium.Foundation.Sensors.Light.Si1145

**SI1145 I2C ultraviolet and ambient light sensor**

The **Si1145** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
Si1145 sensor;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    sensor = new Si1145(Device.CreateI2cBus());

    // Example that uses an IObservable subscription to only be notified when the filter is satisfied
    var consumer = Si1145.CreateObserver(
        handler: result => Resolver.Log.Info($"Observer: filter satisifed: {result.New.VisibleLight?.Lux:N2}Lux, old: {result.Old?.VisibleLight?.Lux:N2}Lux"),
   
        // only notify if the visible light changes by 100 lux (put your hand over the sensor to trigger)
        filter: result => {
            if (result.Old is { } old) { //c# 8 pattern match syntax. checks for !null and assigns var.
                // returns true if > 100lux change
                return ((result.New.VisibleLight.Value - old.VisibleLight.Value).Abs().Lux > 100);
            }
            return false;
        });

    sensor.Subscribe(consumer);

    // classical .NET events can also be used:
    sensor.Updated += (sender, result) => {
        Resolver.Log.Info($" Visible Light: {result.New.VisibleLight?.Lux:N2}Lux");
        Resolver.Log.Info($" Infrared Light: {result.New.Infrared?.Lux:N2}Lux");
        Resolver.Log.Info($" UV Index: {result.New.UltravioletIndex:N2}Lux");
    };

    return Task.CompletedTask;
}

public override async Task Run()
{
    var (VisibleLight, UltravioletIndex, Infrared) = await sensor.Read();

    Resolver.Log.Info("Initial Readings:");
    Resolver.Log.Info($" Visible Light: {VisibleLight?.Lux:N2}Lux");
    Resolver.Log.Info($" Infrared Light: {Infrared?.Lux:N2}Lux");
    Resolver.Log.Info($" UV Index: {UltravioletIndex:N2}Lux");

    sensor.StartUpdating(TimeSpan.FromSeconds(1));
}

```
