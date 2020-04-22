using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TCC_v1.Model.Entities
{
    public class ObservatoryBaseObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void OnPropertyChanged([CallerMemberName] string dataSetName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(dataSetName));
    }
}