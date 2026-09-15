using Microsoft.Maui.Controls.Handlers.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace MauiApp1
{
    public partial class StartPage : ContentPage
    {
        VerticalStackLayout vst;
        ScrollView sv;
        public List<ContentPage> Lehed = new List<ContentPage>() { new TextPage(), new FigurePage(), new Timer_Page(), new DateTime_Page(), new StepperSliderPage()};
        public List<string> Lehenimed = new List<string>() { "Testid", "Kujundus" };
        public StartPage()
        {
            //Title "Avaleht";
            vst=new VerticalStackLayout { Padding = 20, Spacing = 15 };
            for (int i=0; i < Lehed.Count; i++ )
            {
                Button nupp = new Button
                {
                    Text = Lehenimed[i],
                    FontSize = 36,
                    FontFamily = "Luculine",
                    BackgroundColor = Colors.LightGray,
                    TextColor = Colors.Black,
                    CornerRadius = 10,
                    HeightRequest = 60,
                    ZIndex = i
                };

                vst.Add(nupp);
                nupp.Clicked += (sender, e) =>
                {
                    var valik = Lehed[nupp.ZIndex];
                    Navigation.PushAsync(valik);
                };
            }
            sv=new ScrollView { Content = vst };
            Content = sv;
        }
    }
}
