# Capsium.Foundation.ADCs.Mcp3xxx

**Mcp3xxx SPI analog-to-digital converter (MCP3001, MCP3002, MCP3004, MCP3008, MCP3201, MCP3202, MCP3204, MCP3208)**

The **Mcp3xxx** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
Mcp3001 mcp;

IAnalogInputPort port;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize");

    IDigitalOutputPort chipSelectPort = Device.CreateDigitalOutputPort(Device.Pins.D01);

    mcp = new Mcp3001(Device.CreateSpiBus(), chipSelectPort);

    port = mcp.CreateAnalogInputPort();

    port.Updated += (s, result) =>
    {
        Console.WriteLine($"Analog event, new voltage: {result.New.Volts:N2}V, old: {result.Old?.Volts:N2}V");
    };

    var observer = IAnalogInputPort.CreateObserver(
        handler: result =>
        {
            Resolver.Log.Info($"Analog observer triggered; new: {result.New.Volts:n2}V, old: {result.Old?.Volts:n2}V");
        },
        filter: result =>
        {
            if (result.Old is { } oldValue)
            {
                return (result.New - oldValue).Abs().Volts > 0.1;
            }
            else { return false; }
        }
    );
    port.Subscribe(observer);

    return base.Initialize();
}

public override Task Run()
{
    Resolver.Log.Info("Run");

    port.StartUpdating();

    return Task.CompletedTask;
}

```
