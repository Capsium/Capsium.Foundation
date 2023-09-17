using Capsium;
using Capsium.Devices;
using Capsium.Foundation.Sensors.Switches;
using Capsium.Hardware;
using Capsium.Peripherals.Switches;
using System.Threading.Tasks;

namespace Sensors.Switches.DipSwitch_Sample
{
    public class CapsiumApp : App<F7FeatherV2>
    {
        //<!=SNIP=>

        protected DipSwitch dipSwitch;

        public override Task Initialize()
        {
            Resolver.Log.Info("Initializing...");

            IDigitalInterruptPort[] ports =
            {
                Device.CreateDigitalInterruptPort(Device.Pins.D06, InterruptMode.EdgeRising, ResistorMode.InternalPullDown),
            };

            dipSwitch = new DipSwitch(ports);
            dipSwitch.Changed += (s, e) =>
            {
                Resolver.Log.Info("Switch " + e.ItemIndex + " changed to " + (((ISwitch)e.Item).IsOn ? "on" : "off"));
            };

            Resolver.Log.Info("DipSwitch...");

            return Task.CompletedTask;
        }

        //<!=SNOP=>
    }
}