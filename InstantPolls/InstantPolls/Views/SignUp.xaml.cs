using InstantPolls.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstantPolls.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();
        }
        async private void SignUp_Clicked(object sender, EventArgs e)
        {
            #region Rules
            if (userEmail.Text == null)
            {
                await DisplayAlert("Alert", "Email address cannot be blank", "OK");
                return;
            }
            if (userPassword.Text == null)
            {
                await DisplayAlert("Alert", "Password cannot be blank", "OK");
                return;
            }
            if (!userEmail.Text.Contains('@'))
            {
                await DisplayAlert("Alert", "Invalid Email", "OK");
                return;
            }
            if (userPassword.Text.Length < 6)
            {
                await DisplayAlert("Alert", "Password should be atleast 6 characters long", "OK");
                return;
            }
            if (userPassword.Text != userConfirmPass.Text)
            {
                await DisplayAlert("Alert", "Passwords do not match", "OK");
                return;
            } 
            #endregion

            try
            {
                var token = await DependencyService.Get<IFirebaseAuthenticator>().RegsiterWithEmailPassword(userEmail.Text, userPassword.Text);
                if (token != null)
                {
                    //Sign up success
                    await Navigation.PushAsync(new MyPolls());
                    Constants.Constants.CURRENT_USER_EMAIL = userEmail.Text;
                }
                else
                {
                    await DisplayAlert("Alert","Inavlid username or password","OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alert", "Inavlid username or password", "OK");
            }
        }
    }
}