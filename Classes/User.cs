using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITTRACK_PROJEKTUPPGIFT_OPG.Classes
{
    public class User : Person 
    {
        //Egenskaper

        public string Country { get; set; }

        public string SecurityQuestion { get; set; }

        public string SecurityAnswer { get; set; }

        //Konstruktor

        public User(string Country, string SecurityQuestion, string SecurityAnswer)
        {
            this.Country = Country;
            this.SecurityQuestion = SecurityQuestion;
            this.SecurityAnswer = SecurityAnswer;
        }
        // Metod override från Person
        public override void SignIn()
        {
            throw new NotImplementedException();
        }
        public void ResetPassword(string SecurityAnswer)
        
        {
            throw new NotImplementedException();
        }
    }
}
