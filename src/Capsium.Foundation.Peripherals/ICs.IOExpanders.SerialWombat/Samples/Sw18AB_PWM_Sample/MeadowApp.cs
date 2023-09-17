using Capsium;
using Capsium.Devices;
using Capsium.Foundation.ICs.IOExpanders;
using Capsium.Hardware;
using System;
using System.Threading.Tasks;

namespace ICs.IOExpanders.Sw18AB_PWM_Sample
{
    public class CapsiumApp : App<F7FeatherV2>
    {
        //<!=SNIP=>

        private Sw18AB serialWombat;
        private IPwmPort pwmPort;

        public override Task Initialize()
        {
            Resolver.Log.Info("Initialize...");

            try
            {
                Resolver.Log.Info(" creating Wombat...");
                serialWombat = new Sw18AB(Device.CreateI2cBus());
                Resolver.Log.Info(" creating PWM...");
                pwmPort = serialWombat.CreatePwmPort(serialWombat.Pins.WP0, new Capsium.Units.Frequency(1, Capsium.Units.Frequency.UnitType.Hertz));
            }
            catch (Exception ex)
            {
                Resolver.Log.Error($"error: {ex.Message}");
            }

            return Task.CompletedTask;
        }

        public override async Task Run()
        {
            Resolver.Log.Info("Running...");

            pwmPort.Start();

            for (int i = 1; i < 1000; i += 10)
            {
                Resolver.Log.Info($"{i}Hz");
                pwmPort.Frequency = new Capsium.Units.Frequency(i, Capsium.Units.Frequency.UnitType.Hertz);
                await Task.Delay(2000);
            }

            pwmPort.Stop();
        }

        //<!=SNOP=>
    }
}