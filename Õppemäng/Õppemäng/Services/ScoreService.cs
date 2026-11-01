using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using Õppemäng.Models;

namespace Õppemäng.Services
{
    public class ScoreService
    {
        private readonly SQLiteConnection _database;

        
        public ScoreService()
        {
            
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            
            string dbPath = System.IO.Path.Combine(folder, "UserScores.db3");

            
            _database = new SQLiteConnection(dbPath);

            
            _database.CreateTable<GameItem>();
        }
        public void SaveScore(int finalScore)
        {
            
            var newRecord = new GameItem
            {
                Value = finalScore
            };

            
            _database.Insert(newRecord);
        }

        public int GetScore()
        {
            
            var scoreHistory = _database.Table<GameItem>().ToList();

            
            if (scoreHistory.Count == 0)
            {
                return 0;
            }

            
            int highestScore = 0;

           
            foreach (var record in scoreHistory)
            {
                if (record.Value > highestScore)
                {
                    highestScore = record.Value; 
                }
            }

            return highestScore;
        }
    }
}
