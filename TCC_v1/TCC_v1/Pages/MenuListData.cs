using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_v1.View;

namespace TCC_v1.Pages
{
    public class MenuListData : List<MenuItem>
    {
        public MenuListData()
        {

            this.Add(new MenuItem() { Titulo = "Forms" , TargetType = typeof(TabPage) });

            this.Add(new MenuItem() { Titulo = "About", TargetType = typeof(About_Page) });

        }
    }
}
