# Capsium.Foundation.Sensors.Environmental.MiniPID2

**MiniPID2 analog photoionisation (PID) VOC sensor**

The **MiniPID2** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
MiniPID2 sensor;

public override Task Initialize()
{
    Resolver.Log.Info("Initializing...");

    sensor = new MiniPID2(Device.Pins.A01, MiniPID2.MiniPID2Type.PPB_WR);

    var consumer = MiniPID2.CreateObserver(
        handler: result =>
        {
            Resolver.Log.Info($"Observer: VOC concentration changed by threshold; new: {result.New.PartsPerBillion:N1}ppm");
        },
        filter: result =>
        {
            if (result.Old is { } oldCon &&
                result.New is { } newCon)
            {
                return Math.Abs((newCon - oldCon).PartsPerMillion) > 10;
            }
            return false;
        }
    );

    sensor?.Subscribe(consumer);

    if (sensor != null)
    {
        sensor.Updated += (sender, result) =>
        {
            Resolver.Log.Info($"  VOC Concentraion: {result.New.PartsPerMillion:N1}ppm");
        };
    }

    sensor?.StartUpdating(TimeSpan.FromSeconds(2));

    return base.Initialize();
}

```
