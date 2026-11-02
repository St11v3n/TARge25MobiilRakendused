using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace EducationalGame.Services
{
    public class DatabaseService
    {
        private SQLite.SQLiteAsyncConnection _database;

        private async System.Threading.Tasks.Task InitAsync()
        {
            
            if (_database != null)
            {
                return;
            }

            string secureFolder = Microsoft.Maui.Storage.FileSystem.AppDataDirectory;
            string myFile = "EducationalGame.db3";

            string ultimatePath = System.IO.Path.Combine(secureFolder, myFile);

            _database = new SQLite.SQLiteAsyncConnection(ultimatePath);

            await _database.CreateTableAsync<EducationalGame.Models.GameItem>();
        }

        public async System.Threading.Tasks.Task<List<EducationalGame.Models.GameItem>> GetItemsAsync()
        {
          
            await InitAsync();

           
            return await _database.Table<EducationalGame.Models.GameItem>().ToListAsync();
        }

       
        public async System.Threading.Tasks.Task<int> SaveItemAsync(EducationalGame.Models.GameItem item)
        {
            await InitAsync();

            
            if (item.Id != 0)
            {
                return await _database.UpdateAsync(item);
            }
            else
            {
                return await _database.InsertAsync(item);
            }
        }

        public async System.Threading.Tasks.Task<int> DeleteItemAsync(EducationalGame.Models.GameItem item)
        {
            
            await InitAsync();

            
            return await _database.DeleteAsync(item);
        }




    }
}

    
