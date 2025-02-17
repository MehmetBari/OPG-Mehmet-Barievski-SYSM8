using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITTRACK_PROJEKTUPPGIFT_OPG.Classes
{
    public abstract class Person
    {
        // Egenskap för användarnamn
        public string Username { get; set; }

        // Egenskap för lösenord
        public string Password { get; set; }

        // Konstruktor som sätter användarnamn och lösenord

        public Person(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        // Abstrakt metod för inloggning
        public abstract bool SignIn(string username,string password);

    }
}
