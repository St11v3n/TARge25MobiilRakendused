namespace TripsTrapsTrull
{
    public partial class MainPage : ContentPage
    {
       
        GameLogic logic = new GameLogic();

        
        Button b1, b2, b3, b4, b5, b6, b7, b8, b9;
        Label statusLabel;

        public MainPage()
        {
            InitializeComponent();

           
            Grid gameGrid = new Grid { HeightRequest = 300, WidthRequest = 300 };
            for (int i = 0; i < 3; i++)
            {
                gameGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
                gameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            }

            
            b1 = CreateBoardButton(0, 0); b2 = CreateBoardButton(0, 1); b3 = CreateBoardButton(0, 2);
            b4 = CreateBoardButton(1, 0); b5 = CreateBoardButton(1, 1); b6 = CreateBoardButton(1, 2);
            b7 = CreateBoardButton(2, 0); b8 = CreateBoardButton(2, 1); b9 = CreateBoardButton(2, 2);

            
            gameGrid.Children.Add(b1); gameGrid.Children.Add(b2); gameGrid.Children.Add(b3);
            gameGrid.Children.Add(b4); gameGrid.Children.Add(b5); gameGrid.Children.Add(b6);
            gameGrid.Children.Add(b7); gameGrid.Children.Add(b8); gameGrid.Children.Add(b9);

           
            statusLabel = new Label { Text = "Player X's turn", FontSize = 20, HorizontalOptions = LayoutOptions.Center };

            
            Button newGameButton = new Button { Text = "Uus mäng", BackgroundColor = Colors.Green };
            newGameButton.Clicked += (s, e) => ClearGameBoard();

            Button randomStarterButton = new Button { Text = "Kes alustab?", BackgroundColor = Colors.Orange };
            randomStarterButton.Clicked += (s, e) => {
                logic.ChooseRandomStarter();
                statusLabel.Text = $"Mängija {logic.CurrentPlayer} alustab!";
            };

            Button rulesButton = new Button { Text = "Vaata reegleid", BackgroundColor = Colors.Blue };
            rulesButton.Clicked += OpenRulesPage;

            Button resetStatsButton = new Button { Text = "Nulli statistika", BackgroundColor = Colors.DarkRed, TextColor = Colors.White };
            resetStatsButton.Clicked += (s, e) => {
                logic.ResetAllStatisticsPermanently();
                UpdateStatusLabel();
            };

            
            VerticalStackLayout verticalLayout = new VerticalStackLayout { Padding = 20, Spacing = 10 };
            verticalLayout.Children.Add(statusLabel);
            verticalLayout.Children.Add(gameGrid);
            verticalLayout.Children.Add(newGameButton);
            verticalLayout.Children.Add(randomStarterButton);
            verticalLayout.Children.Add(rulesButton);
            verticalLayout.Children.Add(resetStatsButton);

           
            this.Content = verticalLayout;

            
            UpdateStatusLabel();
        }

       
        private Button CreateBoardButton(int row, int column)
        {
            Button button = new Button { Text = "", FontSize = 24 };
            Grid.SetRow(button, row);
            Grid.SetColumn(button, column);
            button.Clicked += (s, e) => SquarePushed(button);
            return button;
        }

        private async void SquarePushed(Button button)
        {
           
            if (button.Text != "") return;

         
            button.Text = logic.CurrentPlayer;

            
            string matchResult = logic.CheckWinner(b1.Text, b2.Text, b3.Text, b4.Text, b5.Text, b6.Text, b7.Text, b8.Text, b9.Text);

            if (matchResult == "Win")
            {
                await DisplayAlert("Mäng läbi", $"{logic.CurrentPlayer} võitis! Kas soovid veel mängida?", "Jah");
                ClearGameBoard();
                return;
            }
            else if (matchResult == "Draw")
            {
                await DisplayAlert("Mäng läbi", "Mäng jäi viiki!", "Uus mäng");
                ClearGameBoard();
                return;
            }

            
            logic.SwitchPlayer();
            UpdateStatusLabel();
        }

        private void ClearGameBoard()
        {
            b1.Text = ""; b2.Text = ""; b3.Text = "";
            b4.Text = ""; b5.Text = ""; b6.Text = "";
            b7.Text = ""; b8.Text = ""; b9.Text = "";
            UpdateStatusLabel();
        }

        private void UpdateStatusLabel()
        {
            statusLabel.Text = $"Mängija {logic.CurrentPlayer} kord (Statistika - X: {logic.XWins} | O: {logic.OWins} | Viigid: {logic.Draws})";
        }

        private async void OpenRulesPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RulesPage());
        }
    }
}