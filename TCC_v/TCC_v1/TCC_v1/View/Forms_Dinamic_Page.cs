using System;
using System.Threading.Tasks;
using TCC_v1.Model.Entities;
using Xamarin.Forms;

namespace TCC_v1.View
{
    internal class FormsDynamicPage: CarouselPage
    {
        public FormsDynamicPage(Form form)
        {
            Title = form.DataSetName;

            var e = new ToolbarItem {Text = "Salvar" };
            e.Clicked += (sender, args) => { SaveForm(); };

            ToolbarItems.Add(e);

            var padding = new Thickness(0, 16, 0, 0);

            var fields = GenerateFields(form);

            var page = new ContentPage
            {
                Padding = padding,
                Content = new ScrollView
                {
                    Content = fields
                }
            };

            Children.Add(page);
        }

        private async void SaveForm()
        {
            await DisplayAlert ("Forms", "you save answers in json", "OK");
        }

        private static StackLayout GenerateFields(Form form)
        {
            var stack = new StackLayout() { Margin = new Thickness(8) };

            foreach (var field in form.Fields)
            {
                stack.Children.Add(new Label
                    {Text = field.FieldName, FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))});

                TextField(field, stack);
                NumberField(field, stack);
                DateField(field, stack);
                TimeField(field, stack);
            }

            return stack;
        }

        private static void TimeField(Field field, StackLayout stack)
        {
            if (field.Type != "Time") return;
            
            var timePicker = new TimePicker() {HorizontalOptions = LayoutOptions.FillAndExpand};
            stack.Children.Add(timePicker);
        }

        private static void DateField(Field field, StackLayout stack)
        {
            if (field.Type != "Date") return;
            
            var datePicker = new DatePicker
            {
                Format = "D",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            stack.Children.Add(datePicker);
        }

        private static void NumberField(Field field, StackLayout stack)
        {
            if (field.Type != "Number") return;
            
            stack.Children.Add(new Editor
                {FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)), Keyboard = Keyboard.Numeric});
        }

        private static void TextField(Field field, StackLayout stack)
        {
            if (field.Type != "String") return;
            
            if (field.SelectFromList)
            {
                var pic = new Picker();
                foreach (var item in field.ListItems)
                {
                    pic.Items.Add(item.Name);
                }

                stack.Children.Add(pic);
            }
            else
            {
                stack.Children.Add(new Editor
                    {FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)), Keyboard = Keyboard.Text});
            }
        }
    }
}
