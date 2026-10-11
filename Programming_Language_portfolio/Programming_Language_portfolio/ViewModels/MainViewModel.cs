using Programming_Language_portfolio.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static Programming_Language_portfolio.MainPage;

namespace Programming_Language_portfolio.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;

        private CarouselItem _currentCard;
        private int _currentCardIndex = 0;
        private readonly LanguageService _languageService;

        public List<CarouselItem> PortfolioItems { get; private set; }

        public CarouselItem CurrentCard
        {
            get => _currentCard;
            set
            {
                _currentCard = value;
                OnPropertyChanged(); 
            }
        }

        public MainViewModel()
        {
            _languageService = new LanguageService();
            PortfolioItems = _languageService.GetPortfolioItems();
            CurrentCard = PortfolioItems[_currentCardIndex];

            
            Application.Current.Dispatcher.StartTimer(TimeSpan.FromSeconds(4), () =>
            {
                _currentCardIndex = (_currentCardIndex + 1) % PortfolioItems.Count;
                CurrentCard = PortfolioItems[_currentCardIndex];
                return true;
            });
        }

        
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}