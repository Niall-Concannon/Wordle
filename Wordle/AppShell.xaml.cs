﻿namespace Wordle
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("MainMenu", typeof(MainMenu));
            Routing.RegisterRoute("MainPage", typeof(MainPage));
        }
    }
}
