using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TCC_v1.Model.Entities;
using Xamarin.Forms;

namespace TCC_v1.ViewModel
{
    internal class FormDirectoryViewModel : ObservatoryBaseObject
    {
        public ObservableCollection<Form> Form { get; set; }

        public FormDirectoryViewModel()
        {
            Form = new ObservableCollection<Form>();
        }
    }
}