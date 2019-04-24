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
            await PopupService.ShowLoadingAsync();
	        await Navigation.PushAsync(new ThemesPage());
            await PopupService.HideLastPopupAsync();
        }

	    private async void CalculatorButton_OnTapped(object sender, EventArgs e)
	    {
	        await PopupService.ShowLoadingAsync();
	        await Navigation.PopToRootAsync(true);
	        await PopupService.HideLastPopupAsync();
	    }

	    private async void HistoryListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {
	        await PopupService.ShowLoadingAsync();

	        var item = (CalculatorItem) e.SelectedItem;

	        Navigation.InsertPageBefore(new CalculatorPage(item.Expression, item.Result),
	            Navigation.NavigationStack[0]);
	        await Navigation.PopToRootAsync();

	        await PopupService.HideLastPopupAsync();
	    }

	    private void MoveToLastButton_OnClicked(object sender, EventArgs e)
	    {
	        HistoryListView.ScrollTo(ViewModel.CalculatorItems[ViewModel.CalculatorItems.Count - 1],
	            ScrollToPosition.MakeVisible, true);
	    }

        #endregion private methods
    }
}