using System.Runtime.CompilerServices;

namespace ProgrammingLanguagePortfoolio
{
    public class CarouselItem
    {
        public string Title { get; set; }
        
        public string Description { get; set;}

        public string ViewCode { get; set; }

        public string ButtonText { get; set; }

        public string ImageUrl { get; set; }
    }
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();

            var items = new List<CarouselItem>
            {
                new CarouselItem
                {
                    Title = "C#",

                    Description = "",

                    ViewCode = "",

                    ButtonText = "",

                    ImageUrl = ""
                },

                new CarouselItem
                {
                    Title = "Python",

                    Description = "",

                    ViewCode = "",

                    ButtonText = "",

                    ImageUrl = ""
                },

                new CarouselItem
                {
                    Title = "C++",

                    Description = "",

                    ViewCode = "",

                    ButtonText = "",

                    ImageUrl = ""
                },

                new CarouselItem
                {
                    Title = "JavaScript",

                    Description = "",

                    ViewCode = "",

                    ButtonText = "",

                    ImageUrl = ""
                },

                new CarouselItem
                {
                    Title = "TypeScript",

                    Description = "",

                    ViewCode = "",

                    ButtonText = "",

                    ImageUrl = ""
                }
            };

            IndicatorView indicatorView = new IndicatorView
            {
                IndicatorColor = Colors.Gray,
                SelectedIndicatorColor = Colors.Blue,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            CarouselView carouselView = new CarouselView
            {
                ItemsSource = items,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            Button englishButton = new Button
            {
                Text = "English",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            Button estonianButton = new Button
            {
                Text = "Estonian",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            Button russianButton = new Button
            {
                Text = "Russian",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            Button viewCodeButton = new Button
            {
                Text = "View Code",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            carouselView.ItemTemplate = new DataTemplate(() =>
            {
                Label label1 = new Label
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };

                Label label2 = new Label
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };

                Label label3 = new Label
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };

                Image image = new Image
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };

                image.SetBinding(Image.SourceProperty, "ImageUrl");
                label1.SetBinding(Label.TextProperty, "Title");
                label2.SetBinding(Label.TextProperty, "Description");
                label3.SetBinding(Label.TextProperty, "ButtonText");

                Grid grid = new Grid
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };

                grid.Add(image);
                grid.Add(label1);
                grid.Add(label2);
                grid.Add(label3);

                return grid;




            });

            StackLayout layout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            layout.Add(carouselView);
            layout.Add(indicatorView);



        }


            


        public void OnEnglishButtonClicked(object sender, EventArgs e)
        {

        }

        public void OnEstonianButtonClicked(object sender, EventArgs e)
        {

        }

        public void OnRussianButtonClicked(object sender, EventArgs e)
        {

        }

        public void OnViewCodeButtonClicked(object sender, EventArgs e)
        {

        }



        



    }
}
