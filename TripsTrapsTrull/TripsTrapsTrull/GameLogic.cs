using System;
using System.Collections.Generic;
using System.Text;

namespace TripsTrapsTrull
{
    public class GameLogic
    {
       
        public string CurrentPlayer { get; set; } = "X";
        public int XWins { get; set; } = 0;
        public int OWins { get; set; } = 0;
        public int Draws { get; set; } = 0;

        
        public void ChooseRandomStarter()
        {
            Random r = new Random();
            CurrentPlayer = (r.Next(0, 2) == 0) ? "X" : "O";
        }

       
        public void SwitchPlayer()
        {
            CurrentPlayer = (CurrentPlayer == "X") ? "O" : "X";
        }

        
        public string CheckWinner(string t1, string t2, string t3, string t4, string t5, string t6, string t7, string t8, string t9)
        {
            bool winFound = false;

            
            if (t1 != "" && t1 == t2 && t2 == t3) winFound = true;
            if (t4 != "" && t4 == t5 && t5 == t6) winFound = true;
            if (t7 != "" && t7 == t8 && t8 == t9) winFound = true;

          
            if (t1 != "" && t1 == t4 && t4 == t7) winFound = true;
            if (t2 != "" && t2 == t5 && t5 == t8) winFound = true;
            if (t3 != "" && t3 == t6 && t6 == t9) winFound = true;

           
            if (t1 != "" && t1 == t5 && t5 == t9) winFound = true;
            if (t3 != "" && t3 == t5 && t5 == t7) winFound = true;

            if (winFound)
            {
                if (CurrentPlayer == "X") XWins++; else OWins++; 
                return "Win";
            }

            
            if (t1 != "" && t2 != "" && t3 != "" && t4 != "" && t5 != "" && t6 != "" && t7 != "" && t8 != "" && t9 != "")
            {
                Draws++; 
                return "Draw";
            }

            return "Continue";
        }
    }
}