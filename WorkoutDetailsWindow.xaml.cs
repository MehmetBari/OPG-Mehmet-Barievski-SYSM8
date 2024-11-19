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
  
    public partial class WorkoutDetailsWindow : Window
    {
        private bool isEditing = false;
        private Workout Workout;
        public WorkoutDetailsWindow(Workout Workout)
        {
            this.Workout = Workout;
            InitializeComponent();
            LoadWorkoutDetails(); 
        }
        private void LoadWorkoutDetails()
        {
            // Här laddar du träningsdetaljerna
            DateTextBox.Text = Workout.Date.ToString("MM/dd/yyyy");
            TypeTextBox.Text = Workout.Type;
            DurationTextBox.Text = Workout.Duration.ToString();
            CaloriesTextBox.Text = Workout.CaloriesBurned.ToString();
            NotesTextBox.Text = Workout.Notes;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            isEditing = !isEditing;
            SetEditingMode(isEditing);
        }

        private void SetEditingMode(bool editing)
        {
            DateTextBox.IsReadOnly = !editing;
            TypeTextBox.IsReadOnly = !editing;
            DurationTextBox.IsReadOnly = !editing;
            CaloriesTextBox.IsReadOnly = !editing;
            NotesTextBox.IsReadOnly = !editing;

            EditButton.Content = editing ? "Cancel" : "Edit";
            SaveButton.IsEnabled = editing;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Validera att alla fält är korrekt ifyllda
            if (string.IsNullOrWhiteSpace(DateTextBox.Text) ||
                string.IsNullOrWhiteSpace(TypeTextBox.Text) ||
                string.IsNullOrWhiteSpace(DurationTextBox.Text) ||
                string.IsNullOrWhiteSpace(CaloriesTextBox.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Här sparar du de nya träningsuppgifterna
            SaveWorkoutDetails();

            // Stäng detta fönster och öppna WorkoutsWindow
            var workoutsWindow = new WorkoutsWindow(User.currentUser);
            workoutsWindow.Show();
            this.Close();
        }

        private void SaveWorkoutDetails()
        {
            // Exempel på sparfunktion 
            MessageBox.Show("Workout details have been saved.");
        }
    }
}
    

