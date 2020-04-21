using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCC_v1.Pages;
using TCC_v1.View;
using Xamarin.Forms;

namespace TCC_v1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new RootPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
