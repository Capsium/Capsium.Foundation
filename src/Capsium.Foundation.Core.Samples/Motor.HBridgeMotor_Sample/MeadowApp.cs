﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Capsium;
using Capsium.Devices;
using Capsium.Foundation.Motors;
using Capsium.Units;

namespace Motor.HBridgeMotor_Sample
{
    public class CapsiumApp : App<F7FeatherV2>
    {
        //<!=SNIP=>

        protected HBridgeMotor motor1;

        public override Task Initialize()
        {
            Resolver.Log.Info("Initializing...");

            motor1 = new HBridgeMotor
            (
                a1Port: Device.CreatePwmPort(Device.Pins.D07, new Frequency(100, Frequency.UnitType.Hertz)),
                a2Port: Device.CreatePwmPort(Device.Pins.D08, new Frequency(100, Frequency.UnitType.Hertz)),
                enablePort: Device.CreateDigitalOutputPort(Device.Pins.D09)
            );

            return Task.CompletedTask;
        }

        public override async Task Run()
        {
            Resolver.Log.Info("TestMotor...");

            while (true)
            {
                // Motor Forwards
                motor1.Power = 1f;
                await Task.Delay(1000);

                // Motor Stops
                motor1.Power = 0f;
                await Task.Delay(500);

                // Motor Backwards
                motor1.Power = -1f;
                await Task.Delay(1000);
            }
        }

        //<!=SNOP=>
    }
}