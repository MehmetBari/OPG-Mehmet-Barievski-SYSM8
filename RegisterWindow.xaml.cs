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


            // Fyller CountryComboBox med en lista av länder.
            // Man kan enkelt lägga till fler länder om det behövs.
            CountryComboBox.ItemsSource = new List<string> { "Sweden", "Norway", "Denmark", "Finland" };

        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Hämtar inmatade värden från fälten
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;
            string country = CountryComboBox.SelectedItem as string;

            // Validerar om alla fält är ifyllda
            if (string.IsNullOrEmpty(country) && string.IsNullOrEmpty(password) && string.IsNullOrEmpty(username))
            {
                // Går igenom befintliga användare för att se om användaren finns
                foreach (var user in User.userlist)
                {
                    if (user.Username != username)
                    {
                        MessageBox.Show("User does not exist");
                        return; // Avbryter registreringen om användaren inte finns
                    }
                }   
            }

            // Registrerar den nya användaren om valideringen godkänns
            User.RegisterUser(country, username, password);



            // Öppnar huvudfönstret (MainWindow) och stänger registreringsfönstret
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
