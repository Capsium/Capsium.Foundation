# Capsium.Foundation.ICs.IOExpanders.SerialWombat

**SerialWombat I2C IO expander for GPIO, PWM, servos, etc.**

The **SerialWombat** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
private Sw18AB serialWombat;
private IAnalogInputPort analogInputPort;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    try
    {
        Resolver.Log.Info(" creating Wombat...");
        serialWombat = new Sw18AB(Device.CreateI2cBus(), logger: Resolver.Log);
        Resolver.Log.Info(" creating ADC...");
        analogInputPort = serialWombat.CreateAnalogInputPort(serialWombat.Pins.WP0);
    }
    catch (Exception ex)
    {
        Resolver.Log.Error($"error: {ex.Message}");
    }

    return Task.CompletedTask;
}

public override async Task Run()
{
    Resolver.Log.Info("Running...");

    Resolver.Log.Info($"ADC: Reference voltage = {analogInputPort.ReferenceVoltage.Volts:0.0}V");
    for (int i = 1; i < 1000; i += 10)
    {
        var v = await analogInputPort.Read();
        Resolver.Log.Info($"ADC: {analogInputPort.Voltage.Volts:0.0}V");
        await Task.Delay(2000);
    }
}

```
