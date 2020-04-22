using System.Collections.Generic;
using TCC_v1.DAL;
using TCC_v1.Model.Entities;
using TCC_v1.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TCC_v1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            lvForm.ItemSelected += LvForm_ItemSelect;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var database = new Database();
            lvForm.ItemsSource = database.GetFormList();
        }

        private void LvForm_ItemSelect(object sender, SelectedItemChangedEventArgs e)
        {
            var selected = (FormDb)e.SelectedItem;
            if (selected == null)
                return;

            var cv = new ConvertClass();
            var form = ConvertClass.ConvertDataFormToForm(selected);

            var fieldAnswers = new List<FieldAnswer>();
            const int index = 0;
            Navigation.PushAsync(new FormsDynamicPage(form, index, fieldAnswers));
            lvForm.SelectedItem = null;
        }
    }
}
