using ISDS.Models;
using ISDS.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ISDS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VQuestion : ContentPage
    {
        List<Symptom> sympsQ;
        List<Symptom> symps;
        public VQuestion(List<Symptom> sympsQ, List<Symptom> symps)
        {
            this.sympsQ = sympsQ;
            this.symps = symps;
            InitializeComponent();
            Q1.Text = this.sympsQ[0].SymptomName;
            Q2.Text = this.sympsQ[1].SymptomName;
            Q3.Text = this.sympsQ[2].SymptomName;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (NoAnswers())
                DisplayAlert("Error", "Please select at least one answer!", "Ok");
            else
            {
                var sympId = Q1.IsChecked ? sympsQ[0] : Q2.IsChecked ? sympsQ[1] : Q3.IsChecked ? sympsQ[2] : null;
                if (sympId != null)
                    symps.Add(sympId);
                var prediction = APIInterface.Predict(symps.Select(x => x.ID).ToArray());
                if (prediction != null)
                {
                    if (prediction.StateCode == 2)
                    {
                        var dis = prediction.ResultDisease;
                        var det = DataModel.GetDetails(dis.ID);
                        Navigation.PushAsync(new VDiseaseDetials(dis, det));
                    }
                    else if (prediction.StateCode == 1)
                        Navigation.PushAsync(new VQuestion(prediction.ResultSymptoms.ToList(), symps));
                    else
                        DisplayAlert("Error", "Some thing went wrong! .. Retry", "Ok");
                }
                else
                {
                    DisplayAlert("Error", "Some thing went wrong! .. Retry", "Ok");
                }
            }
        }

        bool NoAnswers()
            => !(Q1.IsChecked || Q2.IsChecked || Q3.IsChecked || Q4.IsChecked);
    }
}