using ISDS.Utils;
using System;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ISDS
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            new Thread(() =>
            {
                DataModel.Initialize();
            }).Start();

            MainPage = new NavigationPage(new VLogin())
            {
                BarBackgroundColor = Color.FromHex("#1FCABB"),
                BarTextColor = Color.White,
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
