using System;
using System.Collections.Generic;
using System.Text;

namespace MemoGame
{
    public class Card
    {
        public string Content { get; private set; } 
        public bool IsFaceUp { get; set; }
        public bool IsMatched { get; set; }

        public Card(string content)
        {
            Content = content;
            IsFaceUp = false;
            IsMatched = false;
        }
    }

}
