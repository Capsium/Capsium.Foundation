# Capsium.Foundation.Servos.ServoCore

**PWM generic servo controller**

The **ServoCore** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
protected Servo servo;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    servo = new Servo(Device.Pins.D02, NamedServoConfigs.SG90);

    return Task.CompletedTask;
}

public async override Task Run()
{ 
    await servo.RotateTo(new Angle(0, AU.Degrees));

    while (true)
    {
        for (int i = 0; i <= servo.Config.MaximumAngle.Degrees; i++)
        {
            await servo.RotateTo(new Angle(i, AU.Degrees));
            Resolver.Log.Info($"Rotating to {i}");
        }

        await Task.Delay(2000);

        for (int i = 180; i >= servo.Config.MinimumAngle.Degrees; i--)
        {
            await servo.RotateTo(new Angle(i, AU.Degrees));
            Resolver.Log.Info($"Rotating to {i}");
        }
        await Task.Delay(2000);
    }
}

```
