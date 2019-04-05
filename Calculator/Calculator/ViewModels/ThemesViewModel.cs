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
                Description = "Some desc 1asdasdlj1asdasdlj1asdasdlj1asdasdlj1asdasdlj1asdasdlj1asdasdljфыввффывффыфвфывфццвфцвыф",
                ImagePath = "https://distributor.golding.eu/desk-calculator-white--4050-02--hd.jpg"
            });

            Themes.Add(new Theme
            {
                IdAndName = Enums.Themes.Dark,
                Description = "Some desc 1222222222222222222222 222222222222222222222222222222222222222 222222222222222222222222222222222222",
                ImagePath = "https://images-na.ssl-images-amazon.com/images/I/61TWIQWJS1L._SY741_.jpg"
            });
        }

        public void ChangeTheme(Theme theme)
        {
            ThemeManager.ChangeTheme(theme.IdAndName);
        }

        public Theme GetCurrentTheme()
        {
            return Themes.First(theme => theme.IdAndName == ThemeManager.CurrentTheme());
        }
    }
}