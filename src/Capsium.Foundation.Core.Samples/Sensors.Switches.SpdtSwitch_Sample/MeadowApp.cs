using Capsium;
using Capsium.Devices;
using Capsium.Foundation.Sensors.Switches;
using Capsium.Hardware;
using System;
using System.Threading.Tasks;

namespace Sensors.Switches.SpdtSwitch_Sample
{
    public class CapsiumApp : App<F7FeatherV2>
    {
        //<!=SNIP=>

        protected SpdtSwitch spdtSwitch;

        public override Task Initialize()
        {
            Resolver.Log.Info("Initializing...");

            spdtSwitch = new SpdtSwitch(Device.CreateDigitalInterruptPort(Device.Pins.D15, InterruptMode.EdgeBoth, ResistorMode.InternalPullDown));
            spdtSwitch.Changed += (s, e) =>
            {
                Resolver.Log.Info(spdtSwitch.IsOn ? "Switch is on" : "Switch is off");
            };

            Resolver.Log.Info("SpdtSwitch ready...");

            return Task.CompletedTask;
        }

        //<!=SNOP=>
    }
}