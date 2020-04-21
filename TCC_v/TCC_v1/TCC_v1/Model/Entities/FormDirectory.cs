using System.Collections.ObjectModel;

namespace TCC_v1.Model.Entities
{
    public class FormDirectory: ObservableBaseObject
    {
        private ObservableCollection<Form> form = new ObservableCollection<Form>();

        public ObservableCollection<Form> Form
        {
            get { return form; }
            set { form = value; OnPropertyChanged(); }
        }
    }
}
