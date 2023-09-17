# Capsium.Foundation.Sensors.Temperature.Mcp9808

**MCP9808 I2C temperature sensor**

The **Mcp9808** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
Mcp9808 mcp9808;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    mcp9808 = new Mcp9808(Device.CreateI2cBus());

    var consumer = Mcp9808.CreateObserver(
        handler: result =>
        {
            Resolver.Log.Info($"Temperature New Value { result.New.Celsius}C");
            Resolver.Log.Info($"Temperature Old Value { result.Old?.Celsius}C");
        },
        filter: null
    );
    mcp9808.Subscribe(consumer);

    mcp9808.TemperatureUpdated += (object sender, IChangeResult<Capsium.Units.Temperature> e) =>
    {
        Resolver.Log.Info($"Temperature Updated: {e.New.Celsius:N2}C");
    };

    return Task.CompletedTask;
}

public override async Task Run()
{
    var temp = await mcp9808.Read();

    Resolver.Log.Info($"Temperature New Value {temp.Celsius}C");

    mcp9808.StartUpdating(TimeSpan.FromSeconds(1));
}

```
