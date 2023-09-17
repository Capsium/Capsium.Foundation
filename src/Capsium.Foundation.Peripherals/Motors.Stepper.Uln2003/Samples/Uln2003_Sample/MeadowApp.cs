using System;
using System.Threading;
using System.Threading.Tasks;
using Capsium;
using Capsium.Devices;
using Capsium.Foundation.Motors.Stepper;

namespace CapsiumApp
{
    public class CapsiumApp : App<F7FeatherV2>
    {
        //<!=SNIP=>

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

        //<!=SNOP=>
    }
}