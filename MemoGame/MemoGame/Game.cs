using System;
using System.Collections.Generic;
using System.Text;

namespace MemoGame
{
    public class Game
    {

        public Card[,] Board { get; private set; }
        public Button FirstSelectedButton { get; set; }
        public Card FirstSelectedCard { get; set; }
        public int SelectedCount { get; set; }

        private List<string> letterPool = new List<string>
        {
            "A", "B", "C", "D", "E", "F", "G", "H"
        };

        public Game()
        {
            Board = new Card[4, 4];
            ResetGame();
        }

        public void ResetGame()
        {
            SelectedCount = 0;
            FirstSelectedButton = null;
            FirstSelectedCard = null;

           
            List<string> gameCards = new List<string>();
            foreach (var letter in letterPool)
            {
                gameCards.Add(letter);
                gameCards.Add(letter);
            }

            
            Random rnd = new Random();
            for (int i = gameCards.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                string temp = gameCards[i];
                gameCards[i] = gameCards[j];
                gameCards[j] = temp;
            }

            
            int listIndex = 0;
            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < 4; c++)
                {
                    Board[r, c] = new Card(gameCards[listIndex]);
                    listIndex++;
                }
            }
        }

    }


}
