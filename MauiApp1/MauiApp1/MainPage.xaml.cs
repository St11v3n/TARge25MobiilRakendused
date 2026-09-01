namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
            ResetBtn.Text = $"Tagasi nulli";
            BotImage.Rotation += 10;

           

            // Genereerime juhusliku värvi
            var random = new Random();
            var randomColor = Color.FromRgb(random.Next(256), random.Next(256), random.Next(256));
            ResetBtn.BackgroundColor = randomColor;

            if (count >= 10)
            {
                BotImage.IsVisible = false;
            }

            if (count >= 5)
            {
                CounterBtn.BackgroundColor = Colors.Red;
                CounterBtn.TextColor = Colors.White;

            }
            BotImage.Opacity -= 0.1;
            BotImage.Scale += 0.1;
            CounterBtn.CornerRadius = 20;
        }



        private void ResetBtn_Clicked(object sender, EventArgs e)
        {
            count = 0;
            CounterBtn.Text = $"Clicked {count} times";
            ResetBtn.Text = $"Reset oli tehtud";
            BotImage.IsVisible = true;
            CounterBtn.BackgroundColor = Colors.Blue;
            CounterBtn.TextColor = Colors.LightGray;

            if (BotImage.HorizontalOptions == LayoutOptions.Start)
            {
                BotImage.HorizontalOptions = LayoutOptions.End;
            }
            else
            {
                BotImage.HorizontalOptions = LayoutOptions.Start;
            }
        }
    }
}
