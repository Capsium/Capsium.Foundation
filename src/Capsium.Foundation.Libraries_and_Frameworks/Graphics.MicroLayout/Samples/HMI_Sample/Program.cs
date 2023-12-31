﻿using Capsium.Foundation.Graphics;
using Capsium.Foundation.Graphics.MicroLayout;
using System.Windows.Forms;

namespace Capsium.Foundation.Displays.UI;

public class CapsiumApp : App<Windows>
{
    private DisplayScreen _screen;

    public static async Task Main(string[] args)
    {
        ApplicationConfiguration.Initialize();
        await CapsiumOS.Start(args);
    }

    public override Task Run()
    {
        var display = new WinFormsDisplay();
        display.ControlBox = true;

        var labelFont = new Font12x20();

        _screen = new DisplayScreen(display);
        _screen.BackgroundColor = Color.AntiqueWhite;

        var splashLayout = new AbsoluteLayout(_screen, 0, 0, _screen.Width, _screen.Height)
        {
            //            BackgroundColor = Color.Blue
        };

        var logo = Graphics.Image.LoadFromFile("logo.bmp");
        var wlLabel = new DisplayLabel(0, 10, _screen.Width, 32)
        {
            TextColor = Color.White,
            BackColor = Color.DarkRed,
            Text = "Hello Capsium"
        };
        var logoImg = new Graphics.MicroLayout.Picture(
                0, 0,
                _screen.Width,
                _screen.Height,
                logo
            );
        splashLayout.Controls.Add(logoImg, wlLabel);



        var chartLayout = new AbsoluteLayout(_screen, 0, 0, _screen.Width, _screen.Height);

        var chart1Label = new DisplayLabel(0, 0, _screen.Width, 16)
        {
            Text = "Values for process A",
            TextColor = Color.Aquamarine,
            BackColor = Color.Black,
            Font = labelFont,
        };

        var chart1 = new LineChart(0, 16, _screen.Width, (_screen.Height / 2) - 16)
        {
            BackgroundColor = Color.FromHex("111111"),
            ShowYAxisLabels = true
        };

        chart1.Series.Add(
            GetSineSeries(),
            GetCosineSeries(4, 4.2, 0));

        var chart2Label = new DisplayLabel(0, _screen.Height / 2, _screen.Width, 16)
        {
            Text = "Values for process B",
            TextColor = Color.BlueViolet,
            BackColor = Color.Black,
            Font = labelFont,
        };

        var chart2 = new LineChart(0, (_screen.Height / 2) + 16, _screen.Width, (_screen.Height / 2) - 16)
        {
            BackgroundColor = Color.FromHex("222222"),
            ShowYAxisLabels = true
        };

        chart2.Series.Add(
            GetSineSeries(2, 2),
            GetCosineSeries(4, 4.2, 4.5));

        chartLayout.Controls.Add(chart1Label, chart2Label, chart1, chart2);

        _screen.Controls.Add(splashLayout, chartLayout);

        chartLayout.Visible = false;

        Task.Run(async () =>
        {
            await Task.Delay(5000);
            splashLayout.Visible = false;
            chartLayout.Visible = true;
        });
        Application.Run(display);

        return base.Run();
    }

    private const int PointsPerSeries = 50;

    private LineChartSeries GetSineSeries(double xScale = 4, double yScale = 1.5, double yOffset = 1.5)
    {
        var series = new LineChartSeries()
        {
            LineColor = Color.Red,
            PointColor = Color.Green,
            LineStroke = 4,
            PointSize = 6,
            ShowLines = true,
            ShowPoints = true,

        };

        for (var p = 0; p < PointsPerSeries; p++)
        {
            series.Points.Add(p * 2, (Math.Sin(p / xScale) * yScale) + yOffset);
        }

        return series;
    }

    private LineChartSeries GetCosineSeries(double xScale = 4, double yScale = 1.5, double yOffset = 4.5)
    {
        var series = new LineChartSeries()
        {
            LineColor = Color.DarkBlue,
            PointColor = Color.DarkGreen,
            LineStroke = 4,
            PointSize = 6,
            ShowLines = true,
            ShowPoints = true,

        };

        for (var p = 0; p < PointsPerSeries; p++)
        {
            series.Points.Add(p * 2, (Math.Cos(p / xScale) * yScale) + yOffset);
        }

        return series;
    }
}
