using Programming_Language_portfolio.Resources.Localization;
using static Programming_Language_portfolio.MainPage;

namespace Programming_Language_portfolio.Services
{
    public class LanguageService
    {
        public List<CarouselItem> GetPortfolioItems()
        {
            return new List<CarouselItem>
            {
                new CarouselItem
                {
                    Title = "C#",
                    ImageUrl = "c_sharp_logo.png",
                    Description = AppResources.CSharpDesc,
                    HelloWorldCode = "Console.WriteLine(\"Hello, World!\");"
                },
                new CarouselItem
                {
                    Title = "Python",
                    ImageUrl = "python_logo.jpg",
                    Description = AppResources.PythonDesc,
                    HelloWorldCode = "print(\"Hello, World!\")"
                },
                new CarouselItem
                {
                    Title = "JavaScript",
                    ImageUrl = "javascript_logo.png",
                    Description = AppResources.JSDesc,
                    HelloWorldCode = "console.log(\"Hello, World!\");"
                },
                new CarouselItem
                {
                    Title = "C++",
                    ImageUrl = "c_plus_plus_logo.jpg",
                    Description = AppResources.CppDesc,
                    HelloWorldCode = "std::cout << \"Hello, World!\";"
                }
            };
        }
    }
}