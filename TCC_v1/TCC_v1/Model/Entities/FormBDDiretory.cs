using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_v1.Model.Entities
{
    public class FormBDDiretory : ObservatorBaseObject
    {
        private ObservableCollection<FormBD> formbd = new ObservableCollection<FormBD>();

        public ObservableCollection<FormBD> FormBD
        {
            get { return formbd; }
            set { formbd = value; OnPropertyChanged(); }
        }
    }
}
