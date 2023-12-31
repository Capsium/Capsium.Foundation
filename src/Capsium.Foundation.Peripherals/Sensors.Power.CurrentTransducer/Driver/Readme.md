# Capsium.Foundation.Sensors.Power.CurrentTransducer

**Current transducer library**

The **CurrentTransducer** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
private CurrentTransducer transducer = default!;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    var bus = Device.CreateI2cBus();
    transducer = new CurrentTransducer(
        Device.Pins.A00.CreateAnalogInputPort(1),
        new Voltage(3.3, Voltage.UnitType.Volts), // a reading of 3.3V
        new Current(10, Current.UnitType.Amps)    // equals 10 amps of current
        );

    Resolver.Log.Info($"-- Current Transducer Sample App ---");
    transducer.Updated += (s, v) =>
    {
        Resolver.Log.Info($"Current is now {v.New.Amps}A");
    };

    return Task.CompletedTask;
}

public override Task Run()
{
    transducer.StartUpdating(TimeSpan.FromSeconds(2));
    return Task.CompletedTask;
}

```
