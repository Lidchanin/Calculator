using System;
using Xamarin.Forms.Xaml;

namespace Calculator.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistoryPage
	{
	    public HistoryPage()
	    {
	        InitializeComponent();
	    }

        #region private methods

	    private async void ThemesButton_OnTapped(object sender, EventArgs e)
	    {
	        ThemesButton.IsEnabled = false;
	        await Navigation.PushAsync(new ThemesPage());
	        ThemesButton.IsEnabled = true;
	    }

	    private async void CalculatorButton_OnTapped(object sender, EventArgs e)
	    {
	        CalculatorButton.IsEnabled = false;
	        await Navigation.PopToRootAsync(true);
	        CalculatorButton.IsEnabled = true;
	    }

        #endregion private methods
    }
}