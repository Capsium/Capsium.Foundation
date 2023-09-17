# Capsium.Foundation.Motors.Stepper.Uln2003

**ULN2003 digital input stepper motor controller**

The **Uln2003** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
Uln2003 stepperController;

public override Task Initialize()
{
    stepperController = new Uln2003(
        pin1: Device.Pins.D01,
        pin2: Device.Pins.D02,
        pin3: Device.Pins.D03,
        pin4: Device.Pins.D04);

    return base.Initialize();
}

public override Task Run()
{
    stepperController.Step(1024);

    for (int i = 0; i < 100; i++)
    {
        Resolver.Log.Info($"Step forward {i}");
        stepperController.Step(50);
        Thread.Sleep(10);
    }

    for (int i = 0; i < 100; i++)
    {
        Resolver.Log.Info($"Step backwards {i}");
        stepperController.Step(-50);
        Thread.Sleep(10);
    }

    return base.Run();
}

```
