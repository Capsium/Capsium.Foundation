using Capsium;
using Capsium.Devices;
using Capsium.Foundation.Displays;
using Capsium.Foundation.Graphics;
using System.Threading.Tasks;

namespace Displays.ePaper.IL91874V03_Sample
{
    public class CapsiumApp : App<F7FeatherV2>
    {
        //<!=SNIP=>

        MicroGraphics graphics;

        public override Task Initialize()
        {
            Resolver.Log.Info("Initialize ...");

            var display = new Il91874V03(
                spiBus: Device.CreateSpiBus(),
                chipSelectPin: Device.Pins.D02,
                dcPin: Device.Pins.D01,
                resetPin: Device.Pins.D00,
                busyPin: Device.Pins.D03,
                width: 176,
                height: 264);

            graphics = new MicroGraphics(display);

            return base.Initialize();
        }

        public override Task Run()
        {
            graphics.DrawRectangle(1, 1, 126, 32, Capsium.Foundation.Color.Red, false);

            graphics.CurrentFont = new Font8x12();
            graphics.DrawText(2, 2, "IL91874V03", Capsium.Foundation.Color.Black);
            graphics.DrawText(2, 20, "Capsium F7", Capsium.Foundation.Color.Black);

            graphics.Show();

            return Task.CompletedTask;
        }

        //<!=SNOP=>
    }
}