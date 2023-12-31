# Capsium.Foundation.Sensors.Radio.Rfid.IDxxLA

**IDxxLA Serial radio frequency ID readers**

The **IDxxLA** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
IRfidReader rfidReader;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    rfidReader = new IDxxLA(Device, Device.PlatformOS.GetSerialPortName("COM1"));

    // subscribe to event
    rfidReader.RfidRead += RfidReaderOnTagRead;

    // subscribe to IObservable
    rfidReader.Subscribe(new RfidObserver());

    return Task.CompletedTask;
}

public override Task Run()
{ 
    rfidReader.StartReading();

    return Task.CompletedTask;
}

private void RfidReaderOnTagRead(object sender, RfidReadResult e)
{
    if (e.Status == RfidValidationStatus.Ok) {
        Resolver.Log.Info($"From event - Tag value is {DebugInformation.Hexadecimal(e.RfidTag)}");
        return;
    }

    Resolver.Log.Error($"From event - Error {e.Status}");
}

private class RfidObserver : IObserver<byte[]>
{
    public void OnCompleted()
    {
        Resolver.Log.Info("From IObserver - RfidReader has terminated, no more events will be emitted.");
    }
     
    public void OnError(Exception error)
    {
        Resolver.Log.Error($"From IObserver - {error}");
    }

    public void OnNext(byte[] value)
    {
        Resolver.Log.Info($"From IObserver - Tag value is {DebugInformation.Hexadecimal(value)}");
    }
}

```
