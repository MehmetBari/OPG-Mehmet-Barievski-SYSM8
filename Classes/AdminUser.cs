using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITTRACK_PROJEKTUPPGIFT_OPG.Classes
{
    public class AdminUser : User
    {
        // Konstruktor som skapar en adminanvändare
        public AdminUser(string Country, string username, string password) : base(Country, username, password)
        {
            isAdmin = true; // Sätter användaren som administratör
        }

        public void ManageAllWorkouts()
        {

        }

        // Metod för att hämta alla träningspass från alla användare
        public static List<Workout> GetAllWorkouts()
        {
            List<Workout> Allworkouts = new List<Workout>();

            // Loopar igenom alla användare och samlar in deras träningspass
            foreach (var user in User.userlist)
            {
                foreach (var workout in user.Workouts)
                {
                    Allworkouts.Add(workout);
                }
            }
            return Allworkouts;
        }
    }

   
}

