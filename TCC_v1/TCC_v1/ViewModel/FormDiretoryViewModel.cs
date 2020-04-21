
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_v1.Model.Entities;
using TCC_v1.Model.Services;
using Xamarin.Forms;

namespace TCC_v1.ViewModel
{
    class FormDiretoryViewModel: ObservatorBaseObject
    {
        public ObservableCollection<Form> Form { get; set; }

        bool isBusy = false;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        //Este Comando serve para conectar com a interface para adicionar um elemento e invocar a ação que está vinculado
        public Command CarregarDiretorioCommand { get; set; }

        public FormDiretoryViewModel()
        {
            Form = new ObservableCollection<Form>();
            IsBusy = false;
            CarregarDiretorioCommand = new Command((obj) => CarregarDiretorio());
        }

        async void CarregarDiretorio()
        {
            if (!isBusy)
            {
                isBusy = true;

                await Task.Delay(1);

               // var carregadoDiretorio = FormDiretoryService.LoadFormsDirectorySqlite();

                //foreach (var form in carregadoDiretorio.Form)
                //{
                //    Form.Add(form);
                //}

                isBusy = false;
            }
        }
    }
}
