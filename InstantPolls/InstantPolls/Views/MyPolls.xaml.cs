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
    public partial class MyPolls : ContentPage
    {
        public MyPolls()
        {
            InitializeComponent();
            myPollList.ItemsSource = new List<string>
            {
                "Vote for the next representative", "Rongon", "Rahul", "Yash", "Naman"

            };
        }

        private void createBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreatePoll());
        }

       
    }
}