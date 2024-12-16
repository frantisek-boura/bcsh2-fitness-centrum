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

namespace FitnessApp.View
{
    /// <summary>
    /// Interaction logic for MembersAddDialog.xaml
    /// </summary>
    public partial class LessonsAddDialog : Window
    {

        public string? Name { get; private set; }
        public string? Type { get; private set; }
        public DateTime? Date { get; private set; }
        public int? Capacity { get; private set; }


        public LessonsAddDialog()
        {
            InitializeComponent();
        }

        private void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            int capacity = 0;


            if (string.IsNullOrWhiteSpace(nameTextBox.Text) || string.IsNullOrWhiteSpace(typeTextBox.Text) || !dateDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show(
                $"Empty fields",
                "Invalid input",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
                return;
            } else if (!int.TryParse(capacityTextBox.Text, out capacity))
            {
                MessageBox.Show($"Value {capacityTextBox.Text} is not a valid number", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            } else
            {
                Name = nameTextBox.Text;
                Type = typeTextBox.Text;
                Date = dateDatePicker.SelectedDate;
                Capacity = capacity;
                DialogResult = true;
            }
        }

        private void Cancel_Clicked(object sender, RoutedEventArgs e)
        {
            Name = null;
            Type = null;
            Date = null;
            Capacity = null;
            DialogResult = false;
        }
    }
}
