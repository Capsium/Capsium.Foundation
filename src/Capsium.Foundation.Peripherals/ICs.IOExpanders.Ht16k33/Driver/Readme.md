# Capsium.Foundation.ICs.IOExpanders.Ht16k33

**HT16K33 I2C IO expander, led driver, and character display controller**

The **Ht16k33** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
Ht16k33 ht16k33;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");
    ht16k33 = new Ht16k33(Device.CreateI2cBus());

    return base.Initialize();
}

public override async Task Run()
{
    int index = 0;
    bool on = true;

    while (true)
    {
        ht16k33.SetLed((byte)index, on);
        ht16k33.UpdateDisplay();
        index++;

        if (index >= 128)
        {
            index = 0;
            on = !on;
        }

        await Task.Delay(100);
    }
}

```
