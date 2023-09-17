# Capsium.Foundation.Sensors.Distance.Hcsr04

**HCSR04 digital ultrasonic distance sensor**

The **Hcsr04** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
Hcsr04 hCSR04;

public override Task Initialize()
{
    Resolver.Log.Info($"Hello HC-SR04 sample");

    hCSR04 = new Hcsr04(
        triggerPin: Device.Pins.D05,
        echoPin: Device.Pins.D06);
    hCSR04.DistanceUpdated += HCSR04_DistanceUpdated;

    return Task.CompletedTask;
}

public override Task Run()
{
    while (true)
    {
        // Sends a trigger signal
        hCSR04.MeasureDistance();
        Thread.Sleep(2000);
    }
}

private void HCSR04_DistanceUpdated(object sender, IChangeResult<Capsium.Units.Length> e)
{
    Resolver.Log.Info($"Distance (cm): {e.New.Centimeters}");
}

```
