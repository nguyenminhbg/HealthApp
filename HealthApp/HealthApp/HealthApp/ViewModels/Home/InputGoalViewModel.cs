using HealthApp.Common.Bases;
using HealthApp.Models.Home;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace HealthApp.ViewModels.Home
{
    public class InputGoalViewModel : ViewModelBase
    {
        public ObservableCollection<DailyExcercise> ItemDaily { set; get; }
        INavigationService navigationService;
        public InputGoalViewModel(INavigationService _navigationService)
        {
            navigationService = _navigationService;
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            ItemDaily = new ObservableCollection<DailyExcercise>()
            {
                new DailyExcercise{ Name="Mon"},
                  new DailyExcercise{ Name="Tue"},
                    new DailyExcercise{ Name="Wed"},
                      new DailyExcercise{ Name="Thu"},
                        new DailyExcercise{ Name="Fri"},
                          new DailyExcercise{ Name="Sat"},
                            new DailyExcercise{ Name="Sun"},
            };
        }
        ICommand cmdBack;
        public ICommand CmdBack => cmdBack = cmdBack ?? new DelegateCommand(BackExcute);
        private async void BackExcute()
        {
            await navigationService.GoBackAsync();
        }

        Command cmdSelectDateEx;
        public Command CmdSelectDateEx => cmdSelectDateEx = cmdSelectDateEx ?? new Command<DailyExcercise>(SlecteDateExExcute);
        private void SlecteDateExExcute(DailyExcercise item)
        {
            if (item !=null)
                item.SelectedDate = !item.SelectedDate;
        }
    }
}
