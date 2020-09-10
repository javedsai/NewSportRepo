using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SportDirect.ViewModels;
using Xamarin.Forms;

namespace SportDirect.Services.Interfaces
{
    public interface INavigationService
    {
        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : BasePageViewModel;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BasePageViewModel;

        Task NavigateToAsync<TViewModel>(TViewModel viewModel) where TViewModel : BasePageViewModel;

        Task NavigateToAsync(Type viewModelType);

        Task NavigateToAsync(Type viewModelType, object parameter);

        Task ShellGoToAsync(string route);

        Task ShellNavigationPushAsync(Page page);

        Task ShellGoBackAsync();

        Task ShellNavigationPopAsync();

        Task ShellNavigationPopToRootAsync();

        Task NavigateBackAsync();

        Task RemoveLastFromBackStackAsync();

        Task NavigateToPopupAsync<TViewModel>(bool animate, TViewModel viewModel) where TViewModel : BasePageViewModel;

        Task NavigateToPopupAsync<TViewModel>(object parameter, bool animate, TViewModel viewModel) where TViewModel : BasePageViewModel;

        Task CloseAllPopupsAsync();

        Task ClosePopupsAsync();

        Type GetCurrentPageViewModel();

        bool SetCurrentPageTitle(string title);

        IList<Tuple<Type, Type, bool>> _mappingsRead { get; }

    }
}
