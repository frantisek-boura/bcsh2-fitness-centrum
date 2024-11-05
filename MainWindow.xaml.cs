using FitnessApp.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FitnessApp
{
    public partial class MainWindow : Window
    {

        public MainWindow() 
        { 
            
        }

        private async void MembersButton_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = await Task.Run(() =>
            {
                return new MembersViewModel();
            });
        }

        private async void LessonsButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = await Task.Run(() =>
            {
                return new LessonsViewModel();
            });
        }

        private async void ReservationsButton_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = await Task.Run(() =>
            {
                return new ReservationsViewModel();
            });
        }

        private async void UserProfileButton_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = await Task.Run(() =>
            {
                return new UserViewModel();
            });
        }
    }
}