using TCC_v1.DAL;
using TCC_v1.Model.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TCC_v1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UploadPage : ContentPage
    {
        public UploadPage()
        {
            InitializeComponent();
            lvForm.ItemSelected += LvForm_ItemSelect;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var data = new DatabaseAnswer();
            lvForm.ItemsSource = data.GetFormList();
        }

        private void LvForm_ItemSelect(object sender, SelectedItemChangedEventArgs e)
        {
            var selected = (FormAnswer) e.SelectedItem;
            if (selected == null)
                return;

            var data = new DatabaseAnswer();
            var fieldAnswers = data.GetFieldList(selected.Id);
            Navigation.PushAsync(new PaginaResposta(fieldAnswers, selected));
            lvForm.SelectedItem = null;
        }
    }
}