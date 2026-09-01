using Microsoft.Extensions.DependencyInjection;

namespace MauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            //loome esimese lehe (StartPage)
            var startPage =new StartPage();
            var navPage = new NavigationPage(startPage)
            {
                BarBackgroundColor = Colors.LightBlue,
                BarTextColor = Colors.White
            };
            return new Window(navPage);
        }
    }
}