using System;
using System.Threading;
using System.Threading.Tasks;
using Capsium;
using Capsium.Devices;
using Capsium.Foundation.ICs.IOExpanders;

namespace CapsiumApp
{
    public class CapsiumApp : App<F7FeatherV2>
    {
        //<!=SNIP=>

        x74595 shiftRegister;

        public override Task Initialize()
        {
            Resolver.Log.Info("Initialize...");

            shiftRegister = new x74595(Device.CreateSpiBus(), Device.Pins.D00, 8);

            return base.Initialize();
        }

        public override async Task Run()
        {
            shiftRegister.Clear(true);

            Resolver.Log.Info("Set Pin 3 to high");
            //turn on pin 3
            shiftRegister.WriteToPin(shiftRegister.Pins.GP3, true);

            Resolver.Log.Info("Set Pin 4 to high");

            //get the port for Pin4
            var port4 = shiftRegister.CreateDigitalOutputPort(shiftRegister.Pins.GP4, true, Capsium.Hardware.OutputType.OpenDrain);

            Resolver.Log.Info("Toggle pin 4");

            await Task.Delay(1000);
            port4.State = false;
            await Task.Delay(1000);
            port4.State = true;
            await Task.Delay(1000);

            Resolver.Log.Info("Raise all pins to high");
            while (true)
            {
                shiftRegister.Clear();

                foreach (var pin in shiftRegister.Pins.AllPins)
                {
                    shiftRegister.WriteToPin(pin, true);
                    await Task.Delay(50);
                }
            }
        }

        //<!=SNOP=>
    }
}