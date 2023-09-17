using Capsium;
using Capsium.Devices;
using Capsium.Foundation;
using Capsium.Foundation.Sensors.HallEffect;
using System;
using System.Threading.Tasks;

namespace Sensors.HallEffect_Sample
{
    public class CapsiumApp : App<F7FeatherV2>
    {
        //<!=SNIP=>

        private LinearHallEffectTachometer hallSensor;

        public override Task Initialize()
        {
            Resolver.Log.Info("Initializing...");

            hallSensor = new LinearHallEffectTachometer(
                inputPort: Device.CreateDigitalInterruptPort(Device.Pins.D02, Capsium.Hardware.InterruptMode.EdgeRising, Capsium.Hardware.ResistorMode.InternalPullUp, TimeSpan.Zero, TimeSpan.FromMilliseconds(1)),
                type: CircuitTerminationType.CommonGround,
                numberOfMagnets: 2,
                rpmChangeNotificationThreshold: 1);
            hallSensor.RPMsChanged += HallSensorRPMsChanged;

            Resolver.Log.Info("done");

            return Task.CompletedTask;
        }

        private void HallSensorRPMsChanged(object sender, ChangeResult<float> e)
        {
            Resolver.Log.Info($"RPM: {e.New}");
        }

        //<!=SNOP=>
    }
}