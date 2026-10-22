



namespace MemoGame
{
    public partial class MainPage : ContentPage
    {
        private Grid grid;

       

        private Button statisticsButton;

        private Button startButton;

        private Button themeButton;

        private VerticalStackLayout layout;

        private HorizontalStackLayout buttonlayout;

        private int currentThemeIndex;

        private Player player;
        private Button choiceButton;


        private Game game;

        private Theme[] themes;

        public MainPage()
        {
            player = new Player("Player 1");

            game = new Game();

            themes = new Theme[]
            {
                new Theme("Light", Colors.White, Colors.LightGray, Colors.Black),
                new Theme("Dark", Colors.DimGray, Colors.Black, Colors.White),
                new Theme("Colorful", Colors.LightPink, Colors.Purple, Colors.Yellow)
            };

            grid = new Grid
            {
                RowSpacing = 4,
                ColumnSpacing = 4,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

           



            for (int row = 0; row < 4; row++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });

                

               
            }

            for (int column = 0; column < 4; column++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

               
            }

            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < 4; c++)
                {

                    choiceButton = new Button { Text = "?", HeightRequest = 70, WidthRequest = 70, BackgroundColor = Colors.Gray };
                    choiceButton.Clicked += OnClickedChoiceButton;
                    grid.Add(choiceButton, c, r);
                }
            }

            startButton = new Button
            {
                Text = "Start",
                HorizontalOptions = LayoutOptions.Center,
                
            };

            statisticsButton = new Button
            {
                Text = "Statistics",
                HorizontalOptions = LayoutOptions.Center,
               
            };

            themeButton = new Button
            {
                Text = "Theme",
                HorizontalOptions = LayoutOptions.Center,
               
            };

            layout = new VerticalStackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            buttonlayout = new HorizontalStackLayout
            {
                Spacing = 20,
                HorizontalOptions = LayoutOptions.Center
            };

            buttonlayout.Margin = new Thickness(0, 20, 0, 0);

            buttonlayout.Add(startButton);
            buttonlayout.Add(statisticsButton);
            buttonlayout.Add(themeButton);


            

            layout.Add(grid);
            layout.Add(buttonlayout);


            startButton.Clicked += OnClickedStartButton;
            themeButton.Clicked += OnClickedThemeButton;
            statisticsButton.Clicked += OnClickedStatisticsButton;




            
            Content = layout;
        }

        public async void OnClickedChoiceButton(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            int r = Grid.GetRow(clickedButton);
            int c = Grid.GetColumn(clickedButton);

            Card clickedCard = game.Board[r, c];

            if (clickedCard.IsFaceUp || clickedCard.IsMatched || game.SelectedCount >= 2)
                return;

            clickedCard.IsFaceUp = true;
            clickedButton.Text = clickedCard.Content;
            player.IncrementMoves();
            game.SelectedCount++;

            if (game.SelectedCount == 1)
            {
                game.FirstSelectedButton = clickedButton;
                game.FirstSelectedCard = clickedCard;
            }
            else if (game.SelectedCount == 2)
            {
                
                await Task.Delay(1000);

                if (game.FirstSelectedCard.Content == clickedCard.Content)
                {
                    
                    game.FirstSelectedCard.IsMatched = true;
                    clickedCard.IsMatched = true;
                    player.AddPoints(20);

                   
                    bool hasWon = true;
                    for (int row = 0; row < 4; row++)
                    {
                        for (int col = 0; col < 4; col++)
                        {
                            if (game.Board[row, col].IsMatched == false)
                            {
                                hasWon = false;
                                break;
                            }
                        }
                        if (!hasWon) break;
                    }

                    if (hasWon)
                    {
                        HighScoreService.SaveHighScore(player.Score);
                        string victoryMessage = $"Victory! You matched all pairs!\n\n" +
                                                 $"Total Moves: {player.MoveCount}\n" +
                                                 $"Final Score: {player.Score} pts\n" +
                                                 $"High Score: {HighScoreService.GetHighScore()} pts";

                        await DisplayAlert("Game Over", victoryMessage, "Great!");
                    }
                }
                else
                {
                    
                    game.FirstSelectedCard.IsFaceUp = false;
                    clickedCard.IsFaceUp = false;

                    game.FirstSelectedButton.Text = "?";
                    clickedButton.Text = "?";
                }

                
                game.SelectedCount = 0;
                game.FirstSelectedButton = null;
                game.FirstSelectedCard = null;
            }
        }

        public void OnClickedStartButton(object sender, EventArgs e)
        {

            game.ResetGame();   
            player.ResetStats(); 

            
            foreach (var element in grid.Children)
            {
                if (element is Button cardButton)
                {
                    cardButton.Text = "?";
                }
            }

            DisplayAlertAsync("New Game", "The board has been randomized!", "OK");

        }

        public void OnClickedStatisticsButton(object sender, EventArgs e)
        {
            int savedHighScore = HighScoreService.GetHighScore();

            string statsMessage = $"Player: {player.Name}\n" +
                          $"Score: {player.Score} points\n" +
                          $"Moves: {player.MoveCount}\n"+
                          $"All-Time High Score: {savedHighScore} points";

            DisplayAlertAsync("Game Stats", statsMessage, "Close");

        }

        public void OnClickedThemeButton(object sender, EventArgs e)
        {


            
            if (currentThemeIndex == 0)
            {
                currentThemeIndex = 1; 
            }
            else if (currentThemeIndex == 1)
            {
                currentThemeIndex = 2; 
            }
            else
            {
                currentThemeIndex = 0; 
            }

            
            themes[currentThemeIndex].Apply(this, startButton, statisticsButton, themeButton);

        }



    }
}
