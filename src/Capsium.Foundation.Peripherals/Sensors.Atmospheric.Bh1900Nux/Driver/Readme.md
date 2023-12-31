# Capsium.Foundation.Sensors.Atmospheric.Bh1900Nux

**Rohm BH1900NUX I2C temperature sensor**

The **Bh1900Nux** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
private Bh1900Nux _sensor;

public override Task Initialize()
{
    Resolver.Log.Info("Initializing...");

    _sensor = new Bh1900Nux(Device.CreateI2cBus(), Bh1900Nux.Addresses.Default);

    var consumer = Bh1900Nux.CreateObserver(
        handler: result =>
        {
            Resolver.Log.Info($"Observer: Temp changed by threshold; new temp: {result.New.Celsius:N2}C, old: {result.Old?.Celsius:N2}C");
        },
        filter: result =>
        {
            //c# 8 pattern match syntax. checks for !null and assigns var.
            if (result.Old is { } old)
            {
                return (result.New - old).Abs().Celsius > 0.5;
            }
            return false;
        }
    );
    _sensor.Subscribe(consumer);

    _sensor.Updated += (sender, result) =>
    {
        Resolver.Log.Info($"  Temperature: {result.New.Celsius:N2}C");
    };
   
    return Task.CompletedTask;
}

public async override Task Run()
{
    var conditions = await _sensor.Read();
    Resolver.Log.Info("Initial Readings:");
    Resolver.Log.Info($"  Temperature: {conditions.Celsius:N2}C");

    _sensor.StartUpdating(TimeSpan.FromSeconds(1));
}

```
