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
                ImagePath = "https://monosnap.com/image/fg6GxxbUSW6iHC0wkvJotLFUUFRz1w.png"
                //ImagePath = "https://monosnap.com/image/6PpVuvzQmNuUSlQyTMyCPgQlKmoQt3.png"
            });

            Themes.Add(new Theme
            {
                IdAndName = Enums.Themes.Dark,
                Description = ConstantHelper.DarkThemeDescription,
                ImagePath = "https://monosnap.com/image/XR50ALRuNS2dLO6huQ4hd5hwWaE6qo.png"
                //ImagePath = "https://monosnap.com/image/aSR6rTB7gfy57jpS8GSVg7RsRuMtTW.png"
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