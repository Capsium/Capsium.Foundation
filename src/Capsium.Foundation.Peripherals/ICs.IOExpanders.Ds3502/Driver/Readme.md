# Capsium.Foundation.ICs.IOExpanders.Ds3502

**Ds3502 I2C digital potentiometer**

The **Ds3502** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
protected Ds3502 ds3502;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    ds3502 = new Ds3502(Device.CreateI2cBus(Ds3502.DefaultBusSpeed));

    return base.Initialize();
}

public override Task Run()
{
    for (byte i = 0; i < 127; i++)
    {
        ds3502.SetWiper(i);
        Resolver.Log.Info($"wiper {ds3502.GetWiper()}");

        Thread.Sleep(1000);
    }

    return base.Run();
}

```
