using Capsium;
using Capsium.Devices;
using Capsium.Foundation.Sensors.Motion;
using System;
using System.Threading.Tasks;

namespace Sensors.Motion.ParallaxPir_Sample
{
    public class CapsiumApp : App<F7FeatherV2>
    {
        //<!=SNIP=>

        private Hcsens0040 sensor;

        public override Task Initialize()
        {
            Resolver.Log.Info("Initialize...");

            sensor = new Hcsens0040(Device.CreateDigitalInterruptPort(Device.Pins.D05, Capsium.Hardware.InterruptMode.EdgeBoth));
            sensor.OnMotionDetected += Sensor_OnMotionDetected;

            return Task.CompletedTask;
        }

        private void Sensor_OnMotionDetected(object sender)
        {
            Resolver.Log.Info($"Motion detected {DateTime.Now}");
        }

        //<!=SNOP=>
    }
}