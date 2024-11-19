using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITTRACK_PROJEKTUPPGIFT_OPG.Classes
{
    public class AdminUser : User
    {
    public AdminUser(string Country, string username, string password) : base(Country, username, password)
        {
            isAdmin = true;
        }

        public void ManageAllWorkouts()
        {

        }

        public static List<Workout> GetAllWorkouts()
        {
            List<Workout> Allworkouts = new List<Workout>();
            
            foreach(var user in User.userlist)
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

