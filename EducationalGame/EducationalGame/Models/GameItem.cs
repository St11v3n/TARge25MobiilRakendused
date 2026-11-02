using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using SQLite;

namespace EducationalGame.Models
{
    public class GameItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string AnimalName { get; set; }

        public string ImagePath { get; set; }

        public string AnswerKey { get; set; }
    }
}
