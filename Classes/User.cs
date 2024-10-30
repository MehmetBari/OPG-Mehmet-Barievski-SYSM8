using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FITTRACK_PROJEKTUPPGIFT_OPG.Classes
{
    public class User : Person 
    {
       
        public static List<User> userlist = new List<User>();

        //Egenskaper

        public string Country { get; set; }

        

        

        //Konstruktor

        public User(string Country, string username,string password) : base (username,password)

        {
            this.Country = Country;
           
        }
        // Metod override från Person
        public override bool SignIn(string username, string password)
        {
            foreach (var user in userlist)
            {
                if (username == user.Username && password == user.Password)
                {
                    MessageBox.Show("Login successful!");
                    return true;

                }
                


            }
            return false;
        }
        public void ResetPassword(string SecurityAnswer)
        
        {
            throw new NotImplementedException();
        }
    }
}
