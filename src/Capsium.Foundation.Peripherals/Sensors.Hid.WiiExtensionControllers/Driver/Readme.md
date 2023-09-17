# Capsium.Foundation.Sensors.Hid.WiiExtensionControllers

**Nintendo Wii I2C extension controllers (nunchuck, classic controller, snes classic controller, nes classic controller)**

The **WiiExtensionControllers** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
NesClassicController nesController;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    var i2cBus = Device.CreateI2cBus(NesClassicController.DefaultI2cSpeed);

    nesController = new NesClassicController(i2cBus: i2cBus);

    //onetime update - could be used in a game loop
    nesController.Update();

    //check the state of a button
    Resolver.Log.Info("X Button is " + (nesController.AButton.State == true ? "pressed" : "not pressed"));

    //.NET events
    nesController.AButton.Clicked += (s, e) => Resolver.Log.Info("A button clicked");
    nesController.BButton.Clicked += (s, e) => Resolver.Log.Info("B button clicked");

    nesController.StartButton.Clicked += (s, e) => Resolver.Log.Info("+ button clicked");
    nesController.SelectButton.Clicked += (s, e) => Resolver.Log.Info("- button clicked");

    nesController.DPad.Updated += (s, e) => Resolver.Log.Info($"DPad {e.New}");

    return Task.CompletedTask;
}

public override Task Run()
{
    nesController.StartUpdating(TimeSpan.FromMilliseconds(200));
    return Task.CompletedTask;
}

```
