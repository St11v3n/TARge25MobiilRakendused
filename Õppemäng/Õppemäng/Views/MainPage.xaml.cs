
using Microsoft.Maui.Controls;
namespace Õppemäng
{
    public partial class MainPage : ContentPage
    {
        private Image image1;
        private Image image2;
        private Image image3;

        private Image dragimage1;
        private Image dragimage2;
        private Image dragimage3;

        private Label label1;
        private Label label2;
        private Label label3;

        private VerticalStackLayout layout1;
        private VerticalStackLayout layout2;
        private VerticalStackLayout layout3;

        private HorizontalStackLayout itemlayout;

        private Button StartBtn;

        private Button ThemeBtn;

        private Button StatisticsBtn;

        private Button EnglishBtn;

        private Button RussianBtn;

        private Button EstonianBtn;

        private HorizontalStackLayout buttonlayout;

        private HorizontalStackLayout languagelayout;

        private HorizontalStackLayout imagelayout;

        private VerticalStackLayout mainlayout;






        public MainPage()
        {
            

            image1 = new Image { Source = "", WidthRequest = 100, HeightRequest = 100 };


            image2 = new Image { Source = "", WidthRequest = 100, HeightRequest = 100 };


            image3 = new Image { Source = "", WidthRequest = 100, HeightRequest = 100 };


            label1 = new Label { Text = "" };

            label2 = new Label { Text = "" };

            label3 = new Label { Text = "" };


            dragimage1 = new Image { Source = "", WidthRequest = 100, HeightRequest = 100 };
            dragimage2 = new Image { Source = "", WidthRequest = 100, HeightRequest = 100 };
            dragimage3 = new Image { Source = "", WidthRequest = 100, HeightRequest = 100 };








            layout1 = new VerticalStackLayout { };

            layout2 = new VerticalStackLayout { };

            layout3 = new VerticalStackLayout { };


            itemlayout = new HorizontalStackLayout { };

            buttonlayout = new HorizontalStackLayout { };

            languagelayout = new HorizontalStackLayout { };

            imagelayout = new HorizontalStackLayout { };

            mainlayout = new VerticalStackLayout { };








            layout1.Add(image1);
            layout1.Add(label1);

            layout2.Add(image2);
            layout2.Add(label2);

            layout3.Add(image3);
            layout3.Add(label3);

            itemlayout.Add(layout1);
            itemlayout.Add(layout2);
            itemlayout.Add(layout3);

            buttonlayout.Add(StatisticsBtn);
            buttonlayout.Add(StartBtn);
            buttonlayout.Add(ThemeBtn);

            languagelayout.Add(EnglishBtn);
            languagelayout.Add(RussianBtn);
            languagelayout.Add(EstonianBtn);

            mainlayout.Add(languagelayout);
            mainlayout.Add(itemlayout);
            mainlayout.Add(imagelayout);
            mainlayout.Add(buttonlayout);

            this.Content = mainlayout;









        }


    }
}
