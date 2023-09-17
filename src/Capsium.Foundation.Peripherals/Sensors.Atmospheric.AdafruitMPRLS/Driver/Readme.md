# Capsium.Foundation.Sensors.Atmospheric.AdafruitMPRLS

**Adafruit MPRLS I2C barometric pressure sensor with metal port connector**

The **AdafruitMPRLS** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
AdafruitMPRLS sensor;

public override Task Initialize()
{
    Resolver.Log.Info("Initializing...");

    sensor = new AdafruitMPRLS(Device.CreateI2cBus());
    sensor.Updated += PressureSensor_Updated;

    return Task.CompletedTask;
}

public override Task Run()
{
    sensor.StartUpdating(TimeSpan.FromSeconds(1));

    return Task.CompletedTask;
}

void PressureSensor_Updated(object sender, IChangeResult<(Pressure? Pressure, Pressure? RawPsiMeasurement)> result)
{
    Resolver.Log.Info($"New pressure PSI: {result.New.Pressure?.Psi}, Old pressure PSI: {result.Old?.Pressure?.Psi}");

    Resolver.Log.Info($"Pressure in Pascal: {result.New.Pressure?.Pascal}");

    Resolver.Log.Info($"Raw sensor value: {result.New.RawPsiMeasurement?.Psi}");
}

```
