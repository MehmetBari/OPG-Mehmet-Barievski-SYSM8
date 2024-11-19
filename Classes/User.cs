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

        //Egenskaper
        public static User currentUser { get; set; }

        public static List<User> userlist = new List<User>();
        public List<Workout> Workouts { get; set; }
        public string country { get; set; }
        
        public bool isAdmin { get; set; }



        //Konstruktor
        public User(string country, string username,string password) : base (username,password)
        {
            isAdmin = false;
            this.country = country;
            Workouts = new List<Workout>();
        }


        // Metod override från Person
        public override bool SignIn(string username, string password)
        {
            foreach (var user in userlist)
            {
                if (username.ToLower() == user.Username.ToLower() && password == user.Password)
                {
                    MessageBox.Show("Login successful!");
                    currentUser = user;

                    return true;
                }                
            }
            return false;
        }
        public void ResetPassword()
        {

        }

        public static List<Workout> GetUserWorkouts()
        {
            List<Workout> userWorkouts = new List<Workout>();

            foreach (var workout in currentUser.Workouts)
            {                
                userWorkouts.Add(workout);                
            }

            return userWorkouts;
        }

        public static User GetUser(string username)
        {
            foreach(var user in userlist)
            {
                return user;
            }
            return null;
        }
        public static User GetCurrentUser()
        {
            return currentUser;
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

        public static User GetOwnerOfWorkout(Workout targetWorkout)
        {
            // Iterate through the list of users to find the first owner
            foreach (User user in User.userlist) // Assuming `User.userlist` contains all users
            {
                if (user.Workouts.Contains(targetWorkout))
                {
                    return user; // Return the first owner found
                }
            }

            // Return null if no owner is found
            return null;
        }

        public static bool CheckUserExist(string username)
        {
            foreach(var user in User.userlist)
            {
                if (username == user.Username)
                {
                    return true;
                }
            }
            return false;

        }
    }
}
