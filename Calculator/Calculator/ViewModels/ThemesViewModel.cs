using Calculator.Helpers;
using Calculator.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace Calculator.ViewModels
{
    public class ThemesViewModel : BaseViewModel
    {
        public ObservableCollection<Theme> Themes { get; set; } = new ObservableCollection<Theme>();

        public ThemesViewModel()
        {
            Themes.Add(new Theme
            {
                IdAndName = Enums.Themes.Light,
                Description = ConstantHelper.LightThemeDescription,
                ImagePath = ConstantHelper.LightThemeImage
            });

            Themes.Add(new Theme
            {
                IdAndName = Enums.Themes.Dark,
                Description = ConstantHelper.DarkThemeDescription,
                ImagePath = ConstantHelper.DarkThemeImage
            });
        }

        public static void ChangeTheme(Theme theme)
        {
            ThemeManager.ChangeTheme(theme.IdAndName);
        }

        public Theme GetCurrentTheme()
        {
            return Themes.First(theme => theme.IdAndName == ThemeManager.CurrentTheme());
        }
    }
}