using ISDS.Models;
using ISDS.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace ISDS
{
    public partial class VLogin : ContentPage
    {
        public VLogin()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            signUp.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    //if (lastTap.AddSeconds(2) > DateTime.Now)
                    Navigation.PushAsync(new VRegister());
                })
            });
            //signUp.GestureRecognizers.Add(new TapGestureRecognizer((view) => { Navigation.PushAsync(new VRegister()); }));
        }

        DateTime lastTap = DateTime.Now.AddSeconds(-5);
        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new VMain());
                return;
                if (EmialAddress.Text.IsNull() || Password.Text.IsNull())
                {
                    DisplayAlert("Warning!", "Email Address and Password Can not be Empty !", "OK");
                    return;
                }
                var client = new HttpClient();
                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(new User { EmailAddress = EmialAddress.Text }));
                var response = client.PostAsync(Values.APILogin, content).Result.Content.ReadAsStringAsync().Result;
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginResult>(response);
                if (result != null)
                {
                    if (result.StateCode == Values.CodeSuccess)
                    {
                        Values.AccessToken = result.Result;
                        Navigation.PushAsync(new VMain());
                    }
                }
            }
            catch
            {
                DisplayAlert("Error!", "Some Thing went wrong!", "OK");
            }
            finally
            {

            }
        }
    }
}
