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
    /// Interaction logic for WorkoutsWindow.xaml
    /// </summary>
    public partial class WorkoutsWindow : Window
    {
        private string currentUser;
        public WorkoutsWindow(string username)
        {
            InitializeComponent();
            currentUser = username;
            UsernameLabel.Content = $"Welcome, {currentUser}";
        }
        private void AddWorkoutButton_Click(object sender, RoutedEventArgs e)
        {
            AddWorkoutWindow addWorkoutWindow = new AddWorkoutWindow();
            addWorkoutWindow.Show();
            this.Close();
        }

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            if (WorkoutsListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a workout.");
                return;
            }

            WorkoutDetailsWindow detailsWindow = new WorkoutDetailsWindow();
            detailsWindow.Show();
            this.Close();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            // Ta bort valt träningspass från listan
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsWindow userDetailsWindow = new UserDetailsWindow();
            userDetailsWindow.Show();
            this.Close();
        }

        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
