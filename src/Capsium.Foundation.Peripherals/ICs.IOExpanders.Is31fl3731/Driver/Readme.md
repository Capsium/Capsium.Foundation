# Capsium.Foundation.ICs.IOExpanders.Is31fl3731

**IS31FL3731 I2C matrix led driver**

The **Is31fl3731** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
Is31fl3731 iS31FL3731;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");
    iS31FL3731 = new Is31fl3731(Device.CreateI2cBus());
    iS31FL3731.Initialize();

    return base.Initialize();
}

public override Task Run()
{
    iS31FL3731.ClearAllFrames();
    iS31FL3731.SetFrame(frame: 0);
    iS31FL3731.DisplayFrame(frame: 0);

    //Turn on all LEDs in frame
    for (byte i = 0; i <= 144; i++)
    {
        iS31FL3731.SetLedPwm(
            frame: 0,
            ledIndex: i,
            brightness: 128);

        Thread.Sleep(50);
    }

    return base.Run();
}

```
