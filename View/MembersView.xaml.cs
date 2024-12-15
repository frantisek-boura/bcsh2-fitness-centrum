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
    /// Interaction logic for MembersView.xaml
    /// </summary>
    public partial class MembersView : UserControl
    {
        public Member Selected { get; set; }

        public MembersView()
        {
            InitializeComponent();
        }

        private void DataGridSelection_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem == null || !(dataGrid.SelectedItem is Member))
            {
                removeButton.IsEnabled = false;
                return;
            } 

            var row = dataGrid.SelectedItem as Member;
            removeButton.IsEnabled = true;
            Selected = row;
        }

        private void AddMember_Clicked(object sender, RoutedEventArgs e)
        {
            var membersAddDialog = new MembersAddDialog();
            membersAddDialog.Owner = Window.GetWindow(this);
            membersAddDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            bool? result = membersAddDialog.ShowDialog();
            
            if (result == true)
            {
                var viewmodel = (MembersViewModel) DataContext;
                viewmodel.AddMember(membersAddDialog.FirstName, membersAddDialog.LastName);
            }
        }

        private void Remove_Clicked(object sender, RoutedEventArgs e)
        {
            var viewmodel = (MembersViewModel) DataContext;
            if (Selected == null) return;

            bool result = MessageBox.Show(
                $"Do you really want to delete selected members?",
                "Remove member",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            ) == MessageBoxResult.Yes;

            if (result) {
                viewmodel.RemoveMember(Selected);
            }
        }
    }
}
