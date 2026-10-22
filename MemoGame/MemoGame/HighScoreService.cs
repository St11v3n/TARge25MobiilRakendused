using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace MemoGame
{
    public class HighScoreService
    {

        private static string filePath = Path.Combine(FileSystem.AppDataDirectory, "highscore.json");


        public static void SaveHighScore(int score)
        {

            if (score > GetHighScore())
            {
                string jsonString = JsonSerializer.Serialize(score);
                File.WriteAllText(filePath, jsonString);
            }
        }

        public static int GetHighScore()
        {
            if (!File.Exists(filePath))
            {
                return 0; 
            }

            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<int>(jsonString);
        }

    }
}
