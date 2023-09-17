# Capsium.Foundation.Sensors.Temperature.Mcp960x

**Mcp960x I2C thermocouple temperature sensor**

The **Mcp960x** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
Mcp9600 sensor;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    sensor = new Mcp9600(Device.CreateI2cBus());

    var consumer = Mcp9600.CreateObserver(
        handler: result =>
        {
            Resolver.Log.Info($"Temperature New Value {result.New.TemperatureHot.Value.Celsius}C");
        },
        filter: null
    );
    sensor.Subscribe(consumer);

    sensor.Updated += Sensor_Updated;
    return Task.CompletedTask;
}

private void Sensor_Updated(object sender, IChangeResult<(Capsium.Units.Temperature? TemperatureHot, Capsium.Units.Temperature? TemperatureCold)> e)
{
    Resolver.Log.Info($"Temperature hot: {e.New.TemperatureHot.Value.Celsius:n2}C, Temperature cold: {e.New.TemperatureCold.Value.Celsius:n2}C");
}

public override async Task Run()
{
    sensor.StartUpdating();
}

```
