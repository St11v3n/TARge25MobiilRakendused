using EducationalGame.Models;
using EducationalGame.Resources.Localization;
using EducationalGame.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace EducationalGame.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ThemeService _themeService;

        

        private readonly DatabaseService _databaseService;

        private string _currentlyDraggedItem; 
        private int _score = 0;


        public ObservableCollection<GameItem> GameItem { get; set; }
        public ICommand DragStartingCommand { get; set; }
        public ICommand DropCommand { get; set; }
        public ICommand StatisticsBtnCommand { get; set; }
        public ICommand StartBtnCommand { get; set; }
        public ICommand ThemeBtnCommand { get; set; }

        public ICommand EnglishBtnCommand { get; set; }
        public ICommand RussianBtnCommand { get; set; }
        public ICommand EstonianBtnCommand { get; set; }

        public string StartText => AppResource.StartText;
        public string StatisticsText => AppResource.StatisticsText;
        public string ThemeText => AppResource.ThemeText;

        public string EnglishText => AppResource.EnglishText;
        public string RussianText => AppResource.RussianText;
        public string EstonianText => AppResource.EstonianText;


        public MainViewModel(DatabaseService databaseService, ThemeService themeService)
        {

            _databaseService = databaseService;
            _themeService = themeService;

            DragStartingCommand = new Command<string>(OnDragStarting);
            DropCommand = new Command<GameItem>(OnItemDropped);

            GameItem = new ObservableCollection<GameItem>();

            
            StartBtnCommand = new Command(OnStartBtnClicked);

            
            ThemeBtnCommand = new Command(OnThemeBtnClicked);

            StatisticsBtnCommand = new Command(OnStatisticsBtnClicked);


            EnglishBtnCommand = new Command(OnEnglishBtnClicked);

            RussianBtnCommand = new Command(OnRussianBtnClicked);

            EstonianBtnCommand = new Command(OnEstonianBtnClicked);
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

            foreach (var oldItem in currentItems)
            {
                await _databaseService.DeleteItemAsync(oldItem);
            }

            currentItems = await _databaseService.GetItemsAsync();


            if (currentItems.Count == 0)
            {
                
                var item1 = new GameItem { AnimalName = "Cat", ImagePath = "empty.png", AnswerKey = "cat.jpg" };
                var item2 = new GameItem { AnimalName = "Dog", ImagePath = "empty.png", AnswerKey = "dog.jpg" };
                var item3 = new GameItem { AnimalName = "Hamster", ImagePath = "empty.png", AnswerKey = "hamster.png" };

                
                await _databaseService.SaveItemAsync(item1);
                await _databaseService.SaveItemAsync(item2);
                await _databaseService.SaveItemAsync(item3);
            }

            
            await LoadGameItemsAsync();

        }

        public async void OnStatisticsBtnClicked()
        {
           
            var culture = System.Globalization.CultureInfo.CurrentUICulture;

           
            string alertTitle = AppResource.ResourceManager.GetString("AlertTitle", culture);
            string closeButtonText = AppResource.ResourceManager.GetString("AlertClose", culture);

           
            int totalPuzzles = 3;
            int accuracyPercentage = (_score > 0) ? (int)((double)_score / totalPuzzles * 100) : 0;

         
            string alertMessage;
            if (culture.TwoLetterISOLanguageName == "et")
            {
                alertMessage = $"Kokku mõistatusi laetud: {totalPuzzles}\nÕigeid vastuseid: {_score}\nTäpsus: {accuracyPercentage}%";
            }
            else if (culture.TwoLetterISOLanguageName == "ru")
            {
                alertMessage = $"Всего головоломок загружено: {totalPuzzles}\nПравильных совпадений: {_score}\nТочность: {accuracyPercentage}%";
            }
            else 
            {
                alertMessage = $"Total Puzzles Loaded: {totalPuzzles}\nCorrect Matches: {_score}\nAccuracy: {accuracyPercentage}%";
            }

           
            if (Application.Current?.MainPage != null)
            {
                await Application.Current.MainPage.DisplayAlertAsync(alertTitle, alertMessage, closeButtonText);
            }
        }

        public void OnThemeBtnClicked()
        {
            _themeService.ToggleTheme();
        }

        public void OnEnglishBtnClicked()
        {
            System.Globalization.CultureInfo.CurrentUICulture = new System.Globalization.CultureInfo("en");
            RefreshAllButtonText();
        }

        public void OnRussianBtnClicked()
        {
            System.Globalization.CultureInfo.CurrentUICulture = new System.Globalization.CultureInfo("ru");
            RefreshAllButtonText();
        }

        public void OnEstonianBtnClicked()
        {
            System.Globalization.CultureInfo.CurrentUICulture = new System.Globalization.CultureInfo("et");
            RefreshAllButtonText();
        }

        private void RefreshAllButtonText()
        {
            OnPropertyChanged(nameof(StartText));
            OnPropertyChanged(nameof(StatisticsText));
            OnPropertyChanged(nameof(ThemeText));

            OnPropertyChanged(nameof(EnglishText));
            OnPropertyChanged(nameof(RussianText));
            OnPropertyChanged(nameof(EstonianText));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnDragStarting(string dragParameter)
        {
            
            if (dragParameter == "DragImage1") _currentlyDraggedItem = "cat.jpg";
            else if (dragParameter == "DragImage2") _currentlyDraggedItem = "dog.jpg";
            else if (dragParameter == "DragImage3") _currentlyDraggedItem = "hamster.png";
        }

       
        private async void OnItemDropped(GameItem targetedSlot)
        {
            
            if (string.IsNullOrEmpty(_currentlyDraggedItem) || targetedSlot == null || targetedSlot.ImagePath != "empty.png")
                return;


            if (_currentlyDraggedItem == targetedSlot.AnswerKey)
            {
                _score++;
                targetedSlot.ImagePath = targetedSlot.AnswerKey;
                await _databaseService.SaveItemAsync(targetedSlot);
                await LoadGameItemsAsync();

                if (Application.Current?.MainPage != null)
                {
                    // 1. Fetch strings via runtime culture manager bypass
                    var culture = System.Globalization.CultureInfo.CurrentUICulture;
                    string title = AppResource.ResourceManager.GetString("CorrectTitle", culture);
                    string msgTemplate = AppResource.ResourceManager.GetString("CorrectMessage", culture);
                    string close = AppResource.ResourceManager.GetString("AlertClose", culture);

                    // 2. Safely swap the {0} code placeholder for the actual targetedSlot.AnimalName string
                    string finalMessage = string.Format(msgTemplate, targetedSlot.AnimalName);

                    await Application.Current.MainPage.DisplayAlertAsync(title, finalMessage, close);
                }
            }
            else
            {
                if (Application.Current?.MainPage != null)
                {
                    var culture = System.Globalization.CultureInfo.CurrentUICulture;
                    string title = AppResource.ResourceManager.GetString("WrongTitle", culture);
                    string msg = AppResource.ResourceManager.GetString("WrongMessage", culture);
                    string close = AppResource.ResourceManager.GetString("AlertClose", culture);

                    await Application.Current.MainPage.DisplayAlertAsync(title, msg, close);
                }
            }


            _currentlyDraggedItem = null;
        }
    }
}
