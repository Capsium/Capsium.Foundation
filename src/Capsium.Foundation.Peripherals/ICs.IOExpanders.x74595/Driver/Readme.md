# Capsium.Foundation.ICs.IOExpanders.x74595

**x74595 SPI shift register digital output expander**

The **x74595** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
x74595 shiftRegister;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    shiftRegister = new x74595(Device.CreateSpiBus(), Device.Pins.D00, 8);

    return base.Initialize();
}

public override async Task Run()
{
    shiftRegister.Clear(true);

    Resolver.Log.Info("Set Pin 3 to high");
    //turn on pin 3
    shiftRegister.WriteToPin(shiftRegister.Pins.GP3, true);

    Resolver.Log.Info("Set Pin 4 to high");

    //get the port for Pin4
    var port4 = shiftRegister.CreateDigitalOutputPort(shiftRegister.Pins.GP4, true, Capsium.Hardware.OutputType.OpenDrain);

    Resolver.Log.Info("Toggle pin 4");

    await Task.Delay(1000);
    port4.State = false;
    await Task.Delay(1000);
    port4.State = true;
    await Task.Delay(1000);

    Resolver.Log.Info("Raise all pins to high");
    while (true)
    {
        shiftRegister.Clear();

        foreach (var pin in shiftRegister.Pins.AllPins)
        {
            shiftRegister.WriteToPin(pin, true);
            await Task.Delay(50);
        }
    }
}

```
