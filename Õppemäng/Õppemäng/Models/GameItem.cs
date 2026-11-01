using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Õppemäng.Models
{
    public class GameItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int Value { get; set; }

        public string ImageSource { get; set; }  
        public string EnglishWord { get; set; }  
        public string EstonianWord { get; set; } 
        public string RussianWord { get; set; }  
    }
}
