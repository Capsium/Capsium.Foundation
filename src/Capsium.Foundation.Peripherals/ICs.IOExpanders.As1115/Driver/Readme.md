# Capsium.Foundation.ICs.IOExpanders.As1115

**AS1115 I2C IO expander, led driver, character display controller and keyscan**

The **As1115** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
As1115 as1115;
MicroGraphics graphics;

public override Task Initialize()
{
    Resolver.Log.Info("Initialize...");
    as1115 = new As1115(Device.CreateI2cBus(), Device.Pins.D03);

    //general key scan events - will raise for all buttons
    as1115.KeyScanPressStarted += KeyScanPressStarted;

    //or access buttons as IButtons individually
    as1115.KeyScanButtons[KeyScanButtonType.Button1].LongClickedThreshold = TimeSpan.FromSeconds(1);
    as1115.KeyScanButtons[KeyScanButtonType.Button1].Clicked += Button1_Clicked;
    as1115.KeyScanButtons[KeyScanButtonType.Button1].LongClicked += Button1_LongClicked; ;

    graphics = new MicroGraphics(as1115);

    return base.Initialize();
}

private void Button1_LongClicked(object sender, EventArgs e)
{
    Resolver.Log.Info("Button 1 long press");
}

private void Button1_Clicked(object sender, EventArgs e)
{
    Resolver.Log.Info("Button 1 clicked");
}

private void KeyScanPressStarted(object sender, KeyScanEventArgs e)
{
    Resolver.Log.Info($"{e.Button} pressed");
}

public override Task Run()
{
    graphics.Clear();
    graphics.DrawLine(0, 0, 7, 7, true);
    graphics.DrawLine(0, 7, 7, 0, true);

    graphics.Show();

    return base.Run();
}

```
