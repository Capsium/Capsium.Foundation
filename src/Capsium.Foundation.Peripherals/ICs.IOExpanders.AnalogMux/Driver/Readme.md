# Capsium.Foundation.ICs.IOExpanders.AnalogMux

**Library for various analog multiplexers**

The **AnalogMux** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
private Nxp74HC4051 mux;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    mux = new Nxp74HC4051(
        Device.CreateAnalogInputPort(Device.Pins.A00),      // input
        Device.CreateDigitalOutputPort(Device.Pins.D00),    // s0
        Device.CreateDigitalOutputPort(Device.Pins.D01),    // s1
        Device.CreateDigitalOutputPort(Device.Pins.D02),    // s2
        Device.CreateDigitalOutputPort(Device.Pins.D03)     // enable
        );

    return base.Initialize();
}

public override Task Run()
{
    Task.Run(ReadRoundRobin);

    return base.Run();
}

public async Task ReadRoundRobin()
{
    while (true)
    {
        for (var channel = 0; channel < 8; channel++)
        {
            mux.SetInputChannel(channel);
            var read = await mux.Signal.Read();
            Resolver.Log.Info($"ADC Channel {channel} = {read.Volts:0.0}V");
            await Task.Delay(1000);
        }
    }
}

```
