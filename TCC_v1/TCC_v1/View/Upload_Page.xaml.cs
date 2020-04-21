using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_v1.DAL;
using TCC_v1.Model.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TCC_v1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Upload_Page : ContentPage
    {
        public Upload_Page()
        {

            InitializeComponent();
            ToolbarItem r = new ToolbarItem();
            r.Icon = "reload.png";
            ToolbarItems.Add(r);

            r.Clicked += iconCliked;

            DALAswer dal = new DALAswer();

            lvForm.ItemsSource = dal.getFormListA();

            List<FieldAnswerBD> afa = new List<FieldAnswerBD>();

            afa = dal.getFieldListA();

            lvForm.ItemSelected += LvForm_ItemSelect;
            
        }

        private void iconCliked(object sender, EventArgs e)
        {
            DALAswer dal = new DALAswer();

            lvForm.ItemsSource = dal.getFormListA();
        }

        private void LvForm_ItemSelect(object sender, SelectedItemChangedEventArgs e)
        {
            FormAnswerBD selecionadoTEla = (FormAnswerBD)e.SelectedItem;

            if (selecionadoTEla == null)
            {
                return;
            }

            DALAswer dal = new DALAswer();
            
            List<FieldAnswerBD> y = new List<FieldAnswerBD>();

            y = dal.getFieldList(selecionadoTEla.IDFormAnswer);

            Navigation.PushAsync(new PaginaResposta(y, selecionadoTEla));

            lvForm.SelectedItem = null;
        }
    }
}
