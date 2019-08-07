﻿using DomiMantApp.Vistas;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DomiMantApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new SuplidoresTabbedPage();
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
