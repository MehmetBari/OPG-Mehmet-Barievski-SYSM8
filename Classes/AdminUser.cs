using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITTRACK_PROJEKTUPPGIFT_OPG.Classes
{
    public class AdminUser : User
    {
    public AdminUser(string Country, string SecurityQuestion, string SecurityAnswer, string username, string password) : base(Country, SecurityQuestion, SecurityAnswer, username, password)
        {

        }
        public void ManageAllWorkouts()
        {

        }
    }

   
}

