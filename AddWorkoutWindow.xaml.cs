using FITTRACK_PROJEKTUPPGIFT_OPG.Classes;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace FITTRACK_PROJEKTUPPGIFT_OPG
{
  
    public partial class AddWorkoutWindow : Window
    {
        private User currentUser = User.GetCurrentUser();

        public AddWorkoutWindow()
        {
            InitializeComponent();
        }

        // Hanterar valändringen för träningstyp (Strength/Cardio)
        private void TypeWorkout_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Få den valda träningstypen
            string selectedType = (TypeWorkout.SelectedItem as System.Windows.Controls.ComboBoxItem)?.Content.ToString();

            // Visa/dölj lämpliga fält baserat på den valda träningstypen
            if (selectedType == "Strength")
            {
                RepetitionsInput.Visibility = Visibility.Visible;
                RepetitionsLabel.Visibility = Visibility.Visible;
                DistanceInput.Visibility = Visibility.Collapsed;
                DistanceLabel.Visibility = Visibility.Collapsed;
            }
            else if (selectedType == "Cardio")
            {
                DistanceInput.Visibility = Visibility.Visible;
                DistanceLabel.Visibility = Visibility.Visible;
                RepetitionsInput.Visibility = Visibility.Collapsed;
                RepetitionsLabel.Visibility = Visibility.Collapsed;
            }
            else
            {
                // Dölj båda fälten om ingen eller okänd träningstyp
                RepetitionsInput.Visibility = Visibility.Collapsed;
                DistanceInput.Visibility = Visibility.Collapsed;
                RepetitionsLabel.Visibility = Visibility.Collapsed;
                DistanceLabel.Visibility = Visibility.Collapsed;
            }
        }

        // Hanterar klick händelsen på Spara-knappen
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Kontrollerar om obligatoriska fält är ifyllda
            if (DateInput.SelectedDate == null || // Kontrollerar om datumet är valt
                string.IsNullOrWhiteSpace(TypeWorkout.SelectedItem?.ToString()) ||
                string.IsNullOrWhiteSpace(DurationInput.Text) ||
                string.IsNullOrWhiteSpace(CaloriesInput.Text) ||
                string.IsNullOrWhiteSpace(NotesInput.Text))
            {
                // Message box som visar att alla fält måste vara ifyllda och ger varning om de inte är 
                MessageBox.Show("Alla fält måste fyllas i.", "Varning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DateTime selectedDate = DateInput.SelectedDate.Value; // Get the selected date

            string selectedType = (TypeWorkout.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (selectedType == "Strength")
            {
                // Logik för Strength Workout
                int repetitions = 0;
                if (!int.TryParse(RepetitionsInput.Text, out repetitions))
                {
                    MessageBox.Show("Please enter a valid number of repetitions.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Skapa och lägg till Strength Workout
                StrengthWorkout strengthWorkout = new StrengthWorkout(
                    repetitions,
                    selectedDate,
                    "Strength",
                    NotesInput.Text,
                    TimeSpan.Parse(DurationInput.Text),
                    int.Parse(CaloriesInput.Text)
                );

                currentUser.Workouts.Add(strengthWorkout);
                MessageBox.Show("Strength workout added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                WorkoutsWindow workoutsWindow = new WorkoutsWindow(User.currentUser);
                workoutsWindow.Show();
                this.Close();
            }
            else if (selectedType == "Cardio")
            {
                // Logik för Cardio Workout
                double distance = 0;
                if (!double.TryParse(DistanceInput.Text, out distance))
                {
                    MessageBox.Show("Please enter a valid distance.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Skapa och lägg till Cardio Workout
                CardioWorkout cardioWorkout = new CardioWorkout(
                    (int)distance,
                    selectedDate,
                    "Cardio",
                    NotesInput.Text,
                    TimeSpan.Parse(DurationInput.Text),
                    int.Parse(CaloriesInput.Text)
                );

                currentUser.Workouts.Add(cardioWorkout);
                MessageBox.Show("Cardio workout added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                WorkoutsWindow workoutsWindow = new WorkoutsWindow(User.currentUser);
                workoutsWindow.Show();
                this.Close();
            }
        }



        
        
    }
}
