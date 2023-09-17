# Capsium.Foundation.Sensors.Atmospheric.Sgp40

**SGP40 I2C VOC sensor driver**

The **Sgp40** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
Sgp40? sensor;

public override Task Initialize()
{
    Resolver.Log.Info("Initializing...");

    sensor = new Sgp40(Device.CreateI2cBus());

    Resolver.Log.Info($"Sensor SN: {sensor.SerialNumber:x6}");

    if (sensor.RunSelfTest())
    {
        Resolver.Log.Info("Self test successful");
    }
    else
    {
        Resolver.Log.Warn("Self test failed");
    }

    var consumer = Sgp40.CreateObserver(
        handler: result =>
        {
            Resolver.Log.Info($"Observer: VOC changed by threshold; new index: {result.New}");
        },
        filter: result =>
        {
            //c# 8 pattern match syntax. checks for !null and assigns var.
            return Math.Abs(result.New - result.Old ?? 0) > 10;
        }
    );
    sensor.Subscribe(consumer);

    sensor.Updated += (sender, result) =>
    {
        Resolver.Log.Info($"  VOC: {result.New}");
    };

    return base.Initialize();
}

public override async Task Run()
{
    await ReadConditions();

    sensor?.StartUpdating(TimeSpan.FromSeconds(1));
}

async Task ReadConditions()
{
    if (sensor == null) { return; }

    var result = await sensor.Read();
    Resolver.Log.Info("Initial Readings:");
    Resolver.Log.Info($"  Temperature: {result}");
}

```
