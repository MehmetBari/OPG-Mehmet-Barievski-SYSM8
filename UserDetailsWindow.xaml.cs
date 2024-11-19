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
    /// <summary>
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        
        public UserDetailsWindow()
        {
            InitializeComponent();
            CurrentUsername.Text = User.currentUser.Username; // Fyll med faktiska data
            CountryComboBox.SelectedIndex = 0; // Exempel
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            User user = User.currentUser;
            string New_Username = NewUsername.Text;
            string New_Password = NewPassword.Password;
            string Confirm_Password = ConfirmPassword.Password;

            bool userExist = User.CheckUserExist(New_Username);
            if(userExist == true)
            {
                MessageBox.Show("Användarnamn redan upptaget", "Varning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }



            if (New_Username.Length < 3)
            {
                MessageBox.Show("Användarnamn måste vara minst 3 tecken långt.", "Varning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                user.Username = New_Username;
            }

            if (New_Password.Length < 5)
            {
                MessageBox.Show("Lösenord måste vara minst 5 tecken långt.", "Varning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            

            if (New_Password != Confirm_Password)
            {
                MessageBox.Show("Lösenorden stämmer inte överens.", "Varning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                user.Password = New_Password;
            }

            // Kontrollera om användarnamn är upptaget 
            
            

            // Spara uppgifter
            MessageBox.Show("Användaruppgifter sparade.");
            WorkoutsWindow workoutsWindow = new WorkoutsWindow(Classes.User.currentUser);
            workoutsWindow.Show();
            Close();
            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            WorkoutsWindow workoutsWindow = new WorkoutsWindow(Classes.User.currentUser);
            workoutsWindow.Show();
            Close();
        }
    }
}

