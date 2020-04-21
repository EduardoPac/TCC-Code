using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_v1.Model.Entities
{
    public class ItemDiretory : ObservatorBaseObject
    {
        private ObservableCollection<ItemBD> item = new ObservableCollection<ItemBD>();

        public ObservableCollection<ItemBD> Item
        {
            get { return item; }
            set { item = value; OnPropertyChanged(); }
        }
    }
}
