﻿using Capsium;
using Capsium.Devices;
using Capsium.Foundation.Displays;
using Capsium.Foundation.Graphics;
using System.Threading.Tasks;

namespace Displays.Tft.Ili9163_Sample
{
    public class CapsiumApp : App<F7FeatherV2>
    {
        //<!=SNIP=>

        MicroGraphics graphics;

        public override Task Initialize()
        {
            Resolver.Log.Info("Initializing ...");

            var spiBus = Device.CreateSpiBus();

            Resolver.Log.Info("Create display driver instance");

            var display = new Ili9163
            (
                spiBus: spiBus,
                chipSelectPin: Device.Pins.D02,
                dcPin: Device.Pins.D01,
                resetPin: Device.Pins.D00,
                width: 128, height: 160
            );

            graphics = new MicroGraphics(display)
            {
                IgnoreOutOfBoundsPixels = true,
                CurrentFont = new Font8x8()
            };


            return base.Initialize();
        }

        public override Task Run()
        {
            graphics.Clear();

            graphics.DrawTriangle(10, 10, 50, 50, 10, 50, Capsium.Foundation.Color.Red);
            graphics.DrawRectangle(20, 15, 40, 20, Capsium.Foundation.Color.Yellow, false);
            graphics.DrawCircle(50, 50, 40, Capsium.Foundation.Color.Blue, false);
            graphics.DrawText(5, 5, "Capsium F7");

            graphics.Show();

            return base.Run();
        }

        //<!=SNOP=>
    }
}