# Capsium.Foundation.Sensors.Sound.Ky038

**KY-038 analog sound sensor**

The **Ky038** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
Ky038 sensor;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    sensor = new Ky038(Device.Pins.A00, Device.Pins.D10);

    return Task.CompletedTask;
}

public override Task Run()
{
    return Task.CompletedTask;
}

```
