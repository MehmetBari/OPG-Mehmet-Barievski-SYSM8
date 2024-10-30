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
    /// Interaction logic for WorkoutDetailsWindow.xaml
    /// </summary>
    public partial class WorkoutDetailsWindow : Window
    {
        private bool isEditing = false;
        public WorkoutDetailsWindow()
        {
            InitializeComponent();
            LoadWorkoutDetails(); 
        }
        private void LoadWorkoutDetails()
        {
            // Här laddar du träningsdetaljerna
            DateTextBox.Text = "2023-10-01"; // exempelvärden
            TypeTextBox.Text = "Running";
            DurationTextBox.Text = "45";
            CaloriesTextBox.Text = "350";
            NotesTextBox.Text = "Sunny day, felt great!";
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
            var workoutsWindow = new WorkoutsWindow();
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
    

