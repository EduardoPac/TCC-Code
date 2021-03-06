﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TCC_v1.Pages
{
    public class RootPage : MasterDetailPage
    {
        private readonly MenuPage menuPage;

        public RootPage()
        {
            menuPage = new MenuPage();
            menuPage.Menu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as MenuItem);
            Master = menuPage;
            Detail = new NavigationPage(new TabPage());
        }

        private async void NavigateTo(MenuItem menu)
        {
            if (menu == null)
                return;

            var displayPage = (Page) Activator.CreateInstance(menu.TargetType);

            try
            {
                Detail = new NavigationPage(displayPage);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("ERRO", "Erro " + ex.Message, "OK");
            }

            menuPage.Menu.SelectedItem = null;
            IsPresented = false;
        }
    }
}