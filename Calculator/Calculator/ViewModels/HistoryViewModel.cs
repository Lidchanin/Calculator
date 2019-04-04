using Calculator.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calculator.ViewModels
{
    public class HistoryViewModel : BaseViewModel
    {
        public ObservableCollection<CalculatorItem> CalculatorItems { get; set; }

        public ICommand ClearHistoryCommand { get; }

        public HistoryViewModel()
        {
            ClearHistoryCommand = new Command(ClearHistory);
        }

        public async Task InitData()
        {
            CalculatorItems = new ObservableCollection<CalculatorItem>(await App.Database.GetAll());
        }

        private async void ClearHistory()
        {
            await App.Database.DeleteAll();
            CalculatorItems = new ObservableCollection<CalculatorItem>();
        }
    }
}