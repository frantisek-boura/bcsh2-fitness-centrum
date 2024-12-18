using FitnessApp.Model;
using FitnessApp.View;
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
            createUserButton.IsEnabled = true;
            DataContext = new DefaultViewModel(null);

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

        private void CreateUserButton_Clicked(object sender, RoutedEventArgs e)
        {
            var createUserDialog = new CreateUserDialog();
            createUserDialog.Owner = Window.GetWindow(this);
            createUserDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            bool? result = createUserDialog.ShowDialog();

            if (result == true)
            {
                string hash = BCrypt.Net.BCrypt.HashPassword(createUserDialog.Password);
                string login = createUserDialog.Login;
                using (var context = new FitnessAppContext())
                {
                    if (context.Users.FirstOrDefault(u => u.Login == login) != null)
                    {
                        MessageBox.Show(
                            $"User with login {login} already exists",
                            "Remove member",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error
                        );
                        return;
                    }

                    var user = new User { Login = login, PasswordBcrypt = hash };
                    context.Users.Add(user);
                    context.SaveChanges();
                    MessageBox.Show(
                        $"User with login {login} added successfully",
                        "Remove member",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information
                    );
                }
            }
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

        private void LogInViewModel_PropertyChanged(bool isLoggedIn, string login)
        {
            Dispatcher.Invoke(() =>
            {
                UpdateButtonStates(isLoggedIn, login);
            });
        }

        private async void UpdateButtonStates(bool isLoggedIn, string? login)
        {
            logInButton.IsEnabled = !isLoggedIn;
            membersButton.IsEnabled = isLoggedIn;
            lessonsButton.IsEnabled = isLoggedIn;
            reservationsButton.IsEnabled = isLoggedIn;
            logOutButton.IsEnabled = isLoggedIn;

            DataContext = await Task.Run(() =>
            {
                return new DefaultViewModel(login);
            });
        }

        private void LogOutButton_Clicked(object sender, RoutedEventArgs e)
        {
            UpdateButtonStates(false, null);
        }
    }
}