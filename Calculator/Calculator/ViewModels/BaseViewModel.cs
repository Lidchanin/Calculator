using System.ComponentModel;
using Calculator.Services;

namespace Calculator.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IPopupService PopupService = new PopupService();
    }
}