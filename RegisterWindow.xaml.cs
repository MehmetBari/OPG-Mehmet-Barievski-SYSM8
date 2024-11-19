using FITTRACK_PROJEKTUPPGIFT_OPG.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FITTRACK_PROJEKTUPPGIFT_OPG
{
  
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();

            //Kan lägga till fler länder om man vill
            CountryComboBox.ItemsSource = new List<string> { "Sweden", "Norway", "Denmark", "Finland" };

        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            //Hämtar inmatningar
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;
            string country = CountryComboBox.SelectedItem as string;
            //Validerar inmatningarna vi skrivit in 
            if (string.IsNullOrEmpty(country) && string.IsNullOrEmpty(password) && string.IsNullOrEmpty(username))
            {
                foreach (var user in User.userlist)
                {
                    if (user.Username != username)
                    {
                        MessageBox.Show("User does not exist");
                        return;
                    }
                }   
            }

            // Kolla om användarnamnet är upptaget 
            User.RegisterUser(country, username, password); 

            
           
                // Spara användaren och gå tillbaka till MainWindow
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            // Öppnar MainWindow och stänger Register Window
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
