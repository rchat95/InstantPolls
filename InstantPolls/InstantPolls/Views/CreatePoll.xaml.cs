using Firebase.Database;
using InstantPolls.ViewModels;
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
    public partial class CreatePoll : ContentPage
    {
        FirebaseFunctions firebaseFunctions = new FirebaseFunctions();
        private int option_count = 2;
        public CreatePoll()
        {
            InitializeComponent();
            this.ToolbarItems.Add(new ToolbarItem {IconImageSource = "settings.png" });
            
        }

        private void AddMore_Clicked(object sender, EventArgs e)
        {
            if (option_count >= 4)
            {
                DisplayAlert("Alert","Cannot add more than 4 options","OK");
            }
            else
            {
                ++option_count;
                var MyEntry = new Entry {
                    Placeholder = "Option " + option_count };
                mainStack.Children.Add(MyEntry); 
            }
        }

        private void Minus_Clicked(object sender, EventArgs e)
        {
            if (option_count <= 2)
            {
                DisplayAlert("Alert", "Cannot have less than 2 options", "OK");
            }
            else
            {
                
                mainStack.Children.RemoveAt(option_count + 1);
                --option_count;
            }
        }

        async private void Submit_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (quesDesc.Text == null)
                {
                    await DisplayAlert("Alert", "Description required", "OK");
                    return;
                }
                if (opt1.Text == null || opt2.Text == null)
                {
                    await DisplayAlert("Alert", "At least 2 options are required", "OK");
                    return;
                }

                if (opt3.Text == null)
                {
                    opt3.Text = "";
                }
                if (opt4.Text == null)
                {
                    opt4.Text = "";
                }

                await firebaseFunctions.AddPoll(Constants.Constants.CURRENT_USER_EMAIL,quesDesc.Text, opt1.Text, opt2.Text, opt3.Text, opt4.Text);

                await DisplayAlert("Success", "Poll created successfully", "OK");
            }
            catch (Exception ex)
            {

            }


        }
    }
}