using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_v1.DAL;

namespace TCC_v1.Model.Entities
{
    public class ItemBD : ObservatorBaseObject
    {
        [PrimaryKey, AutoIncrement]
        public int IDItem { get; set; }

        public int IDField2 { get; set; }
        
        public int IDFormP2 { get; set; }
        

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }
        
        private string codigoItem;

        
        public string CodigoItem
        {
            get { return codigoItem; }
            set { codigoItem = value; OnPropertyChanged(); }
        }
        
    }
}
