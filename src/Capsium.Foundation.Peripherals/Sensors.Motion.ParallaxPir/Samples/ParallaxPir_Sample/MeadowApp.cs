using Capsium;
using Capsium.Devices;
using Capsium.Foundation.Sensors.Motion;
using Capsium.Hardware;
using System;
using System.Threading.Tasks;

namespace Sensors.Motion.ParallaxPir_Sample
{
    public class CapsiumApp : App<F7FeatherV2>
    {
        //<!=SNIP=>

        private ParallaxPir parallaxPir;

        public override Task Initialize()
        {
            Resolver.Log.Info("Initialize...");

            parallaxPir = new ParallaxPir(Device.CreateDigitalInterruptPort(Device.Pins.D05, InterruptMode.EdgeBoth, ResistorMode.Disabled));

            parallaxPir.OnMotionStart += (sender) => Resolver.Log.Info($"Motion start  {DateTime.Now}");
            parallaxPir.OnMotionEnd += (sender) => Resolver.Log.Info($"Motion end  {DateTime.Now}");

            return Task.CompletedTask;
        }

        //<!=SNOP=>
    }
}