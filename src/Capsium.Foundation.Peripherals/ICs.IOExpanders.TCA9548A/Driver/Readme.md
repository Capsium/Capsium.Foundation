# Capsium.Foundation.ICs.IOExpanders.Tca9548a

**TCA9548A I2C IO expander**

The **Tca9548a** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
IDigitalOutputPort bus0Port0;
IDigitalOutputPort bus1Port0;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    var i2cBus = Device.CreateI2cBus(I2cBusSpeed.Standard);
    var tca9548a = new Tca9548a(i2cBus, 0x70);
    var mcp0 = new Mcp23008(tca9548a.Bus0);
    var mcp1 = new Mcp23008(tca9548a.Bus1);

    bus0Port0 = mcp0.CreateDigitalOutputPort(mcp0.Pins.GP0);
    bus1Port0 = mcp1.CreateDigitalOutputPort(mcp1.Pins.GP0);

    return base.Initialize();
}

public override async Task Run()
{
    while (true)
    {
        bus0Port0.State = true;
        bus1Port0.State = false;

        await Task.Delay(1000);

        bus0Port0.State = false;
        bus1Port0.State = true;

        await Task.Delay(1000);
    }
}

```
