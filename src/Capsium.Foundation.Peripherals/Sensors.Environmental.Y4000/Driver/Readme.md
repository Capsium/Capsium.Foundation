# Capsium.Foundation.Sensors.Environmental.Y4000

**Y4000 Sonde RS485 Modbus water quality sensor**

The **Y4000** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
Y4000 sensor;

public async override Task Initialize()
{
    Resolver.Log.Info("Initialize...");
    await Task.Delay(2000);

    sensor = new Y4000(Device, Device.PlatformOS.GetSerialPortName("COM4"), 0x01, Device.Pins.D09);
    await sensor.Initialize();

    await Task.Delay(2000);
}

public override async Task Run()
{
    Resolver.Log.Info("Run...");

    var isdn = await sensor.GetISDN();
    Resolver.Log.Info($"Address: {isdn}");

    var supplyVoltage = await sensor.GetSupplyVoltage();
    Resolver.Log.Info($"Supply voltage: {supplyVoltage}");

    var measurements = await sensor.Read();

    Resolver.Log.Info($"Sensor data: {measurements}");
}

```
