# Capsium.Foundation.Sensors.Camera.Vc0706

**VC0706 serial VGA CMOS camera**

The **Vc0706** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
Vc0706 camera;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");

    camera = new Vc0706(Device, Device.PlatformOS.GetSerialPortName("COM4"), 38400);

    return Task.CompletedTask;
}

public override Task Run()
{
    if (!camera.SetCaptureResolution(Vc0706.ImageResolution._160x120))
    {
        Resolver.Log.Info("Set resolution failed");
    }

    _ = TakePicture();

    return Task.CompletedTask;
}

async Task TakePicture()
{
    Resolver.Log.Info($"Image size is {camera.GetCaptureResolution()}");

    camera.CapturePhoto();

    using var jpegStream = await camera.GetPhotoStream();

    var jpeg = new JpegImage(jpegStream);
    Resolver.Log.Info($"Image decoded - width:{jpeg.Width}, height:{jpeg.Height}");
}

```
