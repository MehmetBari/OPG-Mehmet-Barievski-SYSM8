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
            CurrentUsername.Text = "Nuvarande användarnamn"; // Fyll med faktiska data
            CountryComboBox.SelectedIndex = 0; // Exempel
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (NewUsername.Text.Length < 3)
            {
                MessageBox.Show("Användarnamn måste vara minst 3 tecken långt.", "Varning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (NewPassword.Password.Length < 5)
            {
                MessageBox.Show("Lösenord måste vara minst 5 tecken långt.", "Varning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (NewPassword.Password != ConfirmPassword.Password)
            {
                MessageBox.Show("Lösenorden stämmer inte överens.", "Varning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Kontrollera om användarnamn är upptaget (exempel)
            bool usernameTaken = false; // Placeholder - implementera en faktisk kontroll
            if (usernameTaken)
            {
                MessageBox.Show("Användarnamn är upptaget.", "Varning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Spara uppgifter
            MessageBox.Show("Användaruppgifter sparade.");
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

