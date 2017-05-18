using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TCC_v1.Pages
{
    public class MenuListView : ListView
    {
        public MenuListView() {
            List<MenuItem> data = new MenuListData();

            ItemsSource = data;
            VerticalOptions = LayoutOptions.FillAndExpand;
            BackgroundColor = Color.Transparent;

            var cell = new DataTemplate(typeof(MenuCell));

            cell.SetBinding(MenuCell.TextProperty, "Titulo");

            
            
            ItemTemplate = cell;

        }
        
    }
}
