# Capsium.Foundation.RTCs.Ds323x

**Ds323x I2C real time clock (DS3231)**

The **Ds323x** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
Ds3231 sensor;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    sensor = new Ds3231(Device.CreateI2cBus(), Device.Pins.D06);
    sensor.OnAlarm1Raised += Sensor_OnAlarm1Raised;

    return base.Initialize();
}

public override Task Run()
{
    sensor.CurrentDateTime = new DateTime(2020, 1, 1);

    Resolver.Log.Info($"Current time: {sensor.CurrentDateTime}");
    Resolver.Log.Info($"Temperature: {sensor.Temperature}");

    sensor.ClearInterrupt(Ds323x.Alarm.BothAlarmsRaised);

    sensor.SetAlarm(Ds323x.Alarm.Alarm1Raised,
        new DateTime(2020, 1, 1, 1, 0, 0),
        Ds323x.AlarmType.WhenSecondsMatch);

    sensor.DisplayRegisters();

    return base.Run();
}

private void Sensor_OnAlarm1Raised(object sender)
{
    var rtc = (Ds3231)sender;
    Resolver.Log.Info("Alarm 1 has been activated: " + rtc.CurrentDateTime.ToString("dd MMM yyyy HH:mm:ss"));
    rtc.ClearInterrupt(Ds323x.Alarm.Alarm1Raised);
}

```
