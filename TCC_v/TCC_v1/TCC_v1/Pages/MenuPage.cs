using Xamarin.Forms;

namespace TCC_v1.Pages
{
    public class MenuPage : ContentPage
    {
        public ListView Menu { get; private set; }
        public MenuPage()
        {
            Title = "Menu";
            Padding = new Thickness(10, 30, 0, 0);
            BackgroundColor = Color.FromHex("333333");
            Menu = new MenuListView();
            var beachImage = new Image {Aspect = Aspect.AspectFit, Source = "banner.png", Margin = new Thickness(0,0,0,16)};
            var layout = new StackLayout
            {
                Margin= new Thickness(0,10,0,10),
                Spacing = 0,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            
            layout.Children.Add(beachImage);
            layout.Children.Add(Menu);
            
            Content = layout;
        }
    }
}
