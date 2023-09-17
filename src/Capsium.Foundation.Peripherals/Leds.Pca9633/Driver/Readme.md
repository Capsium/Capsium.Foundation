# Capsium.Foundation.Leds.Pca9633

**Pca9633 I2C RGB LED driver**

The **Pca9633** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
Pca9633 pca9633;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    pca9633 = new Pca9633(Device.CreateI2cBus());

    return base.Initialize();
}

public override Task Run()
{
    //set the location of R,G,B leds for color control
    pca9633.SetRgbLedPositions(redLed: Pca9633.LedPosition.Led2,
                              greenLed: Pca9633.LedPosition.Led1,
                              blueLed: Pca9633.LedPosition.Led0);

    //set a single color
    pca9633.SetColor(Color.Red);
    Thread.Sleep(1000);
    pca9633.SetColor(Color.Blue);
    Thread.Sleep(1000);
    pca9633.SetColor(Color.Yellow);

    return base.Run();
}

```
