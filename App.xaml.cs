namespace MauiApp8_weatherApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            VersionTracking.Track();
            if(VersionTracking.IsFirstLaunchEver == true)
            {
                MainPage = new NewPage1();
            }
            else
            {
                MainPage = new NewPage2();
            }
        }
    }
}
