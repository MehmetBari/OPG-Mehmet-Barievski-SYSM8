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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            User user = new User("User", "User", "1");
            User.userlist.Add(user);
        }
        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;

            // Kontrollera om användarnamn och lösenord är korrekta
            User user = new User("Sweden",username,password);
            bool LoggedIn = user.SignIn(username,password);
            if (LoggedIn)
            {
                WorkoutsWindow workoutsWindow = new WorkoutsWindow(username);
                workoutsWindow.Show();
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