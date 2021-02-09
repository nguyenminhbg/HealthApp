using HealthApp.Custom;
using HealthApp.Services.Home;
using HealthApp.ViewModels.Dashboard;
using HealthApp.ViewModels.Home;
using HealthApp.Views.Dashboard;
using HealthApp.Views.Home;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Essentials;

namespace HealthApp
{
    public partial class App : PrismApplication
    {
        const string ResourceId = "HealthApp.Localization.AppResources";
        static ResourceManager _resourceManager;
        public static ResourceManager ResourceManager => _resourceManager = _resourceManager ?? new ResourceManager(ResourceId, typeof(App).GetTypeInfo().Assembly);
        public App(IPlatformInitializer platformInitializer = null) : base(platformInitializer)
        {
            var culture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }

        protected async override void OnInitialized()
        {
            InitializeComponent();
            VersionTracking.Track();
            var result = await NavigationService.NavigateAsync(Routes.Dashboard);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterForNavigation(containerRegistry);
            RegisterService(containerRegistry);
        }
        void RegisterForNavigation(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<CustomNavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomeViewModel>();
            containerRegistry.RegisterForNavigation<DashboardPage, DashboardViewModel>();
            containerRegistry.RegisterForNavigation<InputGoalPage, InputGoalViewModel>();
        }

        void RegisterService(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IGetAccountService, GetAccountSevice>();
            containerRegistry.Register<IGetExerciseService, GetExerciseService>();
        }
    }
    public sealed partial class Routes
    {
        public static readonly string navigation = nameof(CustomNavigationPage);
        public static readonly Uri Dashboard = new Uri($"///{nameof(DashboardPage)}/{navigation}/{nameof(HomePage)}", UriKind.Absolute);
        public static readonly Uri InputGoal = new Uri($"{nameof(InputGoalPage)}", UriKind.Relative);
        public static readonly string Back2Step = "../../";
    }
}
