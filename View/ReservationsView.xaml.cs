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
using System.Xml.XPath;

namespace FitnessApp.View
{
    /// <summary>
    /// Interaction logic for ReservationsView.xaml
    /// </summary>
    public partial class ReservationsView : UserControl
    {
        public Reservation? Selected { get; set; }

        public ReservationsView()
        {
            InitializeComponent();
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            var viewmodel = (ReservationsViewModel) DataContext;
            viewmodel.ApplyFilter(filterMemberFirstName.Text, filterMemberLastName.Text, filterLessonType.Text, filterReservationDate.SelectedDate);
            viewmodel.RefreshGrid();
        }
        private void ClearFilterButton_Click(object sender, RoutedEventArgs e)
        {
            filterMemberFirstName.Text = "";
            filterMemberLastName.Text = "";
            filterLessonType.Text = "";
            filterReservationDate.SelectedDate = null;

            var viewmodel = (ReservationsViewModel) DataContext;
            viewmodel.ResetFilter();
            viewmodel.RefreshGrid();
        }

        private void DataGridSelection_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem == null || !(dataGrid.SelectedItem is Reservation))
            {
                removeButton.IsEnabled = false;
                editButton.IsEnabled = false;
                return;
            } 

            var row = dataGrid.SelectedItem as Reservation;
            removeButton.IsEnabled = true;
            editButton.IsEnabled = true;
            Selected = row;
        }

        private void AddReservation_Clicked(object sender, RoutedEventArgs e)
        {
            var reservationsAddDialog = new ReservationsAddDialog();
            reservationsAddDialog.Owner = Window.GetWindow(this);
            reservationsAddDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            bool? result = reservationsAddDialog.ShowDialog();
            var viewmodel = (ReservationsViewModel) DataContext;

            if (result == true)
            {
                viewmodel.AddReservation(reservationsAddDialog.Member, reservationsAddDialog.Lesson, (DateTime) reservationsAddDialog.CreatedOn);
                viewmodel.RefreshGrid();
            }
        }

        private void RemoveReservation_Clicked(object sender, RoutedEventArgs e)
        {
            var viewmodel = (ReservationsViewModel) DataContext;
            if (Selected == null) return;

            bool result = MessageBox.Show(
                $"Do you really want to delete selected reservations?",
                "Remove reservation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            ) == MessageBoxResult.Yes;

            if (result) {
                viewmodel.RemoveReservation(Selected);
                viewmodel.RefreshGrid();
            }
        }

        private void EditReservation_Clicked(object sender, RoutedEventArgs e)
        {
            var reservationsEditDialog = new ReservationsEditDialog(Selected.Member, Selected.Lesson);
            reservationsEditDialog.Owner = Window.GetWindow(this);
            reservationsEditDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            bool? result = reservationsEditDialog.ShowDialog();
            var viewmodel = (ReservationsViewModel) DataContext;

            if (result == true)
            {
                viewmodel.EditReservation(Selected, reservationsEditDialog.Member, reservationsEditDialog.Lesson);
                viewmodel.RefreshGrid();
            }
        }
    }
}
