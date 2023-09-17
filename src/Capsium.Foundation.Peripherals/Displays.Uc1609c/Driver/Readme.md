# Capsium.Foundation.Displays.Uc1609c

**Uc1609c SPI monochrome OLED display**

The **Uc1609c** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
MicroGraphics graphics;

public override Task Initialize()
{
    Resolver.Log.Info("Initializing...");

    var uc1609c = new Uc1609c
    (
        spiBus: Device.CreateSpiBus(),
        chipSelectPin: Device.Pins.A03,
        dcPin: Device.Pins.A04,
        resetPin: Device.Pins.A05,
        width: 192,
        height: 64
    );

    graphics = new MicroGraphics(uc1609c)
    {
        CurrentFont = new Font8x8()
    };

    return base.Initialize();
}

public override Task Run()
{
    graphics.Clear();
    graphics.DrawTriangle(10, 10, 50, 50, 10, 50, false);
    graphics.DrawRectangle(20, 15, 40, 20, true);
    graphics.DrawText(5, 5, "UC1609C");
    graphics.DrawCircle(96, 32, 16);
    graphics.Show();

    Resolver.Log.Info("Run complete");

    return base.Run();
}

```
