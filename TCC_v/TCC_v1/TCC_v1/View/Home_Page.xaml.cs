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
            BindingContext = new FormDirectoryViewModel();
            lvForm.ItemSelected += LvForm_ItemSelect;
        }

        private void LvForm_ItemSelect(object sender, SelectedItemChangedEventArgs e)
        {
            var selected = (Form)e.SelectedItem;
            if (selected == null)
                return;
            
            Navigation.PushAsync(new FormsDynamicPage(selected));
            lvForm.SelectedItem = null;
        }
    }
}
