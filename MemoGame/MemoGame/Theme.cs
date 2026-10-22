using System;
using System.Collections.Generic;
using System.Text;

namespace MemoGame
{
    public class Theme
    {
        public string ThemeName { get; set; }
        public Color BackgroundColor { get;  set; }
        public Color ButtonColor { get;  set; }
        public Color TextColor { get;  set; }

        public Theme(string name, Color bg, Color btn, Color text)
        {
            ThemeName = name;
            BackgroundColor = bg;
            ButtonColor = btn;
            TextColor = text;
        }

        public void Apply(ContentPage page, Button start, Button stats, Button theme)
        {
           
            page.BackgroundColor = BackgroundColor;

            
            start.BackgroundColor = ButtonColor;
            start.TextColor = TextColor;

            stats.BackgroundColor = ButtonColor;
            stats.TextColor = TextColor;

            theme.BackgroundColor = ButtonColor;
            theme.TextColor = TextColor;

            


        }
    }


}
