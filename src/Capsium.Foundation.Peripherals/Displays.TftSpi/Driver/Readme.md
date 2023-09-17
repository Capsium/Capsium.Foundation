# Capsium.Foundation.Displays.TftSpi

**SPI Color TFT and OLED displays (GC9A01, HC8357B, HX8357D, ILI9163, ILI9341, ILI9481, ILI9488, RM68140, S6D02A1, SSD1331, SSD1351, ST7735, ST7789)**

The **TftSpi** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
MicroGraphics graphics;

public override Task Initialize()
{
    Resolver.Log.Info("Initializing ...");

    var spiBus = Device.CreateSpiBus();

    Resolver.Log.Info("Create display driver instance");

    var display = new Gc9a01
    (
        spiBus: spiBus,
        chipSelectPin: Device.Pins.A02,
        dcPin: Device.Pins.D01,
        resetPin: Device.Pins.D00
    );

    graphics = new MicroGraphics(display)
    {
        IgnoreOutOfBoundsPixels = true,
        CurrentFont = new Font12x20(),
        Rotation = RotationType._180Degrees
    };

    return base.Initialize();
}

public override Task Run()
{
    graphics.Clear();
    graphics.DrawCircle(120, 120, 100, Capsium.Foundation.Color.Cyan, false);
    graphics.DrawRoundedRectangle(50, 50, 140, 140, 50, Capsium.Foundation.Color.BlueViolet, false);
    graphics.DrawText(120, 120, "Capsium F7", alignmentH: HorizontalAlignment.Center, alignmentV: VerticalAlignment.Center);
    graphics.Show();

    return base.Run();
}

```
