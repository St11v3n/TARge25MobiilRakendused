using EducationalGame.Models;
using EducationalGame.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace EducationalGame.ViewModels
{
    public class MainViewModel
    {

        
        private readonly DatabaseService _databaseService;

        
        public ObservableCollection<GameItem> GameItem { get; set; }

        
        public ICommand StartBtnCommand { get; set; }
       

        
        public MainViewModel(DatabaseService databaseService)
        {
            
            _databaseService = databaseService;

            
            GameItem = new ObservableCollection<GameItem>();

            
            StartBtnCommand = new Command(OnStartBtnClicked);
        }

       
        public async Task LoadGameItemsAsync()
        {
            
            var itemsFromDb = await _databaseService.GetItemsAsync();

            
            GameItem.Clear();

            
            foreach (var item in itemsFromDb)
            {
                GameItem.Add(item);
            }
        }
        public async void OnStartBtnClicked()
        {

            var currentItems = await _databaseService.GetItemsAsync();

            
            if (currentItems.Count == 0)
            {
                
                var item1 = new GameItem { AnimalName = "Kass", ImagePath = "cat.jpg" };
                var item2 = new GameItem { AnimalName = "Koer", ImagePath = "dog.jpg" };
                var item3 = new GameItem { AnimalName = "Hamster", ImagePath = "hamster.png" };

                
                await _databaseService.SaveItemAsync(item1);
                await _databaseService.SaveItemAsync(item2);
                await _databaseService.SaveItemAsync(item3);
            }

            
            await LoadGameItemsAsync();

        }
    }
}
