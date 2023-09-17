# Capsium.Foundation.Sensors.Weather.SwitchingRainGauge

**GPIO rain gauge sensor**

The **RainGauge** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
SwitchingRainGauge rainGauge;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    // initialize the rain gauge driver
    rainGauge = new SwitchingRainGauge(Device.Pins.D14);

    //==== Classic event example:
    rainGauge.Updated += (sender, result) => Resolver.Log.Info($"Updated event {result.New.Millimeters}mm");

    //==== IObservable Pattern
    var observer = SwitchingRainGauge.CreateObserver(
        handler: result => Resolver.Log.Info($"Rain depth: {result.New.Millimeters}mm"),
        filter: null
    );
    rainGauge.Subscribe(observer);

    return Task.CompletedTask;
}

public override async Task Run()
{
    // get initial reading, just to test the API - should be 0
    Length rainFall = await rainGauge.Read();
    Resolver.Log.Info($"Initial depth: {rainFall.Millimeters}mm");

    // start the sensor
    rainGauge.StartUpdating();
}

```
