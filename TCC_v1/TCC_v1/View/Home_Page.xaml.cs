using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_v1.DAL;
using TCC_v1.Model.Entities;
using TCC_v1.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TCC_v1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home_Page : ContentPage
    {
        public Home_Page()
        {
            InitializeComponent();
            ToolbarItem r = new ToolbarItem();
            r.Icon = "reload.png";
            ToolbarItems.Add(r);
            //BindingContext = new FormDiretoryViewModel();
           // r.SetBinding(MenuItem.CommandProperty, new Binding("CarregarDiretorioCommand"));
            
            r.Clicked += iconCliked;

            DALA dal = new DALA();

            lvForm.ItemsSource = dal.getFormList() ;

            lvForm.ItemSelected += LvForm_ItemSelect;
        }

        private void iconCliked(object sender, EventArgs e)
        {
            DALA dal = new DALA();

            lvForm.ItemsSource = dal.getFormList();
        }

        private void LvForm_ItemSelect(object sender, SelectedItemChangedEventArgs e)
        {
            FormBD selecionadoTEla = (FormBD)e.SelectedItem;
            if (selecionadoTEla == null)
            {
               return;
            }

            ConvertClass cv = new ConvertClass();

            Form selecionado = cv.ConvBDtoForm(selecionadoTEla);

            List<FieldAnswerBD> k = new List<FieldAnswerBD>();
            int x = 0;
            Navigation.PushAsync(new Forms_Dinamic_Page(selecionado, x, k));
            lvForm.SelectedItem = null;
        }
    }
}
