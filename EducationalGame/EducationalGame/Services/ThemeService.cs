using System;
using System.Collections.Generic;
using System.Text;

namespace EducationalGame.Services
{
    public class ThemeService
    {
        public void ToggleTheme()
        {
            
            if (Application.Current.UserAppTheme == AppTheme.Dark)
            {
                Application.Current.UserAppTheme = AppTheme.Light;
            }
            
            else
            {
                Application.Current.UserAppTheme = AppTheme.Dark;
            }
        }
    }
}
