
using ProgrammingLanguagePortfoolio.Resources.Localization;
using ProgrammingLanguagePortfoolio.Viewmodels;
using ProgrammingLanguagePortfoolio.Services;
using ProgrammingLanguagePortfoolio.Models;
using System.Runtime.CompilerServices;


namespace ProgrammingLanguagePortfoolio
{
    
    
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel _viewModel = new MainViewModel();

        private Button viewCodeButton;
        private CarouselView carouselView;

        private bool _isTimerRunning = false;

        public MainPage()
        {
            

            BindingContext = _viewModel;

            IndicatorView indicatorView = new IndicatorView
            {
                IndicatorColor = Colors.Gray,
                SelectedIndicatorColor = Colors.Blue,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            carouselView = new CarouselView
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                IndicatorView = indicatorView
               
            };

            carouselView.SetBinding(CarouselView.ItemsSourceProperty, "Items");
            

            Button englishButton = new Button
            {
                Text = "English",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            englishButton.Clicked += OnEnglishButtonClicked;

            Button estonianButton = new Button
            {
                Text = "Estonian",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            estonianButton.Clicked += OnEstonianButtonClicked;

            Button russianButton = new Button
            {
                Text = "Russian",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            russianButton.Clicked += OnRussianButtonClicked;

            viewCodeButton = new Button
            {
                Text = AppResources.ButtonText,
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

                Button cardButton = new Button
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };

                Image image = new Image
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    HeightRequest = 100,
                    WidthRequest = 100
                };

                image.SetBinding(Image.SourceProperty, "ImageUrl");
                label1.SetBinding(Label.TextProperty, "Title");
                label2.SetBinding(Label.TextProperty, "Description");
                cardButton.SetBinding(Button.TextProperty, "ButtonText");

                cardButton.Clicked += OnViewCodeButtonClicked;

                VerticalStackLayout cardLayout = new VerticalStackLayout
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Spacing = 15,
                    Padding = new Thickness(20),
                    WidthRequest = 320
                };

                cardLayout.Add(image);
                cardLayout.Add(label1);
                cardLayout.Add(label2);
                cardLayout.Add(cardButton);

                return cardLayout;
            });

               
                

            Grid grid = new Grid
            {
                RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition { Height = GridLength.Auto }, 
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }, 
                new RowDefinition { Height = GridLength.Auto }  
            },
                Margin = new Thickness(10)
            };

            HorizontalStackLayout languageBar = new HorizontalStackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                Spacing = 10,
                Children = { englishButton, estonianButton, russianButton },
                Margin = new Thickness(0, 10, 0, 20)
            };

            grid.Add(languageBar, 0, 0);
            grid.Add(carouselView, 0, 1);
            grid.Add(indicatorView, 0, 2);

            Content = grid;

            StartSafeUiTimer();


        }

        private void StartSafeUiTimer()
        {
           
            if (_isTimerRunning) return;
            _isTimerRunning = true;

            Application.Current.Dispatcher.StartTimer(TimeSpan.FromSeconds(4), () =>
            {
                if (_viewModel.Items.Count == 0) return true;

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    int nextPosition = (carouselView.Position + 1) % _viewModel.Items.Count;
                    carouselView.ScrollTo(nextPosition, position: ScrollToPosition.Center, animate: true);
                });

                return true;
            });
        }


        private async void OnViewCodeButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;

           
            if (button?.BindingContext is CarouselItem selectedItem)
            {
                
                await DisplayAlert(selectedItem.Title, selectedItem.ViewCode, "OK");
            }
        }


        public async void OnEnglishButtonClicked(object sender, EventArgs e)
        {
            _viewModel.ChangeLanguage("en");

            
            await Task.Delay(100);

            
            carouselView.ScrollTo(0, position: ScrollToPosition.Center, animate: true);
            
            viewCodeButton.Text = AppResources.ButtonText;
        }

        public async void OnEstonianButtonClicked(object sender, EventArgs e)
        {
            _viewModel.ChangeLanguage("et");

            await Task.Delay(100);

            carouselView.ScrollTo(0, position: ScrollToPosition.Center, animate: true);
            
            viewCodeButton.Text = AppResources.ButtonText;
        }

        public async void OnRussianButtonClicked(object sender, EventArgs e)
        {
            _viewModel.ChangeLanguage("ru");

            await Task.Delay(100);

            carouselView.ScrollTo(0, position: ScrollToPosition.Center, animate: true);
            
            viewCodeButton.Text = AppResources.ButtonText;
        }







    }
}
