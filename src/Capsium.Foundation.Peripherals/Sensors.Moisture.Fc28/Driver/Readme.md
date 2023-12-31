# Capsium.Foundation.Sensors.Moisture.Fc28

**FC28 analog soil moisture sensor**

The **Fc28** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
Fc28 fc28;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    fc28 = new Fc28(
        Device.CreateAnalogInputPort(Device.Pins.A01, 5, TimeSpan.FromMilliseconds(40), new Voltage(3.3, Voltage.UnitType.Volts)),
        Device.CreateDigitalOutputPort(Device.Pins.D15),
        minimumVoltageCalibration: new Voltage(3.24f, VU.Volts),
        maximumVoltageCalibration: new Voltage(2.25f, VU.Volts)
    );

    var consumer = Fc28.CreateObserver(
        handler: result => {
            // the first time through, old will be null.
            string oldValue = (result.Old is { } old) ? $"{old:n2}" : "n/a"; // C# 8 pattern matching
            Resolver.Log.Info($"Subscribed - " +
                $"new: {result.New}, " +
                $"old: {oldValue}");
        },
        filter: null
    );
    fc28.Subscribe(consumer);

    fc28.HumidityUpdated += (object sender, IChangeResult<double> e) =>
    {
        Resolver.Log.Info($"Moisture Updated: {e.New}");
    };

    return Task.CompletedTask;
}

public async override Task Run()
{
    var moisture = await fc28.Read();
    Resolver.Log.Info($"Moisture Value { moisture}");

    fc28.StartUpdating(TimeSpan.FromMilliseconds(5000));
}

```
