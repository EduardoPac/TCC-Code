using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_v1.Model.Entities
{
    public class FormDiretory: ObservatorBaseObject
    {
        private ObservableCollection<Form> form = new ObservableCollection<Form>();

        public ObservableCollection<Form> Form
        {
            get { return form; }
            set { form = value; OnPropertyChanged(); }
        }
    }
}
