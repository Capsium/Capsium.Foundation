# Capsium.Foundation.Displays.Pcd8544

**PCD8544 SPI monochrome display (Nokia 5110)**

The **Pcd8544** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
MicroGraphics graphics;

public override Task Initialize()
{
    Resolver.Log.Info("Initializing...");

    var display = new Pcd8544
    (
        spiBus: Device.CreateSpiBus(),
        chipSelectPin: Device.Pins.D01,
        dcPin: Device.Pins.D00,
        resetPin: Device.Pins.D02
    );

    graphics = new MicroGraphics(display);

    return base.Initialize();
}

public override Task Run()
{
    graphics.Clear(true);
    graphics.CurrentFont = new Font8x12();
    graphics.DrawText(0, 0, "PCD8544");
    graphics.DrawRectangle(5, 14, 30, 10, true);

    graphics.Show();

    return base.Run();
}

```
