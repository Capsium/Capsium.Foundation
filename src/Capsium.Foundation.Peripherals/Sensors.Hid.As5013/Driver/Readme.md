# Capsium.Foundation.Sensors.Hid.As5013

**I2C Hall sensor IC for smart navigation**

The **As5013** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
As5013 joystick;

public override Task Initialize()
{
    Resolver.Log.Info("Initializing ...");

    joystick = new As5013(Device.CreateI2cBus());

    joystick.Updated += As5013_Updated;

    return Task.CompletedTask;
}

public override Task Run()
{
    joystick.StartUpdating(TimeSpan.FromMilliseconds(100));

    return Task.CompletedTask;
}

private void As5013_Updated(object sender, IChangeResult<Capsium.Peripherals.Sensors.Hid.AnalogJoystickPosition> e)
{
    Resolver.Log.Info($"{e.New.Horizontal}, {e.New.Vertical}");
}

```
