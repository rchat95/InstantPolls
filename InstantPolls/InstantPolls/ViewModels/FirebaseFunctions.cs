using Firebase.Database;
using Firebase.Database.Query;
using InstantPolls.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstantPolls.ViewModels
{
    public class FirebaseFunctions
    {
        FirebaseClient firebase = new FirebaseClient("https://instantpolls-50888.firebaseio.com/");

        public async Task AddPoll(string userEmail,string pollDesc, string opt1, string opt2, string opt3 = "", string opt4 = "")
        {
            try
            {
                await firebase
                      .Child("Poll")
                      .PostAsync(new NewPoll() { UserEmail = userEmail, PollDesc = pollDesc, Option1 = opt1, Option2 = opt2, Option3 = opt3, Option4 = opt4 });
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}
