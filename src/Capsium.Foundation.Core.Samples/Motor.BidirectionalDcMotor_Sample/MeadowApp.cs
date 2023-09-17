using Capsium;
using Capsium.Devices;
using Capsium.Foundation.Motors;
using Capsium.Hardware;
using System.Threading.Tasks;

namespace Motor.BidirectionalDcMotor_Sample;

public class CapsiumApp : App<F7FeatherV2>
{
    //<!=SNIP=>

    private BidirectionalDcMotor motor;

    public override Task Initialize()
    {
        Resolver.Log.Info("Initializing...");

        IDigitalOutputPort motorA;
        IDigitalOutputPort motorB;

        motorA = Device.Pins.D00.CreateDigitalOutputPort(false);
        motorB = Device.Pins.D01.CreateDigitalOutputPort(false);

        motor = new BidirectionalDcMotor(motorA, motorB);

        return Task.CompletedTask;
    }

    public override async Task Run()
    {
        Resolver.Log.Info("Test Motor...");

        while (true)
        {
            // Motor clockwise
            motor.StartClockwise();
            await Task.Delay(1000);

            // Motor Stop
            motor.Stop();
            await Task.Delay(500);

            // Motor counter clockwise
            motor.StartCounterClockwise();
            await Task.Delay(1000);

            // Motor Stop
            motor.Stop();
            await Task.Delay(500);
        }
    }

    //<!=SNOP=>
}