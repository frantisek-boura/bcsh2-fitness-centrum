using FitnessApp.Model;
using FitnessApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FitnessApp.View
{
    /// <summary>
    /// Interaction logic for LessonsView.xaml
    /// </summary>
    public partial class LessonsView : UserControl
    {
        public Lesson Selected { get; set; }

        public LessonsView()
        {
            InitializeComponent();
        }

        private void DataGridSelection_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem == null || !(dataGrid.SelectedItem is Lesson))
            {
                removeButton.IsEnabled = false;
                return;
            }

            var row = dataGrid.SelectedItem as Lesson;
            removeButton.IsEnabled = true;
            Selected = row;
        }

        private void AddLesson_Clicked(object sender, RoutedEventArgs e)
        {
            var lessonsAddDialog = new LessonsAddDialog();
            lessonsAddDialog.Owner = Window.GetWindow(this);
            lessonsAddDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            bool? result = lessonsAddDialog.ShowDialog();

            if (result == true)
            {
                var viewmodel = (LessonsViewModel)DataContext;
                viewmodel.AddLesson(lessonsAddDialog.Name, lessonsAddDialog.Type, (int) lessonsAddDialog.Capacity, (DateTime) lessonsAddDialog.Date);
            }
        }

        private void Remove_Clicked(object sender, RoutedEventArgs e)
        {
            var viewmodel = (LessonsViewModel) DataContext;
            if (Selected == null) return;

            bool result = MessageBox.Show(
                $"Do you really want to delete selected lessons?",
                "Remove lesson",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            ) == MessageBoxResult.Yes;

            if (result)
            {
                viewmodel.RemoveLesson(Selected);
            }
        }
    }
}
