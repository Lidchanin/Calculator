using Calculator.Models;
using System;
using Xamarin.Forms;
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

        protected override async void OnAppearing()
	    {
	        base.OnAppearing();

            await ViewModel.InitData();
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

	    private async void HistoryListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {
	        var item = (CalculatorItem) e.SelectedItem;

	        Navigation.InsertPageBefore(new CalculatorPage(item.Expression, item.Result),
	            Navigation.NavigationStack[0]);
	        await Navigation.PopToRootAsync();
        }

	    private void MoveToLastButton_OnClicked(object sender, EventArgs e)
	    {
	        HistoryListView.ScrollTo(ViewModel.CalculatorItems[ViewModel.CalculatorItems.Count - 1],
	            ScrollToPosition.MakeVisible, true);
	    }

        #endregion private methods
    }
}