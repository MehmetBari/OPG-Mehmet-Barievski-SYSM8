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

        public string country { get; set; }

        

        

        //Konstruktor

        public User(string country, string username,string password) : base (username,password)

        {
            this.country = country;
           
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
        public void ResetPassword()
        
        {
            
        }
        public static void RegisterUser(string country,string username, string password)
        {
            bool userExist = false;

            foreach(var users in userlist)
            {
                if(username == users.Username)
                {
                    userExist = true;
                }
            }

            if (!userExist)
            {
                User user = new User(country, username, password);
                userlist.Add(user);
            }
            else
            {
                MessageBox.Show($"{username} already exist");
            }

            
        }
    }
}
