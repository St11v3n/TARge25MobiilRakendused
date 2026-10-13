using System;
using System.Collections.Generic;
using System.Text;

namespace MemoGame
{
    public class Game
    {
        public Game()
        {
            VerticalStackLayout stacklayout = new VerticalStackLayout()
            {
                Spacing = 20,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            Button startbtn = new Button()
            {
                Text = "Start",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

            };

            Grid grid = new Grid()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
        }
    }
}
