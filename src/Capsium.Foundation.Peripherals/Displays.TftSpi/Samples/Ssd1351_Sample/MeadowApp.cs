using Capsium;
using Capsium.Devices;
using Capsium.Foundation.Displays;
using Capsium.Foundation.Graphics;
using System.Threading.Tasks;

namespace BasicDisplays.Tft.Ssd1351_Sample
{
    public class CapsiumApp : App<F7FeatherV2>
    {
        //<!=SNIP=>

        MicroGraphics graphics;

        public override Task Initialize()
        {
            Resolver.Log.Info("Initializing ...");

            var spiBus = Device.CreateSpiBus();

            var display = new Ssd1351(
                spiBus: spiBus,
                chipSelectPin: Device.Pins.D02,
                dcPin: Device.Pins.D01,
                resetPin: Device.Pins.D00,
                width: 128, height: 128);

            graphics = new MicroGraphics(display)
            {
                CurrentFont = new Font8x12(),
                IgnoreOutOfBoundsPixels = true
            };

            return base.Initialize();
        }

        public override Task Run()
        {
            graphics.Clear();

            graphics.DrawCircle(80, 80, 40, Capsium.Foundation.Color.Cyan, false);

            int indent = 0;
            int spacing = 10;
            int y = indent;

            graphics.DrawText(indent, y, "Capsium F7 (SSD1351)");

            graphics.DrawText(indent, y += spacing, "Red", Capsium.Foundation.Color.Red);
            graphics.DrawText(indent, y += spacing, "Purple", Capsium.Foundation.Color.Purple);
            graphics.DrawText(indent, y += spacing, "BlueViolet", Capsium.Foundation.Color.BlueViolet);
            graphics.DrawText(indent, y += spacing, "Blue", Capsium.Foundation.Color.Blue);
            graphics.DrawText(indent, y += spacing, "Cyan", Capsium.Foundation.Color.Cyan);
            graphics.DrawText(indent, y += spacing, "LawnGreen", Capsium.Foundation.Color.LawnGreen);
            graphics.DrawText(indent, y += spacing, "GreenYellow", Capsium.Foundation.Color.GreenYellow);
            graphics.DrawText(indent, y += spacing, "Yellow", Capsium.Foundation.Color.Yellow);
            graphics.DrawText(indent, y += spacing, "Orange", Capsium.Foundation.Color.Orange);
            graphics.DrawText(indent, y += spacing, "Brown", Capsium.Foundation.Color.Brown);

            graphics.Show();

            return base.Run();
        }

        //<!=SNOP=>
    }
}