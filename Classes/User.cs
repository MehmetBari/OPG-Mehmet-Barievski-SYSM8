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

        // Statisk egenskap som håller den nuvarande inloggade användaren
        public static User currentUser { get; set; }

        // Lista som innehåller alla registrerade användare

        public static List<User> userlist = new List<User>();

        // Lista som innehåller användarens träningspass
        public List<Workout> Workouts { get; set; }

        // Land som användaren tillhör
        public string country { get; set; }

        // Bool som anger om användaren är administratör

        public bool isAdmin { get; set; }



        // Konstruktor som sätter användarens land, användarnamn och lösenord
        public User(string country, string username,string password) : base (username,password)
        {
            isAdmin = false; // Standardvärde, användaren är ej admin
            this.country = country;
            Workouts = new List<Workout>(); // Skapar en tom lista för träningspass
        }


        // Metod för inloggning, override från Person-klassen
        public override bool SignIn(string username, string password)
        {
            foreach (var user in userlist)
            {
                // Kontrollera om användarnamn och lösenord matchar en befintlig användare
                if (username.ToLower() == user.Username.ToLower() && password == user.Password)
                {
                    MessageBox.Show("Login successful!");
                    currentUser = user; // Sätter den inloggade användaren

                    return true;
                }                
            }
            return false; // Returnerar false om ingen matchning hittas
        }
        public void ResetPassword()
        {

        }

        // Hämtar träningspassen för den aktuella användaren
        public static List<Workout> GetUserWorkouts()
        {
            List<Workout> userWorkouts = new List<Workout>();

            // Lägger till användarens träningspass i en ny lista
            foreach (var workout in currentUser.Workouts)
            {                
                userWorkouts.Add(workout);                
            }

            return userWorkouts;
        }

        // Hämtar en användare baserat på användarnamn
        public static User GetUser(string username)
        {
            foreach(var user in userlist)
            {
                return user; // Returnerar första användaren i listan
            }
            return null; // Returnerar null om ingen användare hittas
        }

        // Hämtar den nuvarande inloggade användaren
        public static User GetCurrentUser()
        {
            return currentUser;
        }

        // Registrerar en ny användare
        public static void RegisterUser(string country,string username, string password)
        {
            bool userExist = false;

            // Kontrollera om användarnamnet redan finns i listan
            foreach (var users in userlist)
            {
                if(username == users.Username)
                {
                    userExist = true;
                }
            }
            // Om användaren inte redan finns, skapa och lägg till den
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

        // Hittar ägaren till ett specifikt träningspass
        public static User GetOwnerOfWorkout(Workout targetWorkout)
        {
            // Itererar genom alla användare för att hitta rätt ägare
            foreach (User user in User.userlist) 
            {
                if (user.Workouts.Contains(targetWorkout))
                {
                    return user; // Returnerar den första användaren som har träningspasset
                }
            }

            // Returnerar null om ingen ägare hittas
            return null;
        }

        // Kontrollerar om en användare finns baserat på användarnamn
        public static bool CheckUserExist(string username)
        {
            foreach(var user in User.userlist)
            {
                if (username == user.Username)
                {
                    return true;
                }
            }
            return false; // Returnerar false om ingen användare hittas

        }
    }
}
