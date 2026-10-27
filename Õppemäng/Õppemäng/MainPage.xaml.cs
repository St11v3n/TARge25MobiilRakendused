namespace Õppemäng
{
    public partial class MainPage : ContentPage
    {
        

        private CarouselView carouselView;

        private IndicatorView indicatorView;

        private Button Themebtn;

        

        public MainPage()
        {
            carouselView = new CarouselView
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                IndicatorView = indicatorView
            };

            indicatorView = new IndicatorView
            {
                IndicatorColor = Colors.Black,
                SelectedIndicatorColor = Colors.Gray,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            carouselView.ItemTemplate = new DataTemplate(() =>
            {
                Label wordLabel = new Label
                {

                };

                Image imageslot = new Image
                {
                    WidthRequest = 100,
                    HeightRequest = 100
                };   



            });

            

            


        }

        
    }
}
