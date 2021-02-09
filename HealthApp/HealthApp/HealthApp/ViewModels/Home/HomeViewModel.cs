using HealthApp.Common.Bases;
using HealthApp.Models.Account;
using HealthApp.Models.Home;
using HealthApp.Services.Home;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HealthApp.ViewModels.Home
{
    public class HomeViewModel : ViewModelBase
    {
        readonly IGetAccountService serviceAcc;
        readonly IGetExerciseService serviceEx;
        readonly INavigationService navigationService;
        public Tracking Track { set; get; } = Tracking.Weekly;
        public AccountInfo Account { set; get; }
        public List<Exercise> Exercises { set; get; }
        public Exercise Exercise { set; get; }
        public HomeViewModel(INavigationService _navigationService, IGetAccountService _serviceAcc, IGetExerciseService _serviceEx)
        {
            navigationService = _navigationService;
            serviceAcc = _serviceAcc;
            serviceEx = _serviceEx;
        }
        public override async Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            Account = await serviceAcc.GetAccountInfo("1");
            Exercises = await serviceEx.GetExcerceseInfo(1);
            if (Exercises != null && Exercises.Count > 0)
            {
                Exercise = Exercises[0];
                Exercises[0].IsSelectedEx = true;
                oldItem = Exercises[0];
            }
        }
        ICommand cmdChangeGoal;
        public ICommand CmdChangeGoal => cmdChangeGoal = cmdChangeGoal ?? new DelegateCommand(ChangeGoalExcute);

        private async void ChangeGoalExcute()
        {
            var result= await navigationService.NavigateAsync(Routes.InputGoal);
            Debug.WriteLine("result: " + result.Exception);
        }

        Command cmdSelectedItem;
        public Command CmdSelectedItem => cmdSelectedItem = cmdSelectedItem ?? new Command<Exercise>(ExcuteItem);
        Exercise oldItem;
        private void ExcuteItem(Exercise item)
        {
            if (oldItem != null)
                oldItem.IsSelectedEx = false;
            item.IsSelectedEx = true;
            oldItem = item;
        }

        Command cmdTrack;
        public Command CmdTrack => cmdTrack = cmdTrack ?? new Command<Tracking>(ExcuteTrack);
        private void ExcuteTrack(Tracking tracking)
        {
            Track = tracking;
        }
    }
    public enum Tracking
    {
        Weekly,
        Monthly,
        Daily
    }
}
