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
    /// Interaction logic for AddWorkoutWindow.xaml
    /// </summary>
    public partial class AddWorkoutWindow : Window
    {
        public AddWorkoutWindow()
        {
            InitializeComponent();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DateInput.Text) ||
                string.IsNullOrWhiteSpace(TypeInput.Text) ||
                string.IsNullOrWhiteSpace(DurationInput.Text) ||
                string.IsNullOrWhiteSpace(CaloriesInput.Text) ||
                string.IsNullOrWhiteSpace(NotesInput.Text))
            {
                MessageBox.Show("Alla fält måste fyllas i.", "Varning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                // Här sparas träningspasset.
                MessageBox.Show("Träningspass sparat!");
                Close();
            }
        }
    }
}
    

