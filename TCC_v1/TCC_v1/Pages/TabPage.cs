using TCC_v1.View;
using Xamarin.Forms;

namespace TCC_v1.Pages
{
    public class TabPage : TabbedPage
    {
        public TabPage()
        {
            Title = "DataSearch";

            Children.Add(new DownloadPage());
            Children.Add(new HomePage());
            Children.Add(new UploadPage());

            BackgroundColor = Color.White;

            SelectedItem = Children[1];
        }
    }
}