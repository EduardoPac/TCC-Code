using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCC_v1.Model.Entities;
using Xamarin.Forms;

namespace TCC_v1.View
{
    public class PaginaResposta : ContentPage
    {
        public PaginaResposta(List<FieldAnswerBD> resp, FormAnswerBD form)
        {
            Title = form.DatasetName;

            StackLayout stacklayout = new StackLayout() { Margin = new Thickness(8, 0, 8, 0), VerticalOptions = LayoutOptions.Fill, HorizontalOptions = LayoutOptions.Fill };
            for (int x = 0; x < resp.Count; x++)
            {
                stacklayout.Children.Add(new Label { Text = resp[x].Question, FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)), TextColor = Color.Black, Margin = new Thickness(5, 10, 0, 0), HorizontalOptions = LayoutOptions.Start });
                stacklayout.Children.Add(new Label { Text = resp[x].Answer, FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)), TextColor = Color.Black, Margin = new Thickness(5, 2, 0, 0), HorizontalOptions = LayoutOptions.Start });
            }

            var scrol = new ScrollView();

            scrol.Content = stacklayout;

            Content = scrol; 
                
        }
    }
}