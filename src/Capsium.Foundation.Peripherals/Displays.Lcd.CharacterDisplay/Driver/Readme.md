# Capsium.Foundation.Displays.Lcd.CharacterDisplay

**Digital and I2C LCD character displays**

The **CharacterDisplay** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
CharacterDisplay display;

public override Task Initialize()
{
    //InitGpio();
    //InitGpioWithPWM();
    //InitI2c();
    InitGrove();

    return base.Initialize();
}

void InitGpio()
{
    Resolver.Log.Info("InitGpio...");

    display = new CharacterDisplay
    (
        pinRS: Device.Pins.D10,
        pinE: Device.Pins.D09,
        pinD4: Device.Pins.D08,
        pinD5: Device.Pins.D07,
        pinD6: Device.Pins.D06,
        pinD7: Device.Pins.D05,
        rows: 4, columns: 20
    );
}

void InitGpioWithPWM()
{
    Resolver.Log.Info("InitGpioWithPWM...");

    display = new CharacterDisplay
    (
        pinV0: Device.Pins.D11,
        pinRS: Device.Pins.D10,
        pinE: Device.Pins.D09,
        pinD4: Device.Pins.D08,
        pinD5: Device.Pins.D07,
        pinD6: Device.Pins.D06,
        pinD7: Device.Pins.D05,
        rows: 4, columns: 20
    );
}

void InitI2c()
{
    Resolver.Log.Info("InitI2c...");

    display = new CharacterDisplay
    (
        i2cBus: Device.CreateI2cBus(I2cBusSpeed.Standard),
        address: (byte)I2cCharacterDisplay.Addresses.Default,
        rows: 4, columns: 20
    );
}

void InitGrove()
{
    Resolver.Log.Info("InitGrove...");

    display = new CharacterDisplay
    (
        i2cBus: Device.CreateI2cBus(I2cBusSpeed.Standard),
        address: (byte)I2cCharacterDisplay.Addresses.Grove,
        rows: 2, columns: 16,
        isGroveDisplay: true
    );
}

void TestCharacterDisplay()
{
    Resolver.Log.Info("TestCharacterDisplay...");

    display.WriteLine("Hello", 0);

    display.WriteLine("Display", 1);

    Thread.Sleep(1000);
    display.WriteLine("Will delete in", 0);

    int count = 5;
    while (count > 0)
    {
        display.WriteLine($"{count--}", 1);
        Thread.Sleep(500);
    }

    display.ClearLines();
    Thread.Sleep(2000);

    display.WriteLine("Cursor test", 0);

    for (int i = 0; i < display.DisplayConfig.Width; i++)
    {
        display.SetCursorPosition((byte)i, 1);
        display.Write("*");
        Thread.Sleep(100);
        display.SetCursorPosition((byte)i, 1);
        display.Write(" ");
    }

    display.ClearLines();
    display.WriteLine("Complete!", 0);
}

public override Task Run()
{
    TestCharacterDisplay();

    Resolver.Log.Info("Test complete");

    return base.Run();
}

```
