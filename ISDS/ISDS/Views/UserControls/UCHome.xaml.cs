using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ISDS.Views.UserControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UCHome : ContentPage
    {
        public UCHome()
        {
            InitializeComponent();
        }

        private void Diseases_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VConditions());
        }

        private void SymptomChecker_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VSymptomChecker());
        }
    }
}