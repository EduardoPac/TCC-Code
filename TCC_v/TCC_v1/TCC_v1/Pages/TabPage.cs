using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using TCC_v1.View;
using Xamarin.Forms;

namespace TCC_v1.Pages
{
    public class TabPage : TabbedPage
    {
        public TabPage()
        {
            Title = "TCC";
            
            Children.Add(new Download_Page());
            Children.Add(new Home_Page());
            Children.Add(new Upload_Page());


            this.SelectedItem = Children[1];
        }
        
    }
}
