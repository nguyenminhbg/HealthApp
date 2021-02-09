using HealthApp.Common.Bases;
using Prism.Commands;
using Prism.Navigation;
using System.Windows.Input;

namespace HealthApp.ViewModels.Dashboard
{
    public class DashboardViewModel : ViewModelBase
    {
        INavigationService navigationService;
        public DashboardViewModel(INavigationService _navigationService)
        {
            navigationService = _navigationService;
        }
    }
}
