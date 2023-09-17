# Capsium.Foundation.Sensors.Environmental.Scd4x

**SCD4x I2C C02, temperature, and relative humidity sensor (SCD40, SCD41)**

The **Scd4x** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
Scd40 sensor;

public override Task Initialize()
{
    Resolver.Log.Info("Initializing...");

    var i2cBus = Device.CreateI2cBus(Capsium.Hardware.I2cBusSpeed.Standard);
      
    sensor = new Scd40(i2cBus);
    var serialNum = sensor.GetSerialNumber();
    Resolver.Log.Info($"Serial: {BitConverter.ToString(serialNum)}");

    var consumer = Scd40.CreateObserver(
        handler: result =>
        {
            Resolver.Log.Info($"Observer: Temp changed by threshold; new temp: {result.New.Temperature?.Celsius:N2}C, old: {result.Old?.Temperature?.Celsius:N2}C");
        },
        filter: result =>
        {
            if (result.Old?.Temperature is { } oldTemp &&
                result.Old?.Humidity is { } oldHumidity &&
                result.New.Temperature is { } newTemp &&
                result.New.Humidity is { } newHumidity)
            {
                return ((newTemp - oldTemp).Abs().Celsius > 0.5 &&
                        (newHumidity - oldHumidity).Percent > 0.05);
            }
            return false;
        }
    );

    sensor?.Subscribe(consumer);

    if (sensor != null)
    {
        sensor.Updated += (sender, result) =>
        {
            Resolver.Log.Info($"  Concentration: {result.New.Concentration?.PartsPerMillion:N0}ppm");
            Resolver.Log.Info($"  Temperature: {result.New.Temperature?.Celsius:N1}C");
            Resolver.Log.Info($"  Relative Humidity: {result.New.Humidity:N0}%");
        };
    }

    sensor?.StartUpdating(TimeSpan.FromSeconds(6));

    return base.Initialize();
}

```
