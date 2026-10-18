using Programming_Language_portfolio.Resources.Localization;
using Programming_Language_portfolio.ViewModels;
using Programming_Language_portfolio.Services;
using System.Globalization;

namespace Programming_Language_portfolio
{
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();

            _viewModel = new MainViewModel();
            BindingContext = _viewModel;

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
                ItemTemplate = cardTemplate,
                Loop = true,
                IndicatorView = indicatorView
            };

            carouselView.SetBinding(CarouselView.ItemsSourceProperty, "PortfolioItems");
            carouselView.SetBinding(CarouselView.CurrentItemProperty, "CurrentCard", BindingMode.TwoWay);

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
            Programming_Language_portfolio.ViewModels.MainViewModel.IsPageAlive = false;

            var targetCulture = new CultureInfo(langCode);
            Thread.CurrentThread.CurrentCulture = targetCulture;
            Thread.CurrentThread.CurrentUICulture = targetCulture;

            Application.Current.MainPage = new MainPage();
        }
    }
}