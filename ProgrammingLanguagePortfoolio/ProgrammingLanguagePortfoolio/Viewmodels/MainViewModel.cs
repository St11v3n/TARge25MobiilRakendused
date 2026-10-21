using ProgrammingLanguagePortfoolio.Models;
using ProgrammingLanguagePortfoolio.Resources;
using ProgrammingLanguagePortfoolio.Resources.Localization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;

namespace ProgrammingLanguagePortfoolio.Viewmodels
{
    public class MainViewModel
    {
        public ObservableCollection<CarouselItem> Items { get; set; } = new ObservableCollection<CarouselItem>();

        public MainViewModel()
        {
            LoadLanguages();
        }

        public void ChangeLanguage(string cultureCode)
        {
            
            var culture = new CultureInfo(cultureCode);
            AppResources.Culture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            
            LoadLanguages();
        }

        public void LoadLanguages()
        {
            
            Items.Clear();

            
            Items.Add(new CarouselItem
            {
                Title = "C#",
                Description = AppResources.CSharpDesc, 
                ImageUrl = "c_sharp_logo.png",
                ViewCode = "Console.WriteLine(\"Hello World\");",
                ButtonText = AppResources.ButtonText
            });

            Items.Add(new CarouselItem
            {
                Title = "Python",
                Description = AppResources.PythonDesc, 
                ImageUrl = "python_logo.jpg",
                ViewCode = "print('Hello World')",
                ButtonText = AppResources.ButtonText
            });

            Items.Add(new CarouselItem
            {
                Title = "C++",
                Description = AppResources.CppDesc,
                ImageUrl = "c_plus_plus_logo.jpg",
                ViewCode = "std::cout << \"Hello World\";",
                ButtonText = AppResources.ButtonText
            });

            Items.Add(new CarouselItem
            {
                Title = "JavaScript",
                Description = AppResources.JSDesc,
                ImageUrl = "javascript_logo.png",
                ViewCode = "console.log('Hello World');",
                ButtonText = AppResources.ButtonText
            });

            Items.Add(new CarouselItem
            {
                Title = "TypeScript",
                Description = AppResources.TSDesc, 
                ImageUrl = "typescript_logo.png",
                ViewCode = "console.log('Hello World');",
                ButtonText = AppResources.ButtonText
            });
        }

        

        
        
    }
}
