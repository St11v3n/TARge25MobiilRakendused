using EducationalGame.ViewModels;

namespace EducationalGame
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();

            this.BindingContext = viewModel;
        }

        
    }
}
