using System.Collections.Generic;
using Xamarin.Forms;

namespace TCC_v1.Pages
{
    public class MenuListView : ListView
    {
        public MenuListView()
        {
            List<MenuItem> data = new MenuListData();

            ItemsSource = data;
            VerticalOptions = LayoutOptions.FillAndExpand;
            BackgroundColor = Color.Transparent;
            SeparatorColor = Color.Gray;

            var cell = new DataTemplate(typeof(MenuCell));

            cell.SetBinding(TextCell.TextProperty, "Title");

            ItemTemplate = cell;
        }
    }
}