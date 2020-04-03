using Prism;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace PrismSportApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged, IActiveAware, INavigatedAware
    {
        public bool IsActive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler IsActiveChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigationService NavigationService { get; set; }
        public IPageDialogService PageDialogService { get; set; }
        public BaseViewModel(PageDialogService pageDialogService, INavigationService navigationService)
        {
            this.PageDialogService = pageDialogService;
            this.NavigationService = navigationService;
        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }
        public async Task ShowMessage(string title, string message, string cancel, string accept = null)
        {
            await PageDialogService.DisplayAlertAsync(title, message, accept, cancel);
        }      

        
    }
}
