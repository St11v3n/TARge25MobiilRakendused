using Programming_Language_portfolio.Resources.Localization;

namespace Programming_Language_portfolio.Services
{
    public class CarouselItem
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string HelloWorldCode { get; set; }
        public string ButtonText { get; set; }
    }

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
                    HelloWorldCode = "Console.WriteLine(\"Hello, World!\");",
                    ButtonText = AppResources.ButtonText 
                },
                new CarouselItem
                {
                    Title = "Python",
                    ImageUrl = "python_logo.jpg",
                    Description = AppResources.PythonDesc,
                    HelloWorldCode = "print(\"Hello, World!\")",
                    ButtonText = AppResources.ButtonText 
                },
                new CarouselItem
                {
                    Title = "JavaScript",
                    ImageUrl = "javascript_logo.png",
                    Description = AppResources.JSDesc,
                    HelloWorldCode = "console.log(\"Hello, World!\");",
                    ButtonText = AppResources.ButtonText 
                },
                new CarouselItem
                {
                    Title = "C++",
                    ImageUrl = "c_plus_plus_logo.jpg",
                    Description = AppResources.CppDesc,
                    HelloWorldCode = "std::cout << \"Hello, World!\";",
                    ButtonText = AppResources.ButtonText 
                }
            };
        }
    }
}