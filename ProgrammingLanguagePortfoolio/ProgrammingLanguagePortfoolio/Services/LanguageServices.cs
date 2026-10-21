using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ProgrammingLanguagePortfoolio.Services
{
    public class LanguageServices
    {
        public void SetLanguage(string cultureCode)
        {
            CultureInfo.CurrentCulture = new CultureInfo(cultureCode);

            CultureInfo.CurrentUICulture = new CultureInfo(cultureCode);

            Preferences.Default.Set("AppLanguage", cultureCode);
        }

        public void InitializeLanguage()
        {
            
            string savedLanguage = Preferences.Default.Get("AppLanguage", "et");

            
            CultureInfo.CurrentCulture = new CultureInfo(savedLanguage);
            CultureInfo.CurrentUICulture = new CultureInfo(savedLanguage);
        }
    }
}
