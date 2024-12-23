namespace Wordle
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Register the routes explicitly
            Routing.RegisterRoute("MainMenu", typeof(MainMenu));
            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("HistoryPage", typeof(HistoryPage));
        }
    }
}
