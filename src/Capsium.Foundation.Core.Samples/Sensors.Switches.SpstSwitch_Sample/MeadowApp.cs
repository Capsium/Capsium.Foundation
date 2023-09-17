using Capsium;
using Capsium.Devices;
using Capsium.Foundation.Sensors.Switches;
using Capsium.Hardware;
using System.Threading.Tasks;

namespace Sensors.Switches.SpstSwitch_Sample
{
    public class CapsiumApp : App<F7FeatherV2>
    {
        //<!=SNIP=>

        protected SpstSwitch spstSwitch;

        public override Task Initialize()
        {
            Resolver.Log.Info("Initializing...");

            spstSwitch = new SpstSwitch(Device.CreateDigitalInterruptPort(Device.Pins.D02, InterruptMode.EdgeFalling, ResistorMode.InternalPullDown));
            spstSwitch.Changed += (s, e) =>
            {
                Resolver.Log.Info("Switch Changed");
                Resolver.Log.Info($"Switch on: {spstSwitch.IsOn}");
            };

            Resolver.Log.Info("SpstSwitch ready...");

            return Task.CompletedTask;
        }

        //<!=SNOP=>
    }
}