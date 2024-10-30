using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITTRACK_PROJEKTUPPGIFT_OPG.Classes
{
    public abstract class Person
    {
        //Egenskaper
        public string Username { get; set; }

        public string Password { get; set; } 

        //Konstruktor 

        public Person(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        //Metod
        public abstract bool SignIn(string username,string password);

    }
}
