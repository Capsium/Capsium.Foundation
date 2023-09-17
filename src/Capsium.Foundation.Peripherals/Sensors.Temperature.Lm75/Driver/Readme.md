# Capsium.Foundation.Sensors.Temperature.Lm75

**Lm75 I2C temperature sensor**

The **Lm75** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
Lm75 lm75;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    lm75 = new Lm75(Device.CreateI2cBus());

    var consumer = Lm75.CreateObserver(
        handler: result =>
        {
            Resolver.Log.Info($"Temperature New Value { result.New.Celsius}C");
            Resolver.Log.Info($"Temperature Old Value { result.Old?.Celsius}C");
              },
        filter: null
    );
    lm75.Subscribe(consumer);

    lm75.TemperatureUpdated += (object sender, IChangeResult<Capsium.Units.Temperature> e) =>
    {
        Resolver.Log.Info($"Temperature Updated: {e.New.Celsius:n2}C");
    };
    return Task.CompletedTask;
}

public override async Task Run()
{
    var temp = await lm75.Read();
    Resolver.Log.Info($"Temperature New Value {temp.Celsius}C");

    lm75.StartUpdating();
}

```
