using AutoCoolerMobile.View;

namespace AutoCoolerMobile
{
    public partial class App : Application
    {
        public App()
        {
            AutoCoolerMobile.AppConfig.Load();

            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
