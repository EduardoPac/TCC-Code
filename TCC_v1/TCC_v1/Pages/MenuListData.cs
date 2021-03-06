﻿using System.Collections.Generic;
using TCC_v1.View;

namespace TCC_v1.Pages
{
    public class MenuListData : List<MenuItem>
    {
        public MenuListData()
        {
            Add(new MenuItem() {Title = "Forms", TargetType = typeof(TabPage)});
            Add(new MenuItem() {Title = "About", TargetType = typeof(AboutPage)});
        }
    }
}