﻿using Calculator.Enums;
using Calculator.Services;
using Calculator.ThemeResources;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Calculator.Helpers
{
    public static class ThemeManager
    {
        private const string SelectedThemeKey = "SelectedTheme";

        public static void ChangeTheme(Themes theme)
        {
            var mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            mergedDictionaries.Clear();

            Preferences.Set(SelectedThemeKey, (int)theme);

            var statusBarStyleManager = DependencyService.Get<IStatusBarStyleManager>();

            switch (theme)
            {
                case Themes.Light:
                    mergedDictionaries.Add(new LightTheme());
                    statusBarStyleManager.SetWhiteTheme();
                    break;
                case Themes.Dark:
                    mergedDictionaries.Add(new DarkTheme());
                    statusBarStyleManager.SetBlackTheme();
                    break;
                default:
                    mergedDictionaries.Add(new LightTheme());
                    statusBarStyleManager.SetWhiteTheme();
                    break;
            }
        }

        public static void LoadTheme()
        {
            ChangeTheme(CurrentTheme());
        }

        #region private methods

        private static Themes CurrentTheme()
        {
            return (Themes)Preferences.Get(SelectedThemeKey, (int)Themes.Light);
        }

        #endregion private methods
    }
}