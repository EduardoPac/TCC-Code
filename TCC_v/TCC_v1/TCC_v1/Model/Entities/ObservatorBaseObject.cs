using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TCC_v1.Model.Entities
{
    public class ObservatorBaseObject:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate
        {
        };

        public void OnPropertyChanged([CallerMemberName] string datasetName = "")
        {
            if (PropertyChanged == null)
            {
                return;
            }
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(datasetName));
        }


    }
}
