# Capsium.Foundation.Sensors.Distance.Vl53l0x

**Vl53l0x I2C time of flight ranging distance sensor**

The **Vl53l0x** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
Vl53l0x sensor;

public override Task Initialize()
{
    Resolver.Log.Info("Initializing hardware...");

    var i2cBus = Device.CreateI2cBus(I2cBusSpeed.FastPlus);
    sensor = new Vl53l0x(i2cBus);

    sensor.DistanceUpdated += Sensor_Updated;

    return Task.CompletedTask;
}

public override Task Run()
{
    sensor.StartUpdating(TimeSpan.FromMilliseconds(250));

    return Task.CompletedTask;
}

private void Sensor_Updated(object sender, IChangeResult<Length> result)
{
    if (result.New == null) { return; }

    if (result.New < new Length(0, LU.Millimeters))
    {
        Resolver.Log.Info("out of range.");
    }
    else
    {
        Resolver.Log.Info($"{result.New.Millimeters}mm / {result.New.Inches:n3}\"");
    }
}

```
