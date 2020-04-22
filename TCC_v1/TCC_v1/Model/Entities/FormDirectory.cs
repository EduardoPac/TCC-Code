using System.Collections.ObjectModel;

namespace TCC_v1.Model.Entities
{
    public class FormDirectory : ObservatoryBaseObject
    {
        private ObservableCollection<FormDb> formDb = new ObservableCollection<FormDb>();
    }
}
