# Capsium.Foundation.Sensors.Hid.Tsc2004

**Tsc2004 I2C capacitive touch screen**

The **Tsc2004** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
Tsc2004 touchScreen;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    var i2cBus = Device.CreateI2cBus(I2cBusSpeed.Fast);

    touchScreen = new Tsc2004(i2cBus)
    {
        DisplayWidth = 240,
        DisplayHeight = 320,
        XMin = 260,
        XMax = 3803,
        YMin = 195,
        YMax = 3852,
        Rotation = RotationType._90Degrees
    };

    return Task.CompletedTask;
}

public override Task Run()
{
    return Task.Run(() =>
    {
        Point3d pt;

        while (true)
        {
            if (touchScreen.IsTouched())
            {
                pt = touchScreen.GetPoint();
                Resolver.Log.Info($"Location: X:{pt.X}, Y:{pt.Y}, Z:{pt.Z}");
            }

            Thread.Sleep(0);
        }
    });
}

```
