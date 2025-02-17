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
        // Variabel som håller reda på om fönstret öppnas för första gången
        static bool FirstTimeOpen = true;
        public MainWindow()
        {
            InitializeComponent();
            // Initialiserar användare och träningspass endast vid första öppningen
            if (FirstTimeOpen)
            {
                // Skapar och lägger till några användare
                User user = new User("User", "Emil", "1");
                User.userlist.Add(user);

                User user2 = new User("Sweden", "Mehemet", "1");
                User.userlist.Add(user2);

                User Admin = new AdminUser("Sweden", "Admin", "1");
                User.userlist.Add(Admin);

                // Skapar förinställda träningspass
                Workout workout1 = new StrengthWorkout(70, DateTime.Now.AddDays(-5), "Strength", "Leg Day", TimeSpan.FromMinutes(45), 350);
                Workout workout2 = new CardioWorkout(40, DateTime.Now.AddDays(-10), "Cardio", "Morning Run", TimeSpan.FromMinutes(30), 200);
                Workout workout4 = new CardioWorkout(45, DateTime.Now.AddDays(-7), "Cardio", "Interval Training", TimeSpan.FromMinutes(35), 250);
                Workout workout6 = new CardioWorkout(35, DateTime.Now.AddDays(-12), "Cardio", "Evening Walk", TimeSpan.FromMinutes(20), 100);



                // Lägger till träningspassen till respektive användares lista
                user.Workouts.Add(workout1);
                user.Workouts.Add(workout2);


                user2.Workouts.Add(workout4);
                user2.Workouts.Add(workout6);

                // Förhindrar att denna kod körs igen vid framtida öppningar
                FirstTimeOpen = false;
            }
            
            
        }
        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            // Hämtar användarnamn och lösenord från inmatningsfälten
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;

            // Skapar en temporär användare baserat på inmatningen
            User user = new User("Sweden",username,password);
            // Kontrollerar om användaren finns i systemet och om inloggningen lyckas
            bool LoggedIn = user.SignIn(username,password);
            if (LoggedIn)
            {
                // Öppnar WorkoutsWindow och stänger nuvarande fönster om inloggningen är lyckad
                WorkoutsWindow workoutsWindow = new WorkoutsWindow(User.currentUser);
                workoutsWindow.Show();
                this.Close();
            }
            // Visar ett felmeddelande om inloggningen misslyckades
            else MessageBox.Show("Invalid Login");
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Öppnar registreringsfönstret
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close(); // Stänger MainWindow och öppnar RegisterWindow
        }

    }
}