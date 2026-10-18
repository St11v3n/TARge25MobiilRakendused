using Programming_Language_portfolio.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Programming_Language_portfolio.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private CarouselItem _currentCard;
        private int _currentCardIndex = 0;
        private readonly LanguageService _languageService;

      
        public static bool IsPageAlive { get; set; } = true;

        public List<CarouselItem> PortfolioItems { get; private set; }

        public CarouselItem CurrentCard
        {
            get => _currentCard;
            set
            {
                if (_currentCard != value)
                {
                    _currentCard = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainViewModel()
        {
            
            IsPageAlive = true;

            _languageService = new LanguageService();
            PortfolioItems = _languageService.GetPortfolioItems();

            if (PortfolioItems.Count > 0)
            {
                CurrentCard = PortfolioItems[_currentCardIndex];
            }

            Application.Current.Dispatcher.StartTimer(TimeSpan.FromSeconds(4), () =>
            {
                
                if (!IsPageAlive)
                {
                    return false;
                }

                if (PortfolioItems.Count == 0) return true;

                _currentCardIndex = (_currentCardIndex + 1) % PortfolioItems.Count;

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    CurrentCard = PortfolioItems[_currentCardIndex];
                });

                return true;
            });
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}