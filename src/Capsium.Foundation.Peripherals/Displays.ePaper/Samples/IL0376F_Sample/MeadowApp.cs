﻿using Capsium;
using Capsium.Devices;
using Capsium.Foundation.Displays;
using Capsium.Foundation.Graphics;
using System.Threading.Tasks;

namespace Displays.ePaper.IL0376F_Sample
{
    public class CapsiumApp : App<F7FeatherV2>
    {
        //<!=SNIP=>

        MicroGraphics graphics;

        public override Task Initialize()
        {
            Resolver.Log.Info("Initialize ...");

            var display = new Il0376F(
                spiBus: Device.CreateSpiBus(),
                chipSelectPin: Device.Pins.D02,
                dcPin: Device.Pins.D01,
                resetPin: Device.Pins.D00,
                busyPin: Device.Pins.D03,
                width: 200,
                height: 200);

            graphics = new MicroGraphics(display);

            return Task.CompletedTask;
        }

        public override Task Run()
        {
            //any color but black will show the ePaper alternate color 
            graphics.DrawRectangle(1, 1, 126, 32, Capsium.Foundation.Color.Red, false);

            graphics.CurrentFont = new Font8x12();
            graphics.DrawText(2, 2, "IL0376F", Capsium.Foundation.Color.Black);
            graphics.DrawText(2, 20, "Capsium F7", Capsium.Foundation.Color.Black);

            graphics.Show();

            return Task.CompletedTask;
        }

        //<!=SNOP=>
    }
}