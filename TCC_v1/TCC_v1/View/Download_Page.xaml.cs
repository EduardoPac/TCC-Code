using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_v1.Model.Entities;
using TCC_v1.Model.Services;
using TCC_v1.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TCC_v1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Download_Page : ContentPage
    {
        public Download_Page()
        {
            InitializeComponent();
            //ToolbarItem r = new ToolbarItem();
            //r.Icon = "sync.png";
            //ToolbarItem d = new ToolbarItem();
            //d.Icon = "down.png";

            //ToolbarItems.Add(r);
            //ToolbarItems.Add(d);
            BindingContext = new FormDiretoryViewModel();

            ActivityIndicator atc = new ActivityIndicator { Color = Color.Green, IsRunning = true, IsVisible = false, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
            stack.Children.Add(atc);
            
            List<FormBD> dowload = new List<FormBD>();

            FormBD aux1 = new FormBD();
            FormBD aux2 = new FormBD();
            FormBD aux3 = new FormBD();

            FormBD aux4 = new FormBD();
            FormBD aux5 = new FormBD();
            FormBD aux6 = new FormBD();
            FormBD aux7 = new FormBD();
            FormBD aux8 = new FormBD();
            FormBD aux9 = new FormBD();
            FormBD aux10 = new FormBD();
            FormBD aux11 = new FormBD();

            aux1.DatasetName = "Futebol Brasileiro";
            aux1.DataSetDescription = "Pesquisa de indice de torcida";
            aux1.Coordinator = "eduardo";

            aux2.DatasetName = "Dados Meteorológicos";
            aux2.DataSetDescription = "Formulario para coleta de dados meteorológicos";
            aux2.Coordinator = "thiago";

            aux3.DatasetName = "Pesquisa Pessoal";
            aux3.DataSetDescription = "Formulario Simples para teste de campos";
            aux3.Coordinator = "marcelo";

            aux4.DatasetName = "Protocolo Borboletas";
            aux4.DataSetDescription = "Pesquisa de campo para contagem amostras de borboletas";
            aux4.Coordinator = "ProtBorboleta";

            aux5.DatasetName = "Protocolo Mamiferos e Aves - modulo basico tl";
            aux5.DataSetDescription = "Pesquisa de campo para contagem de mamiferos e aves";
            aux5.Coordinator = "ProtMamifr_modulobas_tl";

            aux6.DatasetName = "Protocolo Mamiferos e Aves - modulo basico vestigio";
            aux6.DataSetDescription = "Pesquisa de campo para amostras de plantas lenhosas";
            aux6.Coordinator = "ProtMamifr_modulobas_vest";

            aux7.DatasetName = "Protocolo Mamiferos e Aves - modulo avançado";
            aux7.DataSetDescription = "Pesquisa de campo para amostras de plantas lenhosas";
            aux7.Coordinator = "ProtMamifr_moduloAv";

            aux8.DatasetName = "Protocolo Plantas Lenhosas - modulo 1";
            aux8.DataSetDescription = "Pesquisa de campo para amostras de plantas lenhosas";
            aux8.Coordinator = "ProtPlanta_modulo1";

            aux9.DatasetName = "Protocolo Plantas Lenhosas - modulo 2";
            aux9.DataSetDescription = "Pesquisa de campo para amostras de plantas lenhosas";
            aux9.Coordinator = "ProtPlanta_modulo2";

            aux10.DatasetName = "Protocolo Plantas Lenhosas - modulo 3";
            aux10.DataSetDescription = "Pesquisa de campo para amostras de plantas lenhosas";
            aux10.Coordinator = "ProtPlanta_modulo3";

            aux11.DatasetName = "Pesquisa Socioeconômica";
            aux11.DataSetDescription = "Pesquisa de validação do aplicativo DataSearch";
            aux11.Coordinator = "testeF";


            dowload.Add(aux1);
            dowload.Add(aux2);
            dowload.Add(aux3);
            dowload.Add(aux4);
            dowload.Add(aux5);
            dowload.Add(aux6);
            dowload.Add(aux7);
            dowload.Add(aux8);
            dowload.Add(aux9);
            dowload.Add(aux10);
            dowload.Add(aux11);

            lvForm.ItemsSource = dowload;

            atc.IsVisible = true;
            lvForm.ItemSelected += LvForm_ItemSelect;
            atc.IsVisible = false;
            //r.SetBinding(MenuItem.CommandProperty, new Binding("CarregarDiretorioCommand"));
        }

        private void LvForm_ItemSelect(object sender, SelectedItemChangedEventArgs e)
        {
            FormBD selecionadoTEla = (FormBD)e.SelectedItem;

            if (selecionadoTEla == null)
            {
                return;
            }

            FormDiretoryService pa = new FormDiretoryService();

            Boolean ca = pa.LoadFormsDirectorySqlite(selecionadoTEla.Coordinator + ".json", selecionadoTEla);

            if(ca == false) { DisplayAlert("Ops", "The form has already been downloaded", "OK"); }
            else { DisplayAlert("Save", "Download form completed successfully", "OK"); }

           

            lvForm.SelectedItem = null;
        }
    }
}
