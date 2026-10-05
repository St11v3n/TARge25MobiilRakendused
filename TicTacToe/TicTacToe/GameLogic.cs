using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe

{
    public class GameLogic
    {
        public bool isXTurn = true;

        public bool isGameInProgress = false;

        public bool isGameOver = false;

        public int XWinsCount = 0;
        public int OWinsCount = 0;
        public int DrawsCount = 0;

        public List<Button> SquareButtons = new List<Button>();

        public GameLogic()
        {
            XWinsCount = Preferences.Default.Get("XWins", 0);
            OWinsCount = Preferences.Default.Get("OWins", 0);
            DrawsCount = Preferences.Default.Get("Draws", 0);
        }


        public void SquareMoveRegistration(object sender, EventArgs e)
        {
            Button ChosenBtn = (Button)sender;

            if (isGameOver == true)
            {
                return;
            }

            if (ChosenBtn.Text != "")
            {
                return;
            }

            if (isXTurn == true)
            {
                ChosenBtn.Text = "X";
            }

            else
            {
                ChosenBtn.Text = "O";
            }

            isGameInProgress = true;

            string result = CheckWinner();

            if (result == "X")
            {
                isGameOver = true;

                XWinsCount++;

                Preferences.Default.Set("XWinsCount", XWinsCount);

                App.Current.MainPage.DisplayAlert("Game is over", "X wins!", "Okay");
                return;

            }

            else if (result == "O")
            {
                OWinsCount++;

                Preferences.Default.Set("OWinsCount", OWinsCount);

                isGameOver = true;

                App.Current.MainPage.DisplayAlert("Game is over", "O wins!", "Okay");

                return;
            }

            else if (result == "Draw")
            {
                DrawsCount++;

                Preferences.Default.Set("DrawsCount", DrawsCount);

                isGameOver = true;

                App.Current.MainPage.DisplayAlert("Game is over", "Draw!", "Okay");

                return;
            }

            isXTurn = !isXTurn;

        }




        public void StarterBtnClicked (object sender, EventArgs e)
        {
            if (isGameInProgress == true)
            {
                return;
            }

            Button ChooseStarterBtn = (Button)sender;

            isXTurn = !isXTurn;

            if (isXTurn == true)
            {
                ChooseStarterBtn.Text = "X is starting";
            }

            else
            {
                ChooseStarterBtn.Text = "O is starting";
            }

        }



        public void NewGameBtnClicked (object sender, EventArgs e)
        {
            isXTurn = true;

            isGameInProgress = false;

            isGameOver = false;

            foreach(Button button in SquareButtons)
            {
                button.Text = "";
            }

        }

        public async void RulesBtnClicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new RulesPage(this));
        }

        public async void CloseBtnClicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        public async void StatisticsBtnClicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new StatisticsPage(this));
        }



        public string CheckWinner()
        {
          if  (SquareButtons[0].Text != "" &&
                SquareButtons[0].Text == SquareButtons[1].Text &&
                SquareButtons[0].Text == SquareButtons[2].Text)
          {
                return SquareButtons[0].Text;
          }

          if (SquareButtons[3].Text != "" &&
                SquareButtons[3].Text == SquareButtons[4].Text &&
                SquareButtons[3].Text == SquareButtons[5].Text)
          {
                return SquareButtons[3].Text;
          }

          if (SquareButtons[6].Text != "" &&
                SquareButtons[6].Text == SquareButtons[7].Text &&
                SquareButtons[6].Text == SquareButtons[8].Text)
          {
                return SquareButtons[6].Text;
          }

          if (SquareButtons[0].Text != "" &&
                SquareButtons[0].Text == SquareButtons[3].Text &&
                SquareButtons[0].Text == SquareButtons[6].Text)
          {
            return SquareButtons[0].Text;
          }

          if (SquareButtons[1].Text != "" &&
                SquareButtons[1].Text == SquareButtons[4].Text &&
                SquareButtons[1].Text == SquareButtons[7].Text)
          {
            return SquareButtons[1].Text;
          }

          if (SquareButtons[2].Text != "" &&
                SquareButtons[2].Text == SquareButtons[5].Text &&
                SquareButtons[2].Text == SquareButtons[8].Text)
          {
            return SquareButtons[2].Text;
          }

          if (SquareButtons[2].Text != "" &&
                SquareButtons[2].Text == SquareButtons[4].Text &&
                SquareButtons[2].Text == SquareButtons[6].Text)
          {
            return SquareButtons[2].Text;
          }

          if (SquareButtons[0].Text != "" &&
                  SquareButtons[0].Text == SquareButtons[4].Text &&
                  SquareButtons[0].Text == SquareButtons[8].Text)
          {
                return SquareButtons[0].Text;
          }


            bool isBoardFilled = true;
          
          foreach (Button button in SquareButtons)
          {
                if (button.Text == "")
                {
                    isBoardFilled = false;
                }
          }

          if (isBoardFilled == true)
          {
                return "Draw";
          }

            return "None";

        }
    }
}
