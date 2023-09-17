# Capsium.Foundation.ICs.FanControllers.Emc2101

**Emc2101 I2C fan controller and temperature monitor**

The **Emc2101** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
Emc2101 fanController;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    fanController = new Emc2101(i2cBus: Device.CreateI2cBus());

    return base.Initialize();
}

public override Task Run()
{
    Resolver.Log.Info("Run ...");

    return base.Run();
}

```
