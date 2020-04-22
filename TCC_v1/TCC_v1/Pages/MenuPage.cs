using Xamarin.Forms;

namespace TCC_v1.Pages
{
    public class MenuPage : ContentPage
    {
        public ListView Menu { get; private set; }

        public MenuPage()
        {
            Title = "Menu";
            Padding = new Thickness(8, 24, 0, 0);

            BackgroundColor = Color.White;

            Menu = new MenuListView();

            var beachImage = new Image
            {
                Aspect = Aspect.AspectFit,
                HeightRequest = 150,
                Source = "logomenu.png",
                Margin = new Thickness(0, 0, 0, 24)
            };

            var layout = new StackLayout
            {
                Margin = new Thickness(0, 10, 0, 0),
                Spacing = 0,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            layout.Children.Add(beachImage);
            layout.Children.Add(Menu);
            
            Content = layout;
        }
    }
}