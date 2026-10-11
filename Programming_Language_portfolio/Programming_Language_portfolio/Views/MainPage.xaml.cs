using Programming_Language_portfolio.ViewModels;
using Programming_Language_portfolio.Resources.Localization;
using System.Globalization;

namespace Programming_Language_portfolio
{
    public partial class MainPage : ContentPage
    {
        public class CarouselItem
        {
            public string Title { get; set; }
            public string ImageUrl { get; set; }
            public string Description { get; set; }
            public string HelloWorldCode { get; set; }
            public string ButtonText { get; set; }
        }

        public MainPage()
        {
            InitializeComponent();




            var items = new List<CarouselItem>()
            {
                new CarouselItem
                {
                    Title = "C#",
                    ImageUrl = "c_sharp_logo.png",
                    Description = AppResources.CSharpDesc,
                    HelloWorldCode = "Console.WriteLine(\"Hello, World!\");",
                    ButtonText = AppResources.ButtonText
                },

                new CarouselItem
                {
                    Title = "Python",
                    ImageUrl = "python_logo.jpg",
                    Description =  AppResources.PythonDesc,
                    HelloWorldCode = "print(\"Hello, World!\")",
                    ButtonText = AppResources.ButtonText
                },

                new CarouselItem
                {
                    Title = "JavaScript",
                    ImageUrl = "javascript_logo.png",
                    Description = AppResources.JSDesc,
                    HelloWorldCode = "console.log(\"Hello, World!\");",
                    ButtonText = AppResources.ButtonText
                },

                new CarouselItem
                {
                    Title = "C++",
                    ImageUrl = "c_plus_plus_logo.jpg",
                    Description = AppResources.CppDesc,
                    HelloWorldCode = "std::cout << \"Hello, World!\";",
                    ButtonText = AppResources.ButtonText
                },
            };

            
            int currentCardIndex = 0;

            
            var cardTemplate = new DataTemplate(() =>
            {
                var cardGrid = new Grid
                {
                    Padding = new Thickness(15),
                    RowSpacing = 10,
                   
                    RowDefinitions = new RowDefinitionCollection
                    {
                        new RowDefinition { Height = new GridLength(100) }, 
                        new RowDefinition { Height = GridLength.Auto },    
                        new RowDefinition { Height = GridLength.Star },     
                        new RowDefinition { Height = GridLength.Auto }      
                    }
                };

                var image = new Image { HeightRequest = 100 };
                var titleLabel = new Label { FontSize = 24, HorizontalOptions = LayoutOptions.Center };
                var descLabel = new Label { FontSize = 14, HorizontalOptions = LayoutOptions.Center };
                var codeButton = new Button { Text = AppResources.ButtonText, HorizontalOptions = LayoutOptions.Center };

                image.SetBinding(Image.SourceProperty, "ImageUrl");
                titleLabel.SetBinding(Label.TextProperty, "Title");
                descLabel.SetBinding(Label.TextProperty, "Description");
                codeButton.SetBinding(Button.TextProperty, "ButtonText");

                codeButton.Clicked += (sender, e) =>
                {
                    var clickedLanguage = codeButton.BindingContext as CarouselItem;

                    if (clickedLanguage != null)
                    {
                        DisplayAlert(clickedLanguage.Title, clickedLanguage.HelloWorldCode, "OK");
                    }
                };

                Grid.SetRow(image, 0);
                Grid.SetRow(titleLabel, 1);
                Grid.SetRow(descLabel, 2);
                Grid.SetRow(codeButton, 3);

                cardGrid.Children.Add(image);
                cardGrid.Children.Add(titleLabel);
                cardGrid.Children.Add(descLabel);
                cardGrid.Children.Add(codeButton);

                return cardGrid;

                
            });

            
            var indicatorView = new IndicatorView
            {
                HorizontalOptions = LayoutOptions.Center,
                IndicatorColor = Colors.Gray,
                SelectedIndicatorColor = Colors.Purple,
                Margin = new Thickness(0, 10, 0, 0)
            };

            
            var carouselView = new CarouselView
            {
                ItemsSource = items,
                ItemTemplate = cardTemplate,
                Loop = true, 
                IndicatorView = indicatorView,
                
            };

            
            Dispatcher.StartTimer(TimeSpan.FromSeconds(4), () =>
            {
                currentCardIndex = currentCardIndex + 1;
                if (currentCardIndex >= items.Count) currentCardIndex = 0; 

                carouselView.CurrentItem = items[currentCardIndex];
                return true;
            });

            
            

            var englishButton = new Button { Text = "English", Margin = 5 };
            var estonianButton = new Button { Text = "Eesti", Margin = 5 };
            var russianButton = new Button { Text = "Русский", Margin = 5 };

            englishButton.Clicked += (sender, e) => ChangeLanguage("");

            estonianButton.Clicked += (sender, e) => ChangeLanguage("et");

            russianButton.Clicked += (sender, e) => ChangeLanguage("ru");

            var languageLayout = new HorizontalStackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 20, 0, 0)
            };
            languageLayout.Add(englishButton);
            languageLayout.Add(estonianButton);
            languageLayout.Add(russianButton);


            var mainLayout = new VerticalStackLayout
            {
                Padding = 20,
                Spacing = 15,
                VerticalOptions = LayoutOptions.Center
            };

            mainLayout.Add(carouselView);
            mainLayout.Add(indicatorView);
            mainLayout.Add(languageLayout); 

            Content = mainLayout;
        }

        
        private void ChangeLanguage(string langCode)
        {
            
            var targetCulture = new CultureInfo(langCode);
            Thread.CurrentThread.CurrentCulture = targetCulture;
            Thread.CurrentThread.CurrentUICulture = targetCulture;
            Application.Current.MainPage = new ContentPage();
            Application.Current.MainPage = new MainPage();
        }


           
        
    }
}