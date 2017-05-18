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
    public partial class Upload_Page : ContentPage
    {
        public Upload_Page()
        {
            
            InitializeComponent();
            ToolbarItem r = new ToolbarItem();
            r.Icon = "sync.png";
            ToolbarItem u = new ToolbarItem();
            u.Icon = "up.png";

            ToolbarItems.Add(r);
            ToolbarItems.Add(u);

        }
    }
}
