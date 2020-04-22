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
    internal class FormsDynamicPage : ContentPage
    {
        private Switch switcher;
        private Switch switcherText;
        private Picker picker;
        private Entry entryText;
        private Entry entryNumber;
        private DatePicker datePicker;
        private TimePicker timePicker;
        private Image sourceImage;
        private Entry entryLatitude;
        private Entry entryLongitude;
        private Button btnPickPhoto;
        private StackLayout masterStack;
        private StackLayout layoutStack;

        public FormsDynamicPage(Form form, int index, List<FieldAnswer> answers)
        {
            Title = form.DataSetName;
            var currentField = form.Fields[index];
            InitComponents();
            var page = GenerateLayout(form, index, answers, currentField);
            Content = page;
        }
        private void InitComponents()
        {
            switcher = new Switch();
            switcherText = new Switch();
            picker = new Picker();
            entryText = new Entry();
            entryNumber = new Entry();
            datePicker = new DatePicker();
            timePicker = new TimePicker();
            sourceImage = new Image();
            entryLatitude = new Entry();
            entryLongitude = new Entry();
            btnPickPhoto = new Button
            {
                Text = "Pick Photo",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Start,
                IsEnabled = true,
                BackgroundColor = Color.FromHex("336699")
            };
            masterStack = new StackLayout()
            {
                BackgroundColor = Color.White, 
                Orientation = StackOrientation.Vertical
            };
            layoutStack = new StackLayout()
            {
                Margin = new Thickness(16), 
                BackgroundColor = Color.White, 
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill,
                Spacing = 16
            };
        }
        #region GenerateComponents
        private ScrollView GenerateLayout(Form form, int index, List<FieldAnswer> answers, Field currentField)
        {
            layoutStack.Children.Add(new Label
            {
                Text = currentField.FieldName, FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.Black, HorizontalOptions = LayoutOptions.Start
            });

            GenerateTextField(currentField);
            GenerateNumberField(currentField);
            GenerateDateField(currentField);
            GenerateTimeField(currentField);
            GenerateImageField(currentField);
            GenerateLocationField(currentField);
            GenerateHelpField(currentField);
            var stackButtons = GenerateTransitionsButtons(form, index, answers, currentField);
            layoutStack.Children.Add(stackButtons);
            masterStack.Children.Add(layoutStack);
            var scroll = new ScrollView {Content = masterStack};
            return scroll;
        }

        private void GenerateHelpField(Field currentField)
        {
            var helpItems = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.End,
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.White
            };

            var descriptionBtn = new Button
            {
                Image = "info.png",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                BorderColor = Color.Transparent, BorderWidth = 0,
                HorizontalOptions = LayoutOptions.Start,
                TextColor = Color.Black,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Transparent
            };
            descriptionBtn.Clicked += async (sender, args) =>
                await DisplayAlert("Description", currentField.Description, "OK");
            helpItems.Children.Add(descriptionBtn);

            if (currentField.Required)
            {
                helpItems.Children.Add(new Label
                {
                    Text = "* This Field is Required",
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    TextColor = Color.Red,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Center,
                    VerticalTextAlignment = TextAlignment.Center
                });
            }

            layoutStack.Children.Add(helpItems);
        }

        private void GenerateLocationField(Field currentField)
        {
            if (currentField.Type != "Location")
                return;

            entryLatitude = new Entry
            {
                IsEnabled = false,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                Placeholder = "Latitude",
                Keyboard = Keyboard.Text,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            entryLongitude = new Entry
            {
                IsEnabled = false,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                Placeholder = "Longitude",
                Keyboard = Keyboard.Text,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            var indicator = new ActivityIndicator
            {
                Color = Color.FromHex("336699"),
                IsRunning = true, IsVisible = false,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            var btnGetLocation = new Button
            {
                Text = "Update Location",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Start,
                IsEnabled = true,
                BackgroundColor = Color.FromHex("336699")
            };

            layoutStack.Children.Add(entryLatitude);
            layoutStack.Children.Add(entryLongitude);
            layoutStack.Children.Add(indicator);
            layoutStack.Children.Add(btnGetLocation);


            btnGetLocation.Clicked += async (sender, args) =>
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 100;

                indicator.IsVisible = true;
                var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(5));
                indicator.IsVisible = false;

                var latitude = position.Latitude;
                var longitude = position.Longitude;

                entryLatitude.Text = latitude.ToString();
                entryLongitude.Text = longitude.ToString();
            };
        }

        private void GenerateImageField(Field currentField)
        {
            if (currentField.Type != "Image")
                return;

            sourceImage = new Image
            {
                Aspect = Aspect.AspectFit,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start,
                Source = "um.png"
            };
            layoutStack.Children.Add(sourceImage);
            layoutStack.Children.Add(btnPickPhoto);
            btnPickPhoto.Clicked += async (sender, e) =>
            {
                var stream = await DependencyService.Get<IPicturePicker>().GetImageStreamAsync();
                if (stream != null)
                {
                    sourceImage.Source = ImageSource.FromStream(() => stream);
                    btnPickPhoto.IsEnabled = false;
                }
                else
                    btnPickPhoto.IsEnabled = true;
            };
        }

        private void GenerateTimeField(Field currentField)
        {
            if (currentField.Type != "Time")
                return;

            var hour = DateTime.Now.Hour;
            var minute = DateTime.Now.Minute;
            timePicker = new TimePicker()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                TextColor = Color.Black,
                Time = new TimeSpan(hour, minute, 0)
            };
            layoutStack.Children.Add(timePicker);
        }

        private void GenerateDateField(Field currentField)
        {
            if (currentField.Type != "Date")
                return;

            datePicker = new DatePicker
            {
                Format = "dd/MM/yyyy",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                TextColor = Color.Black
            };
            layoutStack.Children.Add(datePicker);
        }

        private void GenerateNumberField(Field currentField)
        {
            if (currentField.Type != "Number")
                return;

            if (currentField.Controlled)
            {
                entryNumber = new Entry
                {
                    IsEnabled = false,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    Keyboard = Keyboard.Numeric, 
                    TextColor = Color.Black,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Placeholder = currentField.Min.ToString()
                };

                layoutStack.Children.Add(entryNumber);

                var slider = new Slider
                {
                    Maximum = currentField.Max,
                    Minimum = currentField.Min,
                    ThumbColor = Color.Gray
                };

                layoutStack.Children.Add(slider);

                slider.ValueChanged += HandleValueChanged;

                void HandleValueChanged(object sender, ValueChangedEventArgs e)
                {
                    var value = (int) slider.Value;
                    entryNumber.Text = value.ToString();
                }
            }
            else
            {
                entryNumber = new Entry
                {
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    Placeholder = "Type here..",
                    Keyboard = Keyboard.Numeric,
                    TextColor = Color.Black,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                };
                layoutStack.Children.Add(entryNumber);
            }
        }

        private void GenerateTextField(Field currentField)
        {
            if (currentField.Type != "String")
                return;

            switch (currentField.SelectFromList)
            {
                case true when currentField.ListItems[0].Name == "Yes":
                {
                    var stackSwitch = new StackLayout() {Orientation = StackOrientation.Horizontal};
                    switcher = new Switch
                    {
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.End
                    };
                    stackSwitch.Children.Add(switcher);
                    var value = new Label
                    {
                        Text = "No",
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        TextColor = Color.Black,
                        Margin = new Thickness(8,0),
                        HorizontalOptions = LayoutOptions.Start,
                        VerticalOptions = LayoutOptions.Center,
                        VerticalTextAlignment = TextAlignment.Center
                    };

                    stackSwitch.Children.Add(value);

                    switcher.Toggled += SwitcherToggled;

                    void SwitcherToggled(object sender, ToggledEventArgs e)
                    {
                        switch (switcher.IsToggled)
                        {
                            case false:
                                value.Text = "No";
                                break;
                            case true:
                                value.Text = "Yes";
                                break;
                        }
                    }

                    layoutStack.Children.Add(stackSwitch);
                    break;
                }
                case true when currentField.ListItems[0].Name != "Yes":
                {
                    picker = new Picker() {HorizontalOptions = LayoutOptions.FillAndExpand, TextColor = Color.Black};
                    foreach (var item in currentField.ListItems)
                    {
                        picker.Items.Add(item.Name);
                    }

                    picker.SelectedIndex = 0;
                    layoutStack.Children.Add(picker);
                    break;
                }
                default:
                    entryText = new Entry
                    {
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        Placeholder = "Type here..",
                        Keyboard = Keyboard.Text,
                        TextColor = Color.Black,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    };
                    layoutStack.Children.Add(entryText);
                    break;
            }
        }
        #endregion
        #region TransitionsButtons
        
        private StackLayout GenerateTransitionsButtons(Form form, int index, List<FieldAnswer> answers,
            Field currentField)
        {
            var navigationStack = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.End,
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.White
            };
            GenerateBackBtn(form, index, answers, navigationStack);
            GenerateNextBtn(form, index, answers, currentField, navigationStack);

            return navigationStack;
        }

        private void GenerateNextBtn(Form form, int index, List<FieldAnswer> answers, Field currentField,
            StackLayout navigationStack)
        {
            if (index + 1 == form.Fields.Count)
            {
                var saveBtn = new Button
                {
                    Text = "Save",
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                    Opacity = 200,
                    TextColor = Color.White,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.Start,
                    BackgroundColor = Color.FromHex("336699")
                };
                saveBtn.Clicked += async (sender, args) =>
                {
                    switch (currentField.Required)
                    {
                        case true:
                        {
                            var save = new FormDynamicViewModel();
                            switch (currentField.Type)
                            {
                                case "String" when currentField.SelectFromList == true &&
                                                   currentField.ListItems[0].Name == "Yes" &&
                                                   (switcher.IsToggled == true || switcherText.IsToggled == true):
                                    answers.Add(AnswerStringBool(switcher, currentField));
                                    FormDynamicViewModel.SaveData(answers, form);
                                    await DisplayAlert("Save", "Your answers have been successfully saved", "OK");
                                    await Navigation.PopToRootAsync();
                                    break;
                                case "String" when currentField.SelectFromList == true &&
                                                   currentField.ListItems[0].Name != "Yes":
                                    answers.Add(AnswerStringList(picker, currentField));
                                    FormDynamicViewModel.SaveData(answers, form);
                                    await DisplayAlert("Save", "Your answers have been successfully saved", "OK");
                                    await Navigation.PopToRootAsync();
                                    break;
                                case "String" when entryText.Text != null:
                                    answers.Add(AnswerString(entryText, currentField));
                                    FormDynamicViewModel.SaveData(answers, form);
                                    await Navigation.PopToRootAsync();
                                    break;
                                case "String":
                                    await DisplayAlert("Alert", "The question must be answered", "OK");
                                    break;
                                case "Number" when currentField.Controlled == true && entryNumber.Text != null:
                                    answers.Add(AnswerNumericControlled(entryNumber, currentField));
                                    FormDynamicViewModel.SaveData(answers, form);
                                    await DisplayAlert("Save", "Your answers have been successfully saved", "OK");
                                    await Navigation.PopToRootAsync();
                                    break;
                                case "Number" when entryNumber.Text != null:
                                    answers.Add(AnswerNumeric(entryNumber, currentField));
                                    FormDynamicViewModel.SaveData(answers, form);
                                    await DisplayAlert("Save", "Your answers have been successfully saved", "OK");
                                    await Navigation.PopToRootAsync();
                                    break;
                                case "Number":
                                    await DisplayAlert("Alert", "The question must be answered", "OK");
                                    break;
                                case "Date":
                                    answers.Add(AnswerDate(datePicker, currentField));
                                    FormDynamicViewModel.SaveData(answers, form);
                                    await DisplayAlert("Save", "Your answers have been successfully saved", "OK");
                                    await Navigation.PopToRootAsync();
                                    break;
                                case "Time":
                                    answers.Add(AnswerTime(timePicker, currentField));
                                    FormDynamicViewModel.SaveData(answers, form);
                                    await DisplayAlert("Save", "Your answers have been successfully saved", "OK");
                                    await Navigation.PopToRootAsync();
                                    break;
                                case "Image" when btnPickPhoto.IsEnabled == false:
                                    answers.Add(AnswerImage(sourceImage, currentField));
                                    FormDynamicViewModel.SaveData(answers, form);
                                    await DisplayAlert("Save", "Your answers have been successfully saved", "OK");
                                    await Navigation.PopToRootAsync();
                                    break;
                                case "Image":
                                    await DisplayAlert("Alert", "The question must be answered", "OK");
                                    break;
                                case "Location" when entryLatitude.Text != null && entryLongitude.Text != null:
                                    answers.Add(AnswerLocation(entryLatitude, entryLongitude, currentField));
                                    FormDynamicViewModel.SaveData(answers, form);
                                    await DisplayAlert("Save", "Your answers have been successfully saved", "OK");
                                    ;
                                    await Navigation.PopToRootAsync();
                                    break;
                                case "Location":
                                    await DisplayAlert("Alert", "The question must be answered", "OK");
                                    break;
                            }

                            break;
                        }
                        case false:
                        {
                            var save = new FormDynamicViewModel();
                            switch (currentField.Type)
                            {
                                case "String" when currentField.SelectFromList == true &&
                                                   currentField.ListItems[0].Name == "Yes":
                                    answers.Add(AnswerStringBool(switcher, currentField));
                                    break;
                                case "String" when currentField.SelectFromList == true &&
                                                   currentField.ListItems[0].Name != "Yes":
                                    answers.Add(AnswerStringList(picker, currentField));
                                    break;
                                case "String":
                                    answers.Add(AnswerString(entryText, currentField));
                                    break;
                                case "Number" when currentField.Controlled == true:
                                    answers.Add(AnswerNumericControlled(entryNumber, currentField));
                                    break;
                                case "Number":
                                    answers.Add(AnswerNumeric(entryNumber, currentField));
                                    break;
                                case "Date":
                                    answers.Add(AnswerDate(datePicker, currentField));
                                    break;
                                case "Time":
                                    answers.Add(AnswerTime(timePicker, currentField));
                                    break;
                                case "Image":
                                    answers.Add(AnswerImage(sourceImage, currentField));
                                    break;
                                case "Location":
                                    answers.Add(AnswerLocation(entryLatitude, entryLongitude, currentField));
                                    break;
                            }

                            FormDynamicViewModel.SaveData(answers, form);
                            await Navigation.PopToRootAsync();
                            break;
                        }
                    }
                };
                navigationStack.Children.Add(saveBtn);
            }
            else
            {
                var nextBtn = new Button
                {
                    Text = "Next",
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                    Opacity = 200,
                    TextColor = Color.White,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.Start,
                    BorderColor = Color.FromRgb(191, 255, 0),
                    BackgroundColor = Color.FromHex("336699")
                };

                nextBtn.Clicked += async (sender, args) =>
                {
                    if (currentField.Required == true)
                    {
                        switch (currentField.Type)
                        {
                            case "String" when currentField.SelectFromList == true &&
                                               currentField.ListItems[0].Name == "Yes" &&
                                               (switcher.IsToggled == true || switcherText.IsToggled == true):
                                answers.Add(AnswerStringBool(switcher, currentField));
                                await Navigation.PushAsync(new FormsDynamicPage(form, index + 1, answers));
                                break;
                            case "String" when currentField.SelectFromList == true &&
                                               currentField.ListItems[0].Name != "Yes":
                                answers.Add(AnswerStringList(picker, currentField));
                                await Navigation.PushAsync(new FormsDynamicPage(form, index + 1, answers));
                                break;
                            case "String" when entryText.Text != null:
                                answers.Add(AnswerString(entryText, currentField));
                                await Navigation.PushAsync(new FormsDynamicPage(form, index + 1, answers));
                                break;
                            case "String":
                                await DisplayAlert("Alert", "The question must be answered", "OK");
                                break;
                            case "Number" when currentField.Controlled == true && entryNumber.Text != null:
                                answers.Add(AnswerNumericControlled(entryNumber, currentField));
                                await Navigation.PushAsync(new FormsDynamicPage(form, index + 1, answers));
                                break;
                            case "Number" when entryNumber.Text != null:
                                answers.Add(AnswerNumeric(entryNumber, currentField));
                                await Navigation.PushAsync(new FormsDynamicPage(form, index + 1, answers));
                                break;
                            case "Number":
                                await DisplayAlert("Alert", "The question must be answered", "OK");
                                break;
                            case "Date":
                                answers.Add(AnswerDate(datePicker, currentField));
                                await Navigation.PushAsync(new FormsDynamicPage(form, index + 1, answers));
                                break;
                            case "Time":
                                answers.Add(AnswerTime(timePicker, currentField));
                                await Navigation.PushAsync(new FormsDynamicPage(form, index + 1, answers));
                                break;
                            case "Image" when btnPickPhoto.IsEnabled == false:
                                answers.Add(AnswerImage(sourceImage, currentField));
                                await Navigation.PushAsync(new FormsDynamicPage(form, index + 1, answers));
                                break;
                            case "Image":
                                await DisplayAlert("Alert", "The question must be answered", "OK");
                                break;
                            case "Location" when entryLatitude.Text != null && entryLongitude.Text != null:
                                answers.Add(AnswerLocation(entryLatitude, entryLongitude, currentField));
                                await Navigation.PushAsync(new FormsDynamicPage(form, index + 1, answers));
                                break;
                            case "Location":
                                await DisplayAlert("Alert", "The question must be answered", "OK");
                                break;
                        }
                    }
                    else
                    {
                        switch (currentField.Type)
                        {
                            case "String" when currentField.SelectFromList == true &&
                                               currentField.ListItems[0].Name == "Yes":
                                answers.Add(AnswerStringBool(switcher, currentField));
                                break;
                            case "String" when currentField.SelectFromList == true &&
                                               currentField.ListItems[0].Name != "Yes":
                                answers.Add(AnswerStringList(picker, currentField));
                                break;
                            case "String":
                                answers.Add(AnswerString(entryText, currentField));
                                break;
                            case "Number" when currentField.Controlled == true:
                                answers.Add(AnswerNumericControlled(entryNumber, currentField));
                                break;
                            case "Number":
                                answers.Add(AnswerNumeric(entryNumber, currentField));
                                break;
                            case "Date":
                                answers.Add(AnswerDate(datePicker, currentField));
                                break;
                            case "Time":
                                answers.Add(AnswerTime(timePicker, currentField));
                                break;
                            case "Image":
                                answers.Add(AnswerImage(sourceImage, currentField));
                                break;
                            case "Location":
                                answers.Add(AnswerLocation(entryLatitude, entryLongitude, currentField));
                                break;
                        }

                        await Navigation.PushAsync(new FormsDynamicPage(form, index + 1, answers));
                    }
                };

                navigationStack.Children.Add(nextBtn);
            }
        }

        private void GenerateBackBtn(Form form, int index, List<FieldAnswer> answers, StackLayout navigationStack)
        {
            if (index != 0)
            {
                var backBtn = new Button
                {
                    Text = "Back",
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    TextColor = Color.White,
                    VerticalOptions = LayoutOptions.Start,
                    IsEnabled = true,
                    BackgroundColor = Color.FromHex("336699")
                };
                backBtn.Clicked += async (sender, args) => await Navigation.PopAsync();
                navigationStack.Children.Add(backBtn);
            }
            else
            {
                var backBtn = new Button
                {
                    Text = "Back",
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    TextColor = Color.White,
                    VerticalOptions = LayoutOptions.Start,
                    IsEnabled = false,
                    BackgroundColor = Color.FromHex("336699")
                };
                navigationStack.Children.Add(backBtn);
            }

            var status = new Label
            {
                Text = (index + 1).ToString() + " / " + form.Fields.Count.ToString(),
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                VerticalOptions = LayoutOptions.Center
            };
            navigationStack.Children.Add(status);
        }
        
        #endregion
        #region SaveAnswer

        private static FieldAnswer AnswerStringBool(Switch a, Field c)
        {
            var answer = new FieldAnswer {Question = c.FieldName};
            switch (a.IsToggled)
            {
                case true:
                    answer.Answer = "true";
                    break;
                case false:
                    answer.Answer = "false";
                    break;
            }

            return answer;
        }

        private static FieldAnswer AnswerStringList(Picker a, Field c)
        {
            var answer = new FieldAnswer {Question = c.FieldName};
            var index = a.SelectedIndex;
            answer.Answer = c.ListItems[index].Name;
            return answer;
        }

        private static FieldAnswer AnswerString(Entry a, Field c) =>
            new FieldAnswer {Question = c.FieldName, Answer = a.Text};

        private static FieldAnswer AnswerNumericControlled(Entry a, Field c) =>
            new FieldAnswer {Question = c.FieldName, Answer = a.Text};

        private static FieldAnswer AnswerNumeric(Entry a, Field c) =>
            new FieldAnswer {Question = c.FieldName, Answer = a.Text};

        private static FieldAnswer AnswerDate(DatePicker a, Field c) =>
            new FieldAnswer
            {
                Question = c.FieldName,
                Answer = a.Date.Day.ToString() + "/" + a.Date.Month.ToString() + "/" + a.Date.Year.ToString()
            };

        private static FieldAnswer AnswerTime(TimePicker a, Field c) =>
            new FieldAnswer
            {
                Question = c.FieldName, Answer = a.Time.Hours.ToString() + ":" + a.Time.Minutes.ToString()
            };

        private static FieldAnswer AnswerImage(IImageElement image, Field field) =>
            new FieldAnswer {Question = field.FieldName, Answer = image.Source.ToString()};

        private static FieldAnswer AnswerLocation(Entry entry, Entry entry2, Field field) =>
            new FieldAnswer {Question = field.FieldName, Answer = entry.Text + "," + entry2.Text};

        #endregion
    }
}