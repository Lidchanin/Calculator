using Calculator.Services;
using Xamarin.Forms.Xaml;

namespace Calculator.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasePage
    {
        public IPopupService PopupService = new PopupService();

        public BasePage()
        {
            InitializeComponent();
        }
    }
}