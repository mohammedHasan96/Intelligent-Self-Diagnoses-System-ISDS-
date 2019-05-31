using ISDS.Models;
using ISDS.Utils;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ISDS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VConditions : ContentPage
    {
        List<Disease> DiseasesCollection { get; } = new List<Disease>();
        public VConditions()
        {
            InitializeComponent();
            IsActive.IsVisible = true;

            new Thread(() =>
            {
                try
                {
                    while (!DataModel.IsReadyD)
                        Thread.Sleep(60);
                    DiseasesCollection.ReFill(DataModel.Diseases);
                    Device.BeginInvokeOnMainThread(() => { diseasesList.ItemsSource = DiseasesCollection; });
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
        }

        private void MyEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            diseasesList.ItemsSource = DataModel.Diseases.Where(x => x.DiseaseName.ToLower().Contains(e.NewTextValue.ToLower())).Select(x => x.DiseaseName).ToList();
        }

        private void DiseasesList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                var disease = e.Item as Disease;
                if (disease != null)
                {
                    var details = DataModel.GetDetails(disease.ID);
                    Navigation.PushAsync(new VDiseaseDetials(disease, details));
                }
            }
            catch { }
        }
    }
}