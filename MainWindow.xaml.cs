using FITTRACK_PROJEKTUPPGIFT_OPG.Classes;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FITTRACK_PROJEKTUPPGIFT_OPG
{
  
    public partial class MainWindow : Window
    {
        static bool FirstTimeOpen = true;
        public MainWindow()
        {
            InitializeComponent();
            if (FirstTimeOpen)
            {
                User user = new User("User", "Emil", "1");
                User.userlist.Add(user);

                User user2 = new User("Sweden", "Mehemet", "1");
                User.userlist.Add(user2);

                User Admin = new AdminUser("Sweden", "Admin", "1");
                User.userlist.Add(Admin);

                // Creating initial pre-login workouts
                Workout workout1 = new StrengthWorkout(70, DateTime.Now.AddDays(-5), "Strength", "Leg Day", TimeSpan.FromMinutes(45), 350);
                Workout workout2 = new CardioWorkout(40, DateTime.Now.AddDays(-10), "Cardio", "Morning Run", TimeSpan.FromMinutes(30), 200);
                Workout workout4 = new CardioWorkout(45, DateTime.Now.AddDays(-7), "Cardio", "Interval Training", TimeSpan.FromMinutes(35), 250);
                Workout workout6 = new CardioWorkout(35, DateTime.Now.AddDays(-12), "Cardio", "Evening Walk", TimeSpan.FromMinutes(20), 100);



                // Adding workouts to users' lists
                user.Workouts.Add(workout1);
                user.Workouts.Add(workout2);


                user2.Workouts.Add(workout4);
                user2.Workouts.Add(workout6);

                FirstTimeOpen = false;
            }
            
            
        }
        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;

            // Kontrollera om användarnamn och lösenord är korrekta
            User user = new User("Sweden",username,password);
            // Kollar om användaren matchar i Databas
            bool LoggedIn = user.SignIn(username,password);
            if (LoggedIn)
            {
                WorkoutsWindow workoutsWindow = new WorkoutsWindow(User.currentUser);
                workoutsWindow.Show();
                this.Close();
            }
            else MessageBox.Show("Invalid Login");
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close(); // Stänger MainWindow och öppnar RegisterWindow
        }

    }
}