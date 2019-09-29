using System;
using System.Collections.Generic;
using System.Text;

namespace InstantPolls.Models
{
    public class NewPoll
    {
        public string UserEmail {get; set;}
        public string PollDesc {get; set;}
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
    }
}
