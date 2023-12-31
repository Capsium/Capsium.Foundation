# Capsium.Foundation.ICs.IOExpanders.Mcp23xxx

**Mcp23xxx I2C and SPI digital output expanders**

The **Mcp23xxx** library is designed for the [BMC](www.wildernesslabs.co) Capsium .NET IoT platform and is part of [Capsium.Foundation](https://developer.wildernesslabs.co/Capsium/Capsium.Foundation/)

The **Capsium.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Capsium IoT application.

For more information on developing for Capsium, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all BMC open-source projects, including samples, visit [github.com/Capsium](https://github.com/Capsium/)

## Usage

```
private Mcp23008 mcp;

public override Task Initialize()
{
    var interruptPort = Device.CreateDigitalInterruptPort(Device.Pins.D00, InterruptMode.EdgeRising);
    var resetPort = Device.CreateDigitalOutputPort(Device.Pins.D01);

    mcp = new Mcp23008(Device.CreateI2cBus(), 0x20, interruptPort, resetPort);

    return base.Initialize();
}

public override Task Run()
{
    BenchmarkDigitalOutputPorts();
    while (true)
    {
        TestBulkDigitalOutputPortWrites(20);
        TestDigitalOutputPorts(2);
    }
}

private void BenchmarkDigitalOutputPorts()
{
    var out00 = mcp.CreateDigitalOutputPort(mcp.Pins.GP0);
    var out01 = mcp.CreateDigitalOutputPort(mcp.Pins.GP1);
    var out02 = mcp.CreateDigitalOutputPort(mcp.Pins.GP2);
    var out03 = mcp.CreateDigitalOutputPort(mcp.Pins.GP3);
    var out04 = mcp.CreateDigitalOutputPort(mcp.Pins.GP4);
    var out05 = mcp.CreateDigitalOutputPort(mcp.Pins.GP5);
    var out06 = mcp.CreateDigitalOutputPort(mcp.Pins.GP6);
    var out07 = mcp.CreateDigitalOutputPort(mcp.Pins.GP7);

    var outputPorts = new List<IDigitalOutputPort>()
    {
        out00, out01, out02, out03, out04, out05, out06, out07
    };

    var state = false;
    var stopwatch = new Stopwatch();
    Console.WriteLine("Starting benchmark");

    for (var x = 0; x < 10; x++)
    {
        stopwatch.Restart();
        for (var iteration = 0; iteration < 100; iteration++)
        {
            for (var i = 0; i < outputPorts.Count; i++)
            {
                outputPorts[i].State = state;
            }

            state = !state;
        }
        stopwatch.Stop();

        Console.WriteLine($"{100 * outputPorts.Count} pins toggled in {stopwatch.ElapsedMilliseconds}ms");
    }

    Console.WriteLine("Benchmark finished");
}

private void TestDigitalOutputPorts(int loopCount)
{
    var out00 = mcp.CreateDigitalOutputPort(mcp.Pins.GP0);
    var out01 = mcp.CreateDigitalOutputPort(mcp.Pins.GP1);
    var out02 = mcp.CreateDigitalOutputPort(mcp.Pins.GP2);
    var out03 = mcp.CreateDigitalOutputPort(mcp.Pins.GP3);
    var out04 = mcp.CreateDigitalOutputPort(mcp.Pins.GP4);
    var out05 = mcp.CreateDigitalOutputPort(mcp.Pins.GP5);
    var out06 = mcp.CreateDigitalOutputPort(mcp.Pins.GP6);
    var out07 = mcp.CreateDigitalOutputPort(mcp.Pins.GP7);

    var outputPorts = new List<IDigitalOutputPort>()
    {
        out00, out01, out02, out03, out04, out05, out06, out07
    };

    foreach (var outputPort in outputPorts)
    {
        outputPort.State = true;
    }

    for (int l = 0; l < loopCount; l++)
    {
        // loop through all the outputs
        for (int i = 0; i < outputPorts.Count; i++)
        {
            // turn them all off
            foreach (var outputPort in outputPorts)
            {
                outputPort.State = false;
            }

            // turn on just one
            outputPorts[i].State = true;
            Thread.Sleep(250);
        }
    }

    // cleanup
    for (int i = 0; i < outputPorts.Count; i++)
    {
        outputPorts[i].Dispose();
    }
}

private void TestBulkDigitalOutputPortWrites(int loopCount)
{
    byte mask = 0x0;

    for (int l = 0; l < loopCount; l++)
    {
        for (int i = 0; i < 8; i++)
        {
            mcp.WriteToPorts(mask);
            mask = (byte)(1 << i);
            Thread.Sleep(5);
        }
    }
}
        
```
