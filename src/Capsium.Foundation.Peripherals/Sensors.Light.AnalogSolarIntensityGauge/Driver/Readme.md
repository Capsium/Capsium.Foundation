# Capsium.Foundation.Sensors.Light.AnalogSolarIntensityGauge

**Analog solar intensity sensor**

The **AnalogSolarIntensityGauge** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
AnalogSolarIntensityGauge solarGauge;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    solarGauge = new AnalogSolarIntensityGauge(Device.Pins.A02, updateInterval: TimeSpan.FromSeconds(1));

    //==== classic .NET Event
    solarGauge.SolarIntensityUpdated += (s, result) => Resolver.Log.Info($"SolarIntensityUpdated: {result.New * 100:n2}%");

    //==== Filterable observer
    var observer = AnalogSolarIntensityGauge.CreateObserver(
        handler: result => Resolver.Log.Info($"Observer filter satisifed, new intensity: {result.New * 100:n2}%"),
        filter: result =>
        {
            if (result.Old is { } old)
            {
                return (Math.Abs(result.New - old) > 0.05); // only notify if change is > 5%
            }
            return false;
        });
    solarGauge.Subscribe(observer);

    return Task.CompletedTask;
}

public override async Task Run()
{
    var result = await solarGauge.Read();
    Resolver.Log.Info($"Solar Intensity: {result * 100:n2}%");

    solarGauge.StartUpdating(TimeSpan.FromSeconds(1));
}

```
