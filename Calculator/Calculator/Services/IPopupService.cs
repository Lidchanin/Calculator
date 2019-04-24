using System.Threading.Tasks;

namespace Calculator.Services
{
    public interface IPopupService
    {
        Task ShowLoadingAsync();

        Task HideLastPopupAsync();
    }
}