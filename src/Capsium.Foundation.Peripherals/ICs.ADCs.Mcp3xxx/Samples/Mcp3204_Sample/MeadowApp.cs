﻿using Capsium;
using Capsium.Devices;
using Capsium.Foundation.ICs.IOExpanders;
using Capsium.Hardware;
using Capsium.Units;
using System;
using System.Threading.Tasks;

namespace ICs.IOExpanders.Mcp3204_Sample
{
    public class CapsiumApp : App<F7FeatherV2>
    {
        //<!=SNIP=>

        Mcp3204 mcp;

        IAnalogInputPort port;

        public override Task Initialize()
        {
            Resolver.Log.Info("Initialize");

            IDigitalOutputPort chipSelectPort = Device.CreateDigitalOutputPort(Device.Pins.D01);

            mcp = new Mcp3204(Device.CreateSpiBus(), chipSelectPort);

            port = mcp.CreateAnalogInputPort(mcp.Pins.CH0, 32, TimeSpan.FromSeconds(1), new Voltage(3.3, Voltage.UnitType.Volts), Mcp3xxx.InputType.SingleEnded);

            port.Updated += (s, result) =>
            {
                Console.WriteLine($"Analog event, new voltage: {result.New.Volts:N2}V, old: {result.Old?.Volts:N2}V");
            };

            var observer = IAnalogInputPort.CreateObserver(
                handler: result =>
                {
                    Resolver.Log.Info($"Analog observer triggered; new: {result.New.Volts:n2}V, old: {result.Old?.Volts:n2}V");
                },
                filter: result =>
                {
                    if (result.Old is { } oldValue)
                    {
                        return (result.New - oldValue).Abs().Volts > 0.1;
                    }
                    else { return false; }
                }
            );
            port.Subscribe(observer);

            return base.Initialize();
        }

        public override Task Run()
        {
            Resolver.Log.Info("Run");

            port.StartUpdating();

            return Task.CompletedTask;
        }

        //<!=SNOP=>
    }
}