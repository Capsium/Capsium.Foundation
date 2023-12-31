# Capsium.Foundation.Sensors.Gnss.Mt3339

**MediaTek MT3339 serial GNSS / GPS controller**

The **Mt3339** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
Mt3339 gps;

public override Task Initialize()
{
    Resolver.Log.Info("Initializing ...");

    gps = new Mt3339(Device, Device.PlatformOS.GetSerialPortName("COM4"));

    gps.GgaReceived += (object sender, GnssPositionInfo location) => {
        Resolver.Log.Info("*********************************************");
        Resolver.Log.Info(location.ToString());
        Resolver.Log.Info("*********************************************");
    };
    // GLL
    gps.GllReceived += (object sender, GnssPositionInfo location) => {
        Resolver.Log.Info("*********************************************");
        Resolver.Log.Info(location.ToString());
        Resolver.Log.Info("*********************************************");
    };
    // GSA
    gps.GsaReceived += (object sender, ActiveSatellites activeSatellites) => {
        Resolver.Log.Info("*********************************************");
        Resolver.Log.Info(activeSatellites.ToString());
        Resolver.Log.Info("*********************************************");
    };
    // RMC (recommended minimum)
    gps.RmcReceived += (object sender, GnssPositionInfo positionCourseAndTime) => {
        Resolver.Log.Info("*********************************************");
        Resolver.Log.Info(positionCourseAndTime.ToString());
        Resolver.Log.Info("*********************************************");

    };
    // VTG (course made good)
    gps.VtgReceived += (object sender, CourseOverGround courseAndVelocity) => {
        Resolver.Log.Info("*********************************************");
        Resolver.Log.Info($"{courseAndVelocity}");
        Resolver.Log.Info("*********************************************");
    };
    // GSV (satellites in view)
    gps.GsvReceived += (object sender, SatellitesInView satellites) => {
        Resolver.Log.Info("*********************************************");
        Resolver.Log.Info($"{satellites}");
        Resolver.Log.Info("*********************************************");
    };

    return Task.CompletedTask;
}

public override Task Run()
{
    gps.StartUpdating();

    return Task.CompletedTask;
}

```
