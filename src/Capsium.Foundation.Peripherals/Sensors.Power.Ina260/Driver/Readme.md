# Capsium.Foundation.Sensors.Power.Ina260

**INA260 I2C current and power monitor**

The **Ina260** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
Ina260 ina260;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    var bus = Device.CreateI2cBus();
    ina260 = new Ina260(bus);

    Resolver.Log.Info($"-- INA260 Sample App ---");
    Resolver.Log.Info($"Manufacturer: {ina260.ManufacturerID}");
    Resolver.Log.Info($"Die: {ina260.DieID}");
    ina260.Updated += (s, v) =>
    {
        Resolver.Log.Info($"{v.New.Item2}V @ {v.New.Item3}A");
    };

    return Task.CompletedTask;
}

public override Task Run()
{ 
    ina260.StartUpdating(TimeSpan.FromSeconds(2));
    return Task.CompletedTask;
}

```
