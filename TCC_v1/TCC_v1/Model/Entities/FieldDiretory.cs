using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_v1.Model.Entities
{
    public class FieldDiretory : ObservatorBaseObject
    {
        private ObservableCollection<FieldBD> field = new ObservableCollection<FieldBD>();

        public ObservableCollection<FieldBD> Field
        {
            get { return field; }
            set { field = value; OnPropertyChanged(); }
        }
    }
}
