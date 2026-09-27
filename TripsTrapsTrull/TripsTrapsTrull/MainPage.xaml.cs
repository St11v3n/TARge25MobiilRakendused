namespace TripsTrapsTrull
{
    public partial class MainPage : ContentPage
    {
        / Link to our separate OOP Logic file
        GameLogic logic = new GameLogic();

       
        Button b1, b2, b3, b4, b5, b6, b7, b8, b9;
        Label infoSilt;

        public MainPage()
        {
            InitializeComponent();

            
            Grid grid = new Grid { HeightRequest = 300, WidthRequest = 300 };
            for (int i = 0; i < 3; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            }

            
            b1 = LooNupp(0, 0); b2 = LooNupp(0, 1); b3 = LooNupp(0, 2);
            b4 = LooNupp(1, 0); b5 = LooNupp(1, 1); b6 = LooNupp(1, 2);
            b7 = LooNupp(2, 0); b8 = LooNupp(2, 1); b9 = LooNupp(2, 2);

          
            grid.Children.Add(b1); grid.Children.Add(b2); grid.Children.Add(b3);
            grid.Children.Add(b4); grid.Children.Add(b5); grid.Children.Add(b6);
            grid.Children.Add(b7); grid.Children.Add(b8); grid.Children.Add(b9);

            
            infoSilt = new Label { Text = "Mängija X kord", FontSize = 20, HorizontalOptions = LayoutOptions.Center };

            Button uusMängNupp = new Button { Text = "Uus mäng", BackgroundColor = Colors.Green };
            uusMängNupp.Clicked += (s, e) => PuhastaVäli();

            Button alustajaNupp = new Button { Text = "Kes alustab?", BackgroundColor = Colors.Orange };
            alustajaNupp.Clicked += (s, e) => {
                logic.ChooseRandomStarter();
                infoSilt.Text = $"Mängija {logic.CurrentPlayer} alustab!";
            };

            Button reeglidNupp = new Button { Text = "Vaata reegleid", BackgroundColor = Colors.Blue };
            reeglidNupp.Clicked += AvaReegliteLeht;

          
            VerticalStackLayout paigutus = new VerticalStackLayout { Padding = 20, Spacing = 10 };
            paigutus.Children.Add(infoSilt);
            paigutus.Children.Add(grid);
            paigutus.Children.Add(uusMängNupp);
            paigutus.Children.Add(alustajaNupp);
            paigutus.Children.Add(reeglidNupp);

            this.Content = paigutus;
        }

        private Button LooNupp(int rida, int veerg)
        {
            Button nupp = new Button { Text = "", FontSize = 24 };
            Grid.SetRow(nupp, rida);
            Grid.SetColumn(nupp, veerg);
            nupp.Clicked += (s, e) => RuutVajutatud(nupp);
            return nupp;
        }

        private async void RuutVajutatud(Button nupp)
        {
            if (nupp.Text != "") return; 

            nupp.Text = logic.CurrentPlayer;

            string tulemus = logic.CheckWinner(b1.Text, b2.Text, b3.Text, b4.Text, b5.Text, b6.Text, b7.Text, b8.Text, b9.Text);

            if (tulemus == "Win")
            {
                await DisplayAlert("Mäng läbi", $"{logic.CurrentPlayer} võitis! Kas soovid veel mängida?", "Jah");
                PuhastaVäli();
                return;
            }
            else if (tulemus == "Draw")
            {
                await DisplayAlert("Mäng läbi", "Mäng jäi viiki!", "Uus mäng");
                PuhastaVäli();
                return;
            }

           
            logic.SwitchPlayer();
            UuendaSilti();
        }

        private void PuhastaVäli()
        {
            b1.Text = ""; b2.Text = ""; b3.Text = "";
            b4.Text = ""; b5.Text = ""; b6.Text = "";
            b7.Text = ""; b8.Text = ""; b9.Text = "";
            UuendaSilti();
        }

        private void UuendaSilti()
        {
            
            infoSilt.Text = $"Mängija {logic.CurrentPlayer} kord (Statistika - X: {logic.XWins} | O: {logic.OWins} | Viigid: {logic.Draws})";
        }

        
        private async void AvaReegliteLeht(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RulesPage());
        }
    }
}