# Capsium.Foundation.Sensors.Motion.Bno055

**Bosch BNO055 I2C 9 axis absolute orientation sensor**

The **Bno055** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
Bno055 sensor;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    // create the sensor driver
    sensor = new Bno055(Device.CreateI2cBus());

    // classical .NET events can also be used:
    sensor.Updated += (sender, result) =>
    {
        Resolver.Log.Info($"Accel: [X:{result.New.Acceleration3D?.X.MetersPerSecondSquared:N2}," +
            $"Y:{result.New.Acceleration3D?.Y.MetersPerSecondSquared:N2}," +
            $"Z:{result.New.Acceleration3D?.Z.MetersPerSecondSquared:N2} (m/s^2)]");

        Resolver.Log.Info($"Gyro: [X:{result.New.AngularVelocity3D?.X.DegreesPerSecond:N2}," +
            $"Y:{result.New.AngularVelocity3D?.Y.DegreesPerSecond:N2}," +
            $"Z:{result.New.AngularVelocity3D?.Z.DegreesPerSecond:N2} (degrees/s)]");

        Resolver.Log.Info($"Compass: [X:{result.New.MagneticField3D?.X.Tesla:N2}," +
            $"Y:{result.New.MagneticField3D?.Y.Tesla:N2}," +
            $"Z:{result.New.MagneticField3D?.Z.Tesla:N2} (Tesla)]");

        Resolver.Log.Info($"Gravity: [X:{result.New.GravityVector?.X.MetersPerSecondSquared:N2}," +
            $"Y:{result.New.GravityVector?.Y.MetersPerSecondSquared:N2}," +
            $"Z:{result.New.GravityVector?.Z.MetersPerSecondSquared:N2} (meters/s^2)]");

        Resolver.Log.Info($"Quaternion orientation: [X:{result.New.QuaternionOrientation?.X:N2}," +
            $"Y:{result.New.QuaternionOrientation?.Y:N2}," +
            $"Z:{result.New.QuaternionOrientation?.Z:N2}]");

        Resolver.Log.Info($"Euler orientation: [heading: {result.New.EulerOrientation?.Heading:N2}," +
            $"Roll: {result.New.EulerOrientation?.Roll:N2}," +
            $"Pitch: {result.New.EulerOrientation?.Pitch:N2}]");

        Resolver.Log.Info($"Linear Accel: [X:{result.New.LinearAcceleration?.X.MetersPerSecondSquared:N2}," +
            $"Y:{result.New.LinearAcceleration?.Y.MetersPerSecondSquared:N2}," +
            $"Z:{result.New.LinearAcceleration?.Z.MetersPerSecondSquared:N2} (meters/s^2)]");

        Resolver.Log.Info($"Temp: {result.New.Temperature?.Celsius:N2}C");
    };

    // Example that uses an IObservable subscription to only be notified when the filter is satisfied
    var consumer = Bno055.CreateObserver(
        handler: result => Resolver.Log.Info($"Observer: [x] changed by threshold; new [x]: X:{result.New.Acceleration3D?.X.MetersPerSecondSquared:N2}, old: X:{result.Old?.Acceleration3D?.X.MetersPerSecondSquared:N2}"),
        // only notify if there's a greater than 1 micro tesla on the Y axis
        
        filter: result =>
        {
            if (result.Old is { } old)
            { //c# 8 pattern match syntax. checks for !null and assigns var.
                return ((result.New.Acceleration3D - old.Acceleration3D)?.Y > new Acceleration(1, AU.MetersPerSecondSquared));
            }
            return false;
        });
    sensor.Subscribe(consumer);

    return Task.CompletedTask;
}

public async override Task Run()
{ 
    await ReadConditions();

    sensor.StartUpdating(TimeSpan.FromMilliseconds(500));
}

protected async Task ReadConditions()
{
    var result = await sensor.Read();
    Resolver.Log.Info("Initial Readings:");
    Resolver.Log.Info($"Accel: [X:{result.Acceleration3D?.X.MetersPerSecondSquared:N2}," +
        $"Y:{result.Acceleration3D?.Y.MetersPerSecondSquared:N2}," +
        $"Z:{result.Acceleration3D?.Z.MetersPerSecondSquared:N2} (m/s^2)]");

    Resolver.Log.Info($"Gyro: [X:{result.AngularVelocity3D?.X.DegreesPerSecond:N2}," +
        $"Y:{result.AngularVelocity3D?.Y.DegreesPerSecond:N2}," +
        $"Z:{result.AngularVelocity3D?.Z.DegreesPerSecond:N2} (degrees/s)]");

    Resolver.Log.Info($"Compass: [X:{result.MagneticField3D?.X.Tesla:N2}," +
        $"Y:{result.MagneticField3D?.Y.Tesla:N2}," +
        $"Z:{result.MagneticField3D?.Z.Tesla:N2} (Tesla)]");

    Resolver.Log.Info($"Gravity: [X:{result.GravityVector?.X.MetersPerSecondSquared:N2}," +
        $"Y:{result.GravityVector?.Y.MetersPerSecondSquared:N2}," +
        $"Z:{result.GravityVector?.Z.MetersPerSecondSquared:N2} (meters/s^2)]");

    Resolver.Log.Info($"Quaternion orientation: [X:{result.QuaternionOrientation?.X:N2}," +
        $"Y:{result.QuaternionOrientation?.Y:N2}," +
        $"Z:{result.QuaternionOrientation?.Z:N2}]");

    Resolver.Log.Info($"Euler orientation: [heading: {result.EulerOrientation?.Heading:N2}," +
        $"Roll: {result.EulerOrientation?.Roll:N2}," +
        $"Pitch: {result.EulerOrientation?.Pitch:N2}]");

    Resolver.Log.Info($"Linear Accel: [X:{result.LinearAcceleration?.X.MetersPerSecondSquared:N2}," +
        $"Y:{result.LinearAcceleration?.Y.MetersPerSecondSquared:N2}," +
        $"Z:{result.LinearAcceleration?.Z.MetersPerSecondSquared:N2} (meters/s^2)]");

    Resolver.Log.Info($"Temp: {result.Temperature?.Celsius:N2}C");
}
        
```
