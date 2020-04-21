using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_v1.Model.Entities
{
    class FormAnswerDiretory : ObservatorBaseObject
    {
        private ObservableCollection<FormAnswer> form = new ObservableCollection<FormAnswer>();

        public ObservableCollection<FormAnswer> Form
        {
            get { return form; }
            set { form = value; OnPropertyChanged(); }
        }
    }
}
