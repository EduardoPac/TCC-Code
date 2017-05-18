using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_v1.Model.Entities;
using Xamarin.Forms;

namespace TCC_v1.View
{
    class Forms_Dinamic_Page: CarouselPage
    {
        public Forms_Dinamic_Page(Form form)
        {
            Title = form.DatasetName;

            ToolbarItem e = new ToolbarItem();
            e.Icon = "check.png";

            ToolbarItems.Add(e);

            var padding = new Thickness(0, 20, 0, 0);

            StackLayout stacklayout = new StackLayout();
            
            for(int i=0; i<form.Fields.Count; i++)
            {
                stacklayout.Children.Add(new Label { Text = form.Fields[i].FieldName, FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) });

                //Regra para criar campos de String
                if (form.Fields[i].Type == "String")
                {
                    if(form.Fields[i].SelectFromList == true)
                    {
                        Picker pic = new Picker();
                        for (int j=0; j < form.Fields[i].ListItens.Count; j++) {

                            pic.Items.Add(form.Fields[i].ListItens[j].Name);
                            
                        }


                        stacklayout.Children.Add(pic);

                    }
                    else
                    {
                        stacklayout.Children.Add(new Editor { FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)), Keyboard = Keyboard.Text});
                    }
                }
                //Regra para criar Campos de Number
                if (form.Fields[i].Type == "Number")
                {
                    stacklayout.Children.Add(new Editor { FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)), Keyboard = Keyboard.Numeric });
                }
                //Regra para criar Campos de Date
                if (form.Fields[i].Type == "Date")
                {
                    DatePicker datePicker = new DatePicker
                    {
                        Format = "D",
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    };

                    stacklayout.Children.Add(datePicker);
                }
                //Regra para criar Campos de Time
                if (form.Fields[i].Type == "Time")
                {
                    TimePicker timePicker = new TimePicker() {HorizontalOptions = LayoutOptions.FillAndExpand};
                    stacklayout.Children.Add(timePicker);
                }
                ////Regra para criar campos de Imagem (futuro)
                //if(form.Fields[i].Type == "Image")
                //{

                //}

                

            }

            var Page1 = new ContentPage
            {
                Padding = padding,
                Content = new ScrollView
                {
                    Content = stacklayout
                }
            };

            Children.Add(Page1);
        }
    }
}
