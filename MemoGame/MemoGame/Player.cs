using System;
using System.Collections.Generic;
using System.Text;

namespace MemoGame
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int MoveCount { get; set; }

        public Player(string name = "Guest")
        {
            Name = name;
            Score = 0;
            MoveCount = 0;
        }

        public void IncrementMoves()
        {
            MoveCount++;
        }

        public void AddPoints(int points)
        {
            Score += points;
        }

        public void ResetStats()
        {
            Score = 0;
            MoveCount = 0;
        }
    }


}
