using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            r.Icon = "sync.png";
            ToolbarItems.Add(r);
            BindingContext = new FormDiretoryViewModel();
            r.SetBinding(MenuItem.CommandProperty, new Binding("CarregarDiretorioCommand"));

            lvForm.ItemSelected += LvForm_ItemSelect;
        }

        private void LvForm_ItemSelect(object sender, SelectedItemChangedEventArgs e)
        {
            Form selecionado = (Form)e.SelectedItem;
            if (selecionado == null)
            {
                return;
            }
            Navigation.PushAsync(new Forms_Dinamic_Page(selecionado));
            lvForm.SelectedItem = null;
        }
    }
}
