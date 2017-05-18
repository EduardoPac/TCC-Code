using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_v1.Model.Entities
{
    public class Item
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string codigoItem;

        public string CodigoItem
        {
            get { return codigoItem; }
            set { codigoItem = value; }
        }
    }
}
