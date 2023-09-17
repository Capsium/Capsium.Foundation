# Capsium.Foundation.Displays.ePaperWaveShare

**WaveShare SPI eInk / ePaper display controllers**

The **ePaperWaveShare** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
MicroGraphics graphics;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize ...");

    var display = new Epd5in65f(
            spiBus: Device.CreateSpiBus(),
            chipSelectPin: Device.Pins.A04,
            dcPin: Device.Pins.A03,
            resetPin: Device.Pins.A02,
            busyPin: Device.Pins.A01);

    graphics = new MicroGraphics(display);

    return Task.CompletedTask;
}

public override Task Run()
{
    Resolver.Log.Info("Run");

    graphics.Clear();

    graphics.CurrentFont = new Font12x16();
    graphics.DrawText(0, 0, "Capsium F7", Color.Black, scaleFactor: ScaleFactor.X2);
    graphics.DrawText(0, 50, "Green", Color.Green, scaleFactor: ScaleFactor.X2);
    graphics.DrawText(0, 100, "Yellow", Color.Yellow, scaleFactor: ScaleFactor.X2);
    graphics.DrawText(0, 150, "Orange", Color.Orange, scaleFactor: ScaleFactor.X2);
    graphics.DrawText(0, 200, "Red", Color.Red, scaleFactor: ScaleFactor.X2);
    graphics.DrawText(0, 250, "Blue", Color.Blue, scaleFactor: ScaleFactor.X2);

    graphics.Show();

    Resolver.Log.Info("Run complete");

    return Task.CompletedTask;
}

```
