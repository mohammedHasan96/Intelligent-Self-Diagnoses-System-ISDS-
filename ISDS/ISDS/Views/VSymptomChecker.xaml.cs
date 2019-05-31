using ISDS.Models;
using ISDS.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ISDS.Views
{
    enum A
    {
        a = 1, b = 2, c = 4, d = 8
    }
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VSymptomChecker : ContentPage
    {
        List<Symptom> Symptoms = new List<Symptom>();
        public VSymptomChecker()
        {
            InitializeComponent();
            IsActive.IsVisible = true;

            new Thread(() =>
            {
                try
                {
                    while (!DataModel.IsReadyD)
                        Thread.Sleep(60);
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        autoSugg.ItemsSource = DataModel.Symptoms.Select(x => x.SymptomName).ToArray();
                    });
                }
                catch (Exception ex)
                {
                    DisplayAlert("Error", ex.Message, "Retry");
                    Navigation.PopAsync();
                }
                finally
                {
                    Device.BeginInvokeOnMainThread(() => IsActive.IsVisible = false);
                }
            }).Start();
            autoSugg.TextChanged += AutoSugg_TextChanged;
            autoSugg.SuggestionChosen += AutoSugg_SuggestionChosen;
        }



        private void AutoSugg_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            if (autoSugg.Text != null && autoSugg.Text != "")
                autoSugg.ItemsSource = DataModel.Symptoms.Where(x => x.SymptomName.ToLower().Contains(autoSugg.Text.ToLower())).Select(x => x.SymptomName).ToArray();
        }

        private void AutoSugg_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            var symp = DataModel.Symptoms.FirstOrDefault(x => x.SymptomName == (e.SelectedItem as string));
            if (symp != null)
                Symptoms.Add(symp);
            list.ItemsSource = Symptoms.ToList();
            autoSugg.Text = "";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (Symptoms.Count > 0)
            {
                var ids = Symptoms.ToArray();
                var prediction = APIInterface.Predict(ids.Select(x => x.ID).ToArray());
                if (prediction != null)
                {
                    if (prediction.StateCode == 2)
                    {
                        var dis = prediction.ResultDisease;
                        var det = DataModel.GetDetails(dis.ID);
                        Navigation.PushAsync(new VDiseaseDetials(dis, det));
                    }
                    else if (prediction.StateCode == 1)
                        Navigation.PushAsync(new VQuestion(prediction.ResultSymptoms.ToList(), ids.ToList()));
                    else
                        DisplayAlert("Error", "Some thing went wrong! .. Retry", "Ok");
                }
                else
                {
                    DisplayAlert("Error", "Some thing went wrong! .. Retry", "Ok");
                }
            }
            else
                DisplayAlert("Error", "Please Select Your Main Symptoms!", "Ok");
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            var buttom = sender as ImageButton;
            var grid = buttom.Parent as Grid;
            var dataContext = grid.BindingContext as Symptom;
            Symptoms.Remove(dataContext);
            list.ItemsSource = Symptoms.ToList();
        }
    }
}