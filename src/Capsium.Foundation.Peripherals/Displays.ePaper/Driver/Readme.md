# Capsium.Foundation.Displays.ePaper

**SPI eInk / ePaper display controllers (IL0373, IL0376F, IL0398, IL3897, IL91874, ILI91874v3, SSD1608)**

The **EPaper** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
MicroGraphics graphics;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize ...");

    var display = new Il0373(
        spiBus: Device.CreateSpiBus(),
        chipSelectPin: Device.Pins.D03,
        dcPin: Device.Pins.D02,
        resetPin: Device.Pins.D01,
        busyPin: Device.Pins.D00,
        width: 400,
        height: 300);

    graphics = new MicroGraphics(display);

    return Task.CompletedTask;
}

public override Task Run()
{
    //any color but black will show the ePaper alternate color 
    graphics.DrawRectangle(1, 1, 126, 32, Capsium.Foundation.Color.Black, false);

    graphics.CurrentFont = new Font12x16();
    graphics.DrawText(2, 2, "IL0373", Capsium.Foundation.Color.Black);
    graphics.DrawText(2, 30, "Capsium F7", Capsium.Foundation.Color.Black);

    graphics.Show();

    return Task.CompletedTask;
}

```
