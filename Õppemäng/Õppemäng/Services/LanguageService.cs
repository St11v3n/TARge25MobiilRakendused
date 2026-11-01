using System;
using System.Collections.Generic;
using System.Text;

namespace Õppemäng.Services
{
    public class LanguageService
    {
        public void ChangeLanguage(string targetlanguage)
        {
            var culture = new System.Globalization.CultureInfo(targetlanguage);

            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = culture;
            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = culture;

            Preferences.Default.Set("SavedLanguage", targetlanguage);
        }

        public void LoadLanguage()
        {
            string savedLanguage = Preferences.Default.Get("SavedLanguage", "en");

            var culture = new System.Globalization.CultureInfo(savedLanguage);

            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = culture;
            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }
}
