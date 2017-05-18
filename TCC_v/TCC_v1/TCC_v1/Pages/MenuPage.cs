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

            Padding = new Thickness(10, 30, 0, 0);

            BackgroundColor = Color.FromHex("333333");

            Menu = new MenuListView();

            var beachImage = new Image { Aspect = Aspect.AspectFit };
            beachImage.Source = "banner.png";

            var layout = new StackLayout
            {
                Margin= new Thickness(0,10,0,0),
                Spacing = 0,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            var sair = new Button
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Transparent,
                Text = "Sair",
                TextColor = Color.White
        };

            layout.Children.Add(beachImage);
            layout.Children.Add(Menu);
            layout.Children.Add(sair);

            

            Content = layout;


        }
    }
}
