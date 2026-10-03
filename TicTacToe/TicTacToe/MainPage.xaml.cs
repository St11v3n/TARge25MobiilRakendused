namespace TicTacToe
{
    public partial class MainPage : ContentPage
    {
        private GameLogic gameLogistics;
        public MainPage()
        {
            VerticalStackLayout wholelayout = new VerticalStackLayout { Spacing = 20, HorizontalOptions = LayoutOptions.Center };

            gameLogistics = new GameLogic();

            Label title = new Label()
            {
                Text = "Tic Tac Toe",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 20

            };



            Grid grid = new Grid { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };



            for (int i = 0; i < 3; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            }




            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Button SquareBtn = new Button
                    {
                        Text = "",
                        WidthRequest = 150,
                        HeightRequest = 150,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center
                    };

                    grid.Add(SquareBtn, row, col);

                    gameLogistics.SquareButtons.Add(SquareBtn);

                    SquareBtn.Clicked += gameLogistics.SquareMoveRegistration;
                }
            }

            Button TurnBtn = new Button
            {
                Text = "Starter",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,


            };

            TurnBtn.Clicked += gameLogistics.StarterBtnClicked;

            Button NewGameBtn = new Button
            {
                Text = "New Game",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

            };

            NewGameBtn.Clicked += gameLogistics.NewGameBtnClicked;

            Button RulesBtn = new Button
            {
                Text = "Rules",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(150, -130, -150, 130)

            };

            RulesBtn.Clicked += gameLogistics.RulesBtnClicked;



            Button StatisticsBtn = new Button
            {
                Text = "Statistics",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(-150, -190, 150, 190)

            };

            StatisticsBtn.Clicked += gameLogistics.StatisticsBtnClicked;

            wholelayout.Add(title);
            wholelayout.Add(grid);
            wholelayout.Add(TurnBtn);
            wholelayout.Add(NewGameBtn);
            wholelayout.Add(RulesBtn);
            wholelayout.Add(StatisticsBtn);

            ScrollView LemmeScrollUpAndDownBecauseThereIsTooMuchOnTheScreen = new ScrollView();

            LemmeScrollUpAndDownBecauseThereIsTooMuchOnTheScreen.Content = wholelayout;




            this.Content = LemmeScrollUpAndDownBecauseThereIsTooMuchOnTheScreen;


        }

    }

    
}
