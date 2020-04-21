using System;
using TCC_v1.Model.Entities;
using TCC_v1.Pages;
using Xamarin.Forms;
using Plugin.Geolocator;
using System.IO;
using TCC_v1.Model.Services;
using System.Collections.Generic;
using TCC_v1.ViewModel;
using TCC_v1.DAL;

namespace TCC_v1.View
{
    class Forms_Dinamic_Page: ContentPage
    {
        public Forms_Dinamic_Page(Form form, int index, List<FieldAnswerBD> resp)
        {
            Title = form.DatasetName;

            //Pega o campo que será mostrado
            Field field = new Field();
            field = form.Fields[index];
            

            //
            //criar todas as variaveis
            Switch switcher = new Switch();
            Switch switcher2 = new Switch();
            Picker pic = new Picker();
            Entry entradaTexto = new Entry();
            Entry entradaNumero = new Entry();
            DatePicker datePicker = new DatePicker();
            TimePicker timePicker = new TimePicker();
            Image beachImage = new Image();
            Entry entradaLatitude = new Entry();
            Entry entradaLongitude = new Entry();
            Button Pickfoto_btn = new Button { Text = "Pick Photo", FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)), HorizontalOptions = LayoutOptions.FillAndExpand, TextColor = Color.White, VerticalOptions = LayoutOptions.Start, IsEnabled = true, BackgroundColor = Color.FromHex("336699") };



            StackLayout stackmaster = new StackLayout() { BackgroundColor = Color.White, Orientation = StackOrientation.Vertical };
            StackLayout stacklayout = new StackLayout() { Margin = new Thickness(16), BackgroundColor = Color.White, VerticalOptions = LayoutOptions.Fill, HorizontalOptions = LayoutOptions.Fill };

            // coloca o rotulo da questão
            stacklayout.Children.Add(new Label { Text = field.FieldName, FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)), TextColor = Color.Black, HorizontalOptions = LayoutOptions.Start });
           
        //    // caso seja um campo de string
            if (field.Type == "String")
            {
                if (field.SelectFromList == true && field.ListItens[0].Name == "Yes")
                {
                    StackLayout stackSwitch = new StackLayout() { Orientation = StackOrientation.Horizontal };

                    switcher = new Switch
                    {
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.End
                    };

                    stackSwitch.Children.Add(switcher);

                    Label ca = new Label { Text = "No", FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)), TextColor = Color.Black, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Start };

                    stackSwitch.Children.Add(ca);

                    switcher.Toggled += switcher_Toggled;

                    void switcher_Toggled(object sender, ToggledEventArgs e)
                    {
                        if(switcher.IsToggled == false) { ca.Text = "No"; }
                        if(switcher.IsToggled == true ) { ca.Text = "Yes"; }
                    }

                    stacklayout.Children.Add(stackSwitch);
                }

                else if (field.SelectFromList == true && field.ListItens[0].Name != "Yes")
                {

                    pic = new Picker() { HorizontalOptions = LayoutOptions.FillAndExpand, TextColor = Color.Black };
                    for (int j = 0; j < field.ListItens.Count; j++)
                    {

                        pic.Items.Add(field.ListItens[j].Name);

                    }

                    pic.SelectedIndex = 0;
                    stacklayout.Children.Add(pic);
                }


                else
                {
                    entradaTexto = new Entry { FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),Placeholder = "Digite aqui..", Keyboard = Keyboard.Text, TextColor = Color.Black, HorizontalOptions = LayoutOptions.FillAndExpand };
                    stacklayout.Children.Add(entradaTexto);
                }
            }


            //    //Regra para criar Campos de Number
            if (field.Type == "Number")
            {
                if (field.Controled == true)
                {
                    entradaNumero = new Entry { IsEnabled = false,FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)), Keyboard = Keyboard.Numeric, TextColor = Color.Black, HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder = field.Min.ToString() };

                    stacklayout.Children.Add(entradaNumero);

                    Slider slider = new Slider
                    {
                        Maximum = field.Max,
                        Minimum = field.Min,
                    };

                    stacklayout.Children.Add(slider);

                    slider.ValueChanged += HandleValueChanged;

                    void HandleValueChanged(object sender, ValueChangedEventArgs e)
                    {
                        int x = (int)slider.Value;
                        entradaNumero.Text = x.ToString();
                    }

                }

                else
                {
                    entradaNumero = new Entry { FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)), Placeholder = "Digite aqui..", Keyboard = Keyboard.Numeric, TextColor = Color.Black, HorizontalOptions = LayoutOptions.FillAndExpand, };

                    stacklayout.Children.Add(entradaNumero);
                }

            }


            //    //Regra para criar Campos de Date
            if (field.Type == "Date")
            {
                datePicker = new DatePicker
                {
                    Format = "dd/MM/yyyy",
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    TextColor = Color.Black
                };

                stacklayout.Children.Add(datePicker);
            }


            //    //Regra para criar Campos de Time
            if (field.Type == "Time")
            {
                var hour = DateTime.Now.Hour;
                var minute = DateTime.Now.Minute;
                timePicker = new TimePicker()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    TextColor = Color.Black,
                    Time = new TimeSpan(hour, minute, 0)
                };


                stacklayout.Children.Add(timePicker);
            }


            //    //Regra para criar campos de Imagem
            if (field.Type == "Image")
            {
                beachImage = new Image { Aspect = Aspect.AspectFit, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Start};
                beachImage.Source = "um.png";

                stacklayout.Children.Add(beachImage);

                
                stacklayout.Children.Add(Pickfoto_btn);

                Pickfoto_btn.Clicked += async (sender, e) =>
                {
                        //Pickfoto_btn.IsEnabled = false;
                    Stream stream = await DependencyService.Get<IPicturePicker>().GetImageStreamAsync();

                    if (stream != null)
                    {
                        beachImage.Source = ImageSource.FromStream(() => stream);
                        Pickfoto_btn.IsEnabled = false;

                    }
                    else
                    {
                        Pickfoto_btn.IsEnabled = true;
                    }
                };

            }

            //    //Regra para criar o campo de localização

            if (field.Type == "Location")
            {
                entradaLatitude = new Entry { IsEnabled = false,FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)), Placeholder = "Latitude", Keyboard = Keyboard.Text, TextColor = Color.Black, HorizontalOptions = LayoutOptions.FillAndExpand };
                entradaLongitude = new Entry { IsEnabled = false,FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)), Placeholder = "Longitude", Keyboard = Keyboard.Text, TextColor = Color.Black, HorizontalOptions = LayoutOptions.FillAndExpand};
                ActivityIndicator atc = new ActivityIndicator {Color = Color.FromHex("336699"), IsRunning = true, IsVisible = false , HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center};

                Button Location_btn = new Button { Text = "Update Location", FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)), HorizontalOptions = LayoutOptions.FillAndExpand, TextColor = Color.Black, VerticalOptions = LayoutOptions.Start, IsEnabled = true, BackgroundColor = Color.FromHex("336699") };

                stacklayout.Children.Add(entradaLatitude);
                stacklayout.Children.Add(entradaLongitude);
                stacklayout.Children.Add(atc);
                stacklayout.Children.Add(Location_btn);




                Location_btn.Clicked += async (sender, args) =>
                {
                    var locator = CrossGeolocator.Current;
                    locator.DesiredAccuracy = 100;

                    atc.IsVisible = true;
                    var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(5));
                    atc.IsVisible = false;

                    var Latitude = position.Latitude;
                    var Longitude = position.Longitude;

                    entradaLatitude.Text = Latitude.ToString();
                    entradaLongitude.Text = Longitude.ToString();


                };

            };


            StackLayout stackhelp = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.End, Orientation = StackOrientation.Horizontal, BackgroundColor = Color.White };

            //colocar uma imagem de help
            Button Descrition_btn = new Button { Image = "info.png", FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)), BorderColor = Color.Transparent, BorderWidth = 0, HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, VerticalOptions = LayoutOptions.Center, BackgroundColor = Color.Transparent};
            Descrition_btn.Clicked += async (sender, args) => { await DisplayAlert("Descrition", field.Description, "OK"); };
            stackhelp.Children.Add(Descrition_btn);

            if (field.Required == true)
            {
                stackhelp.Children.Add(new Label { Text = "* This Field is Required", FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)), TextColor = Color.Red, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Start });
            }

            stacklayout.Children.Add(stackhelp);

            // botão de transição entre campos

            StackLayout stacklayout2 = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.End, Orientation = StackOrientation.Horizontal, BackgroundColor = Color.White };

            //logica para o botão Back
            if (index == 0)
            {
                Button Back_btn = new Button { Text = "Back", FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)), HorizontalOptions = LayoutOptions.FillAndExpand, TextColor = Color.White, VerticalOptions = LayoutOptions.Start, IsEnabled = false, BackgroundColor = Color.FromHex("336699") };
                stacklayout2.Children.Add(Back_btn);
            }
            else
            {
                Button Back_btn = new Button { Text = "Back", FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)), HorizontalOptions = LayoutOptions.FillAndExpand, TextColor = Color.White, VerticalOptions = LayoutOptions.Start, IsEnabled = true, BackgroundColor = Color.FromHex("336699") };
                Back_btn.Clicked += async (sender, args) => { await Navigation.PushAsync(new Forms_Dinamic_Page(form, index - 1, resp)); };
                stacklayout2.Children.Add(Back_btn);
            }

            Label status = new Label { Text = (index + 1).ToString() + " / " + form.Fields.Count.ToString(), FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)), VerticalOptions = LayoutOptions.Center };
            stacklayout2.Children.Add(status);

            //    //Logica para o botão next

            if (index + 1 == form.Fields.Count)
            {
                Button Next_btn = new Button { Text = "Save", FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)), Opacity = 200, TextColor = Color.White, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.Start, BackgroundColor = Color.FromHex("336699") };
                Next_btn.Clicked += async (sender, args) =>
                {
                    if (field.Required == true)
                    {
                        Form_Dinamic_view_model save = new Form_Dinamic_view_model();
                        if (field.Type == "String")
                        {
                            if (field.SelectFromList == true && field.ListItens[0].Name == "Yes" && (switcher.IsToggled == true || switcher2.IsToggled == true)) { resp.Add(Strbool(switcher, field)); save.SaveDAL(resp, form); await DisplayAlert("Save", "Your answers have been successfully saved", "OK"); await Navigation.PopToRootAsync(); }
                            else if (field.SelectFromList == true && field.ListItens[0].Name != "Yes") { resp.Add(Strlist(pic, field)); save.SaveDAL(resp, form); await DisplayAlert("Save", "Your answers have been successfully saved", "OK"); await Navigation.PopToRootAsync(); }
                            else if (entradaTexto.Text != null) { resp.Add(Strnorm(entradaTexto, field)); save.SaveDAL(resp, form); await Navigation.PopToRootAsync(); }
                            else { await DisplayAlert("Alert", "The question must be answered", "OK"); }
                        }

                        else if (field.Type == "Number")
                        {
                            if (field.Controled == true && entradaNumero.Text != null) { resp.Add(Numcontr(entradaNumero, field)); save.SaveDAL(resp, form); await DisplayAlert("Save", "Your answers have been successfully saved", "OK"); await Navigation.PopToRootAsync(); }
                            else if (entradaNumero.Text != null) { resp.Add(Numnorm(entradaNumero, field)); save.SaveDAL(resp, form); await DisplayAlert("Save", "Your answers have been successfully saved", "OK"); await Navigation.PopToRootAsync(); }
                            else { await DisplayAlert("Alert", "The question must be answered", "OK"); }
                        }
                        else if (field.Type == "Date") { resp.Add(Date(datePicker, field)); save.SaveDAL(resp, form); await DisplayAlert("Save", "Your answers have been successfully saved", "OK"); await Navigation.PopToRootAsync(); }
                        else if (field.Type == "Time") { resp.Add(Time(timePicker, field)); save.SaveDAL(resp, form); await DisplayAlert("Save", "Your answers have been successfully saved", "OK");  await Navigation.PopToRootAsync(); }
                        else if (field.Type == "Image")
                        {
                            if (Pickfoto_btn.IsEnabled == false) { resp.Add(Image(beachImage, field)); save.SaveDAL(resp, form); await DisplayAlert("Save", "Your answers have been successfully saved", "OK"); await Navigation.PopToRootAsync(); }
                            else { await DisplayAlert("Alert", "The question must be answered", "OK"); }
                        }
                        else if (field.Type == "Location")
                        {
                            if (entradaLatitude.Text != null && entradaLongitude.Text != null) { resp.Add(Location(entradaLatitude, entradaLongitude, field)); save.SaveDAL(resp, form); await DisplayAlert("Save", "Your answers have been successfully saved", "OK"); ; await Navigation.PopToRootAsync(); }
                            else { await DisplayAlert("Alert", "The question must be answered", "OK"); }
                        }

                        
                    }

                    if (field.Required == false)
                    {
                        Form_Dinamic_view_model save = new Form_Dinamic_view_model();
                        if (field.Type == "String")
                        {
                            if (field.SelectFromList == true && field.ListItens[0].Name == "Yes") { resp.Add(Strbool(switcher, field)); }
                            else if (field.SelectFromList == true && field.ListItens[0].Name != "Yes") { resp.Add(Strlist(pic, field)); }
                            else { resp.Add(Strnorm(entradaTexto, field)); }
                        }

                        else if (field.Type == "Number")
                        {
                            if (field.Controled == true) { resp.Add(Numcontr(entradaNumero, field)); }
                            else { resp.Add(Numnorm(entradaNumero, field)); }
                        }
                        else if (field.Type == "Date") { resp.Add(Date(datePicker, field)); }
                        else if (field.Type == "Time") { resp.Add(Time(timePicker, field)); }
                        else if (field.Type == "Image") { resp.Add(Image(beachImage, field)); }
                        else if (field.Type == "Location") { resp.Add(Location(entradaLatitude, entradaLongitude, field)); }

                        //converte as caracteristicas do formulario para o formulario de resposta
                        save.SaveDAL(resp, form);

                        await Navigation.PopToRootAsync();

                    }
                    
                };

                stacklayout2.Children.Add(Next_btn);
            }
            else
            {
                Button Next_btn = new Button { Text = "Next", FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)), Opacity = 200, TextColor = Color.White, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.Start, BorderColor = Color.FromRgb(191, 255, 0), BackgroundColor = Color.FromHex("336699") };
                Next_btn.Clicked += async (sender, args) =>
                {
                    if(field.Required == true)
                    {
                        if (field.Type == "String")
                        {
                            if (field.SelectFromList == true && field.ListItens[0].Name == "Yes" && (switcher.IsToggled == true || switcher2.IsToggled == true)) { resp.Add(Strbool(switcher, field)); await Navigation.PushAsync(new Forms_Dinamic_Page(form, index + 1, resp)); }
                            else if (field.SelectFromList == true && field.ListItens[0].Name != "Yes") { resp.Add(Strlist(pic, field)); await Navigation.PushAsync(new Forms_Dinamic_Page(form, index + 1, resp)); }
                            else if (entradaTexto.Text != null) { resp.Add(Strnorm(entradaTexto, field)); await Navigation.PushAsync(new Forms_Dinamic_Page(form, index + 1, resp)); }
                            else { await DisplayAlert("Alert", "The question must be answered", "OK"); }
                        }

                        else if (field.Type == "Number")
                        {
                            if (field.Controled == true && entradaNumero.Text != null) { resp.Add(Numcontr(entradaNumero, field)); await Navigation.PushAsync(new Forms_Dinamic_Page(form, index + 1, resp)); }
                            else if(entradaNumero.Text != null) { resp.Add(Numnorm(entradaNumero, field)); await Navigation.PushAsync(new Forms_Dinamic_Page(form, index + 1, resp)); }
                            else { await DisplayAlert("Alert", "The question must be answered", "OK"); }
                        }
                        else if (field.Type == "Date") { resp.Add(Date(datePicker, field)); await Navigation.PushAsync(new Forms_Dinamic_Page(form, index + 1, resp)); }
                        else if (field.Type == "Time") { resp.Add(Time(timePicker, field)); await Navigation.PushAsync(new Forms_Dinamic_Page(form, index + 1, resp)); }
                        else if (field.Type == "Image") {
                            if(Pickfoto_btn.IsEnabled == false) { resp.Add(Image(beachImage, field)); await Navigation.PushAsync(new Forms_Dinamic_Page(form, index + 1, resp)); }
                            else { await DisplayAlert("Alert", "The question must be answered", "OK"); }
                        }
                        else if (field.Type == "Location") {
                            if (entradaLatitude.Text != null && entradaLongitude.Text != null) { resp.Add(Location(entradaLatitude, entradaLongitude, field)); await Navigation.PushAsync(new Forms_Dinamic_Page(form, index + 1, resp)); }
                            else { await DisplayAlert("Alert", "The question must be answered", "OK"); }
                        }

                        
                    }

                    else if (field.Required == false)
                    {
                        if (field.Type == "String")
                        {
                            if (field.SelectFromList == true && field.ListItens[0].Name == "Yes") { resp.Add(Strbool(switcher, field)); }
                            else if (field.SelectFromList == true && field.ListItens[0].Name != "Yes") { resp.Add(Strlist(pic, field)); }
                            else { resp.Add(Strnorm(entradaTexto, field)); }
                        }

                        else if (field.Type == "Number")
                        {
                            if (field.Controled == true) { resp.Add(Numcontr(entradaNumero, field)); }
                            else { resp.Add(Numnorm(entradaNumero, field)); }
                        }
                        else if (field.Type == "Date") { resp.Add(Date(datePicker, field)); }
                        else if (field.Type == "Time") { resp.Add(Time(timePicker, field)); }
                        else if (field.Type == "Image") { resp.Add(Image(beachImage, field)); }
                        else if (field.Type == "Location") { resp.Add(Location(entradaLatitude, entradaLongitude, field)); }

                        await Navigation.PushAsync(new Forms_Dinamic_Page(form, index + 1, resp));

                    }
                    
                };

                stacklayout2.Children.Add(Next_btn);
            }

            var scrol = new ScrollView();

            stacklayout.Children.Add(stacklayout2);

            stackmaster.Children.Add(stacklayout);

            
            scrol.Content = stackmaster;

            Content = scrol;
            
            
            

        }

        ////metodos de coletar as answerostas da interface
        public FieldAnswerBD Strbool(Switch a, Field c)
        {
            FieldAnswerBD rep = new FieldAnswerBD();
            rep.Question = c.FieldName;
            if (a.IsToggled == true) { rep.Answer = "true"; }
            else if (a.IsToggled == false) { rep.Answer = "false"; };
            
            return rep;
        }

        public FieldAnswerBD Strlist(Picker a, Field c)
        {
            FieldAnswerBD rep = new FieldAnswerBD();
            rep.Question = c.FieldName;
            int k = a.SelectedIndex;
            rep.Answer = c.ListItens[k].Name;
            
            return rep;
        }

        public FieldAnswerBD Strnorm(Entry a, Field c)
        {
            FieldAnswerBD rep = new FieldAnswerBD();
            rep.Question = c.FieldName;
            rep.Answer = a.Text;

            return rep;
        }

        public FieldAnswerBD Numcontr(Entry a, Field c)
        {
            FieldAnswerBD rep = new FieldAnswerBD();
            rep.Question = c.FieldName;
            rep.Answer = a.Text;

            return rep;
        }

        public FieldAnswerBD Numnorm(Entry a, Field c)
        {
            FieldAnswerBD rep = new FieldAnswerBD();
            rep.Question = c.FieldName;
            rep.Answer = a.Text;

            return rep;
        }

        public FieldAnswerBD Date(DatePicker a, Field c)
        {
            FieldAnswerBD rep = new FieldAnswerBD();
            rep.Question = c.FieldName;
            rep.Answer = a.Date.Day.ToString() + "/" + a.Date.Month.ToString() + "/" + a.Date.Year.ToString();
            
            return rep;
        }

        public FieldAnswerBD Time(TimePicker a, Field c)
        {
            FieldAnswerBD rep = new FieldAnswerBD();
            rep.Question = c.FieldName;
            rep.Answer = a.Time.Hours.ToString() + ":" + a.Time.Minutes.ToString();
            
            return rep;
        }
        public FieldAnswerBD Image(Image a, Field c)
        {
            FieldAnswerBD rep = new FieldAnswerBD();
            rep.Question = c.FieldName;
            rep.Answer = a.Source.ToString();
            
            return rep;
        }
        public FieldAnswerBD Location(Entry a, Entry b, Field c)
        {
            FieldAnswerBD rep = new FieldAnswerBD();
            rep.Question = c.FieldName;
            rep.Answer = a.Text + "," + b.Text;
            
            return rep;
        } 

    }
    
}
