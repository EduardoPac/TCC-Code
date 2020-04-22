using System.Collections.Generic;
using TCC_v1.Model.Entities;
using TCC_v1.Model.Services;
using TCC_v1.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TCC_v1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DownloadPage : ContentPage
    {
        public DownloadPage()
        {
            InitializeComponent();
            BindingContext = new FormDirectoryViewModel();

            var atc = new ActivityIndicator
            {
                Color = Color.Green, IsRunning = true, IsVisible = false, HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            stack.Children.Add(atc);

            lvForm.ItemsSource = LoadFormModels();

            atc.IsVisible = true;
            lvForm.ItemSelected += LvForm_ItemSelect;
            atc.IsVisible = false;
        }

        private static IEnumerable<FormDb> LoadFormModels()
        {
            var formsToDownload = new List<FormDb>();

            var form1 = new FormDb
            {
                DataSetName = "Futebol Brasileiro",
                DataSetDescription = "Pesquisa de indice de torcida",
                Coordinator = "eduardo"
            };

            var form2 = new FormDb
            {
                DataSetName = "Dados Meteorológicos",
                DataSetDescription = "Formulario para coleta de dados meteorológicos",
                Coordinator = "thiago"
            };

            var form3 = new FormDb
            {
                DataSetName = "Pesquisa Pessoal",
                DataSetDescription = "Formulario Simples para teste de campos",
                Coordinator = "marcelo"
            };

            var form4 = new FormDb
            {
                DataSetName = "Protocolo Borboletas",
                DataSetDescription = "Pesquisa de campo para contagem amostras de borboletas",
                Coordinator = "ProtBorboleta"
            };

            var form5 = new FormDb
            {
                DataSetName = "Protocolo Mamiferos e Aves - modulo basico tl",
                DataSetDescription = "Pesquisa de campo para contagem de mamiferos e aves",
                Coordinator = "ProtMamifr_modulobas_tl"
            };

            var form6 = new FormDb
            {
                DataSetName = "Protocolo Mamiferos e Aves - modulo basico vestigio",
                DataSetDescription = "Pesquisa de campo para amostras de plantas lenhosas",
                Coordinator = "ProtMamifr_modulobas_vest"
            };

            var form7 = new FormDb
            {
                DataSetName = "Protocolo Mamiferos e Aves - modulo avançado",
                DataSetDescription = "Pesquisa de campo para amostras de plantas lenhosas",
                Coordinator = "ProtMamifr_moduloAv"
            };

            var form8 = new FormDb
            {
                DataSetName = "Protocolo Plantas Lenhosas - modulo 1",
                DataSetDescription = "Pesquisa de campo para amostras de plantas lenhosas",
                Coordinator = "ProtPlanta_modulo1"
            };

            var form9 = new FormDb
            {
                DataSetName = "Protocolo Plantas Lenhosas - modulo 2",
                DataSetDescription = "Pesquisa de campo para amostras de plantas lenhosas",
                Coordinator = "ProtPlanta_modulo2"
            };

            var form10 = new FormDb
            {
                DataSetName = "Protocolo Plantas Lenhosas - modulo 3",
                DataSetDescription = "Pesquisa de campo para amostras de plantas lenhosas",
                Coordinator = "ProtPlanta_modulo3"
            };

            var form11 = new FormDb
            {
                DataSetName = "Pesquisa Socioeconômica",
                DataSetDescription = "Pesquisa de validação do aplicativo DataSearch",
                Coordinator = "testeF"
            };


            formsToDownload.Add(form1);
            formsToDownload.Add(form2);
            formsToDownload.Add(form3);
            formsToDownload.Add(form4);
            formsToDownload.Add(form5);
            formsToDownload.Add(form6);
            formsToDownload.Add(form7);
            formsToDownload.Add(form8);
            formsToDownload.Add(form9);
            formsToDownload.Add(form10);
            formsToDownload.Add(form11);
            return formsToDownload;
        }

        private void LvForm_ItemSelect(object sender, SelectedItemChangedEventArgs e)
        {
            var selected = (FormDb) e.SelectedItem;

            if (selected == null)
                return;

            var downloaded=
                FormDirectoryService.LoadFormsDirectorySqLite(selected.Coordinator + ".json", selected);

            if (downloaded)
                DisplayAlert("Save", "Download form completed successfully", "OK");
            else
                DisplayAlert("Ops", "The form has already been downloaded", "OK");
            
            lvForm.SelectedItem = null;
        }
    }
}