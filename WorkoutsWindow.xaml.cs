using FITTRACK_PROJEKTUPPGIFT_OPG.Classes;
using System;
using System.Collections.Generic;
using System.Data;
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

    
    public partial class WorkoutsWindow : Window
    {
        private User currentUser;
        public DataRow row;
        public WorkoutsWindow(User user)
        {
            InitializeComponent();
            currentUser = User.GetCurrentUser();
            UsernameLabel.Content = $"Welcome, {currentUser.Username}";
            DisplayWorkouts();
        }
        
        
        private void AddWorkoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Öppnar AddWorkoutWindow och stänger detta window
            AddWorkoutWindow addWorkoutWindow = new AddWorkoutWindow();
            addWorkoutWindow.Show();
            this.Close();
        }

        

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            Workout selectedWorkout = WorkoutsDataGrid.SelectedItem as Workout;
            if (selectedWorkout != null)
            {
                var workoutsList = WorkoutsDataGrid.ItemsSource as List<Workout>;

                WorkoutDetailsWindow workoutDetailsWindow = new WorkoutDetailsWindow(selectedWorkout);
                workoutDetailsWindow.Show();
                               
            }


        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            //skapar ett objekt av vad användaren har tryckt
            Workout selectedWorkout = WorkoutsDataGrid.SelectedItem as Workout;

            if (selectedWorkout != null)
            {
                

                //en lista med alla workouts 
                var workoutsList = WorkoutsDataGrid.ItemsSource as List<Workout>;
                
                //kollar så workout inte är null
                if (workoutsList != null)
                {
                    //tar bort workout
                    workoutsList.Remove(selectedWorkout);                    
                    User owner = User.GetOwnerOfWorkout(selectedWorkout);

                    owner.Workouts.Remove(selectedWorkout);


                    // Refresh the DataGrid after removal
                    WorkoutsDataGrid.ItemsSource = null;
                    WorkoutsDataGrid.ItemsSource = workoutsList;
                }
            }
            else
            {
                MessageBox.Show("No workout selected.");
            }
        }



        private void DisplayWorkouts()
        {
            if(currentUser.isAdmin)
            {
                List<Workout> Workouts = AdminUser.GetAllWorkouts();

                WorkoutsDataGrid.ItemsSource = Workouts;            
            }
            else
            {
                List<Workout> Workouts = User.GetUserWorkouts();

                WorkoutsDataGrid.ItemsSource = Workouts;
            }
        }




        private void WorkoutsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Retrieve the selected item and cast it to a Workout object
            Workout selectedWorkout = WorkoutsDataGrid.SelectedItem as Workout;

            if (selectedWorkout != null)
            {
                // Now you have access to the entire Workout object when any cell is clicked
                MessageBox.Show($"Selected Workout: {selectedWorkout.Type} on {selectedWorkout.Date}");
            }
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            // Öppnar UserDetailsWindow och stänger WorkoutsWindow
            UserDetailsWindow userDetailsWindow = new UserDetailsWindow();
            userDetailsWindow.Show();
            this.Close();
        }

        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            // Öpnnar MainWindow och stänger WorkoutsWindow
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Info_Button(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is an informational message.",
                "Information",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}
