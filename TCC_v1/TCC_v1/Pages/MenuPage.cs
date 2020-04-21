using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TCC_v1.Pages
{
    public class MenuPage : ContentPage
    {
        public ListView Menu { get; set; }

        public MenuPage()
        {
            Title = "Menu";

            Padding = new Thickness(8, 16, 0, 0);

            BackgroundColor = Color.FromHex("#003366");

            Menu = new MenuListView();

            var beachImage = new Image { Aspect = Aspect.AspectFit, HeightRequest = 150};
            beachImage.Source = "logomenu.png";
            beachImage.Margin = new Thickness(0, 0, 0, 16);

            var layout = new StackLayout
            {
                Margin= new Thickness(0,10,0,0),
                Spacing = 0,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            

            layout.Children.Add(beachImage);
            layout.Children.Add(Menu);
            

            Content = layout;


        }
    }
}
