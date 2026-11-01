using System;
using System.Collections.Generic;
using System.Linq; 
using Õppemäng.Models;

namespace Õppemäng.Viewmodels
{
    public class GameViewModel
    {
        
        private readonly GameItem[] _masterPool = new GameItem[]
        {
            new GameItem { ImageSource = "cat.png", EnglishWord = "Cat", EstonianWord = "Kass", RussianWord = "Кот" },
            new GameItem { ImageSource = "dog.png", EnglishWord = "Dog", EstonianWord = "Koer", RussianWord = "Собака" },
            new GameItem { ImageSource = "bear.png", EnglishWord = "Bear", EstonianWord = "Karu", RussianWord = "Медведь" },
            new GameItem { ImageSource = "fox.png", EnglishWord = "Fox", EstonianWord = "Rebane", RussianWord = "Лиса" },
            new GameItem { ImageSource = "wolf.png", EnglishWord = "Wolf", EstonianWord = "Susi", RussianWord = "Волк" },
            new GameItem { ImageSource = "lion.png", EnglishWord = "Lion", EstonianWord = "Lõvi", RussianWord = "Лев" }
        };

        
        public GameItem Item1 { get; private set; }
        public GameItem Item2 { get; private set; }
        public GameItem Item3 { get; private set; }

        public void SetupNewRound()
        {
             
            
            List<GameItem> randomThree = _masterPool.OrderBy(x => Guid.NewGuid()).Take(3).ToList();

            
            Item1 = randomThree[0];
            Item2 = randomThree[1];
            Item3 = randomThree[2];

            
        }
    }
}