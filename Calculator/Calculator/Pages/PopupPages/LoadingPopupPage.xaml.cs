using Xamarin.Forms.Xaml;

namespace Calculator.Pages.PopupPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPopupPage
    {
        public LoadingPopupPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed() => true;

        protected override bool OnBackgroundClicked() => true;
    }
}