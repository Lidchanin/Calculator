using Calculator.Pages.PopupPages;
using System.Linq;
using System.Threading.Tasks;
using static Rg.Plugins.Popup.Services.PopupNavigation;

namespace Calculator.Services
{
    public sealed class PopupService : IPopupService
    {
        public async Task ShowLoadingAsync()
        {
            await Instance.PushAsync(new LoadingPopupPage());
        }

        public async Task HideLastPopupAsync()
        {
            if (Instance.PopupStack.Any())
                await Instance.PopAsync();
        }
    }
}