namespace Wordle
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("MainMenu", typeof(MainMenu));
            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("HistoryPage", typeof(HistoryPage));
            Routing.RegisterRoute("SettingsPage", typeof(SettingsPage));
        }
    }
}
