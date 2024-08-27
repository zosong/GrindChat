﻿namespace GrindChat.MAUI
{
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            ServiceProvider = serviceProvider;

            MainPage = new AppShell();
        }
    }
}
