# Capsium.Foundation.ICs.IOExpanders.Pca9685

**PCA9685 I2C PWM expander**

The **Pca9685** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
Pca9685 pca9685;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");
    var i2CBus = Device.CreateI2cBus(I2cBusSpeed.FastPlus);

    pca9685 = new Pca9685(i2CBus, new Capsium.Units.Frequency(50, Capsium.Units.Frequency.UnitType.Hertz), (byte)Pca9685.Addresses.Default);
    pca9685.Initialize();

    return base.Initialize();
}

public override Task Run()
{
    var port0 = pca9685.CreatePwmPort(0, 0.05f);
    var port7 = pca9685.CreatePwmPort(7);

    port0.Start();
    port7.Start();

    return base.Run();
}

```
