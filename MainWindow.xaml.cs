using FitnessApp.Model;
using FitnessApp.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
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
            InitializeComponent();
            logInButton.IsEnabled = true;
            membersButton.IsEnabled = false;
            lessonsButton.IsEnabled = false;
            reservationsButton.IsEnabled = false;
            logOutButton.IsEnabled = false;
            DataContext = new DefaultViewModel();

            // admin ucet
            using (var context = new FitnessAppContext())
            {
                if (context.Users.FirstOrDefault(u => u.Login == "Admin") == null)
                {
                    // Admin, Heslo123
                    var user = new User { Login = "Admin", PasswordBcrypt = "$2a$04$Ny8ejTXHidAhp3NAudfpvuABuTsk/aLbV.606iaItWMzPJW9rFS1." };
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
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

        private async void LogInButton_Clicked(object sender, RoutedEventArgs e)
        {
            var logInViewModel = await Task.Run(() =>
            {
                return new LogInViewModel();
            });

            logInViewModel.LoggedInChanged += LogInViewModel_PropertyChanged;
            DataContext = logInViewModel;
        }

        private void LogInViewModel_PropertyChanged(bool isLoggedIn)
        {
            Dispatcher.Invoke(() =>
            {
                UpdateButtonStates(isLoggedIn);
            });
        }

        private async void UpdateButtonStates(bool isLoggedIn)
        {
            logInButton.IsEnabled = !isLoggedIn;
            membersButton.IsEnabled = isLoggedIn;
            lessonsButton.IsEnabled = isLoggedIn;
            reservationsButton.IsEnabled = isLoggedIn;
            logOutButton.IsEnabled = isLoggedIn;

            DataContext = await Task.Run(() =>
            {
                return new DefaultViewModel();
            });
        }

        private void LogOutButton_Clicked(object sender, RoutedEventArgs e)
        {
            UpdateButtonStates(false);
        }
    }
}