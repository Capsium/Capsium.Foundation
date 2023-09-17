# Capsium.Foundation.Sensors.Distance.Me007ys

**Me007ys serial ultrasonic distance sensor**

The **Me007ys** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
Me007ys me007ys;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    me007ys = new Me007ys(Device, Device.PlatformOS.GetSerialPortName("COM1"));

    var consumer = Me007ys.CreateObserver(
        handler: result =>
        {
            Resolver.Log.Info($"Observer: Distance changed by threshold; new distance: {result.New.Centimeters:N1}cm, old: {result.Old?.Centimeters:N1}cm");
        },
        filter: result =>
        {
            if (result.Old is { } old)
            {
                return Math.Abs((result.New - old).Centimeters) > 0.5;
            }
            return false;
        }
    );
    me007ys.Subscribe(consumer);

    me007ys.DistanceUpdated += Me007y_DistanceUpdated;

    return Task.CompletedTask;
}

public override async Task Run()
{
    var distance = await me007ys.Read();
    Resolver.Log.Info($"Initial distance is: {distance.Centimeters:N1}cm / {distance.Inches:N1}in");

    me007ys.StartUpdating(TimeSpan.FromSeconds(2));
}

private void Me007y_DistanceUpdated(object sender, IChangeResult<Length> e)
{
    Resolver.Log.Info($"Distance: {e.New.Centimeters:N1}cm / {e.New.Inches:N1}in");
}

```
