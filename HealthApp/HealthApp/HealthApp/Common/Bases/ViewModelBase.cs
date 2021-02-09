using Acr.UserDialogs;
using AsyncAwaitBestPractices;
using HealthApp.Localization;
using Prism.AppModel;
using Prism.DryIoc;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HealthApp.Common.Bases
{
    public class ViewModelBase : BindableBase, INavigationAware, IPageLifecycleAware, IInitialize, IDestructible
    {
        public ViewModelBase(/*IEventAggregator eventAggregator*/)
        {
            var container = (Application.Current as PrismApplication).Container;
        }

        public virtual Command CreateCommand(Action action)
        {
            return new Command(action);
        }

        public virtual Command<bool> CreateCommand(Action<bool> action, bool param)
        {
            return CreateCommand<bool>(action, (c) => param == c);
        }

        public virtual Command<T> CreateCommand<T>(Action<T> action)
        {
            return CreateCommand<T>(action, (c) => true);
        }

        public virtual Command<T> CreateCommand<T>(Action<T> action, Func<T, bool> CanExecuteAction)
        {
            return new Command<T>(action, CanExecuteAction);
        }

        public virtual Command<bool> CreateAsyncCommand(Func<bool, Task> action, bool param)
        {
            return CreateAsyncCommand(action, (c) => param == c);
        }

        public virtual Command<bool> CreateAsyncCommand(Func<Task> action, bool param)
        {
            return new Command<bool>((arg) => CheckClick(action), (c) => param == c);
        }

        public virtual Command CreateAsyncCommand(Func<Task> action)
        {
            return new Command(() => CheckClick(action));
        }

        public virtual Command<T> CreateAsyncCommand<T>(Func<T, Task> action)
        {
            return CreateCommand<T>((arg) => CheckClick(action, arg), (c) => true);
        }

        public virtual Command<T> CreateAsyncCommand<T>(Func<T, Task> action, Func<T, bool> CanExecuteAction)
        {
            return new Command<T>((arg) => CheckClick(action, arg), CanExecuteAction);
        }

        async void CheckClick(Func<Task> action)
        {
            if (Clicked)
                return;
            Clicked = true;
            await action.Invoke();
            await Task.Delay(50);
            Clicked = false;
        }

        async void CheckClick<T>(Func<T, Task> action, T arg)
        {
            if (Clicked)
                return;
            Clicked = true;
            await action.Invoke(arg);
            await Task.Delay(50);
            Clicked = false;
        }

        async void CheckClick<T>(Func<T, Task> action)
        {
            if (Clicked)
                return;
            Clicked = true;
            await action.Invoke(default(T));
            await Task.Delay(50);
            Clicked = false;
        }

        public virtual string L(string resourceKey, params string[] objects)
        {
            return LocalizedResourceHelper.GetText(resourceKey, objects);
        }

        public virtual bool Clicked { get; set; }

        bool busy;
        public virtual bool IsBusy
        {
            get => busy;
            set
            {
                if (busy == value)
                {
                    return;
                }
                busy = value;
                if (busy)
                {
                    ShowLoading();
                }
                else
                {
                    HideLoading();
                }
            }
        }

        public virtual bool IsLoaded { get; set; } = false;
        public bool PopupShown { get; set; }
        public bool LoadingShown => PopupShown;

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual async Task InitAsync(INavigationParameters parameters)
        {

        }

        bool _loaded;
        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            OnNavigatedToAsync(parameters).SafeFireAndForget();
            if (!_loaded)
            {
                _loaded = true;
                InitAsync(parameters).SafeFireAndForget();
            }
        }

        public virtual Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            return Task.Run(() => { });
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual async void Toast(string message)
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                await Task.Delay(100);
            }
            UserDialogs.Instance.Toast(message);
        }

        public virtual void ShowLoading()
        {
            UserDialogs.Instance.ShowLoading();
        }

        public void HideLoading()
        {
            UserDialogs.Instance.HideLoading();
        }


        public virtual void Destroy()
        {
        }

        public virtual void OnAppearing()
        {
        }

        public virtual void OnDisappearing()
        {
        }
    }
}
