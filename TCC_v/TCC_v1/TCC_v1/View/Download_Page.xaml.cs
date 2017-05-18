using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TCC_v1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Download_Page : ContentPage
    {
        public Download_Page()
        {
            InitializeComponent();
            ToolbarItem r = new ToolbarItem();
            r.Icon = "sync.png";
            ToolbarItem d = new ToolbarItem();
            d.Icon = "down.png";

            ToolbarItems.Add(r);
            ToolbarItems.Add(d);
        }
    }
}
