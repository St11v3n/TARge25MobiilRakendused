using Microsoft.Maui.Controls.Handlers.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace MauiApp1
{
    public partial class StartPage : ContentPage
    {
        VerticalStackLayout vst;
        public List<ContentPage> Lehed = new List<ContentPage>() { new TextPage(), new FigurePage()};
        public List<string> Lehenimed = new List<string>() { "Testid", "Kujundus" };
        public StartPage()
        {
            //Title "Avaleht";
            vst = new VerticalStackLayout(Padding = 20, Spacing = 15);
            for (int i=8)
        }
    }
}
