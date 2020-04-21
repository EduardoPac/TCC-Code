using System.Collections.ObjectModel;
using TCC_v1.Model.Entities;
using TCC_v1.Model.Services;

namespace TCC_v1.ViewModel
{
    internal class FormDirectoryViewModel: ObservableBaseObject
    {
        public ObservableCollection<Form> Form { get; set; }

        public FormDirectoryViewModel()
        {
            Form = new ObservableCollection<Form>();
            LoadDirectory();
        }

        private void LoadDirectory()
        {
            var loadDirectory = FormDirectoryService.LoadFormsDirectorySqlite();

            Form = new ObservableCollection<Form>(loadDirectory.Form);
        }
    }
}
