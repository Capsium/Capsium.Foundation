﻿using Capsium;
using Capsium.Devices;
using Capsium.Foundation.Displays;
using Capsium.Foundation.Graphics;
using System.Threading.Tasks;

namespace Displays.Tft.Ssd1331_Sample
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

            var display = new St7796s
            (
                spiBus: spiBus,
                resetPin: Device.Pins.D00,
                chipSelectPin: Device.Pins.D02,
                dcPin: Device.Pins.D01,
                width: 320, height: 480
            );

            graphics = new MicroGraphics(display);
            graphics.CurrentFont = new Font8x8();

            return base.Initialize();
        }

        public override Task Run()
        {
            graphics.Clear();

            graphics.DrawTriangle(10, 10, 50, 50, 10, 50, Capsium.Foundation.Color.Red);
            graphics.DrawRectangle(20, 15, 40, 20, Capsium.Foundation.Color.Yellow, false);
            graphics.DrawText(5, 5, "Capsium F7");

            graphics.Show();

            return base.Run();
        }

        //<!=SNOP=>
    }
}