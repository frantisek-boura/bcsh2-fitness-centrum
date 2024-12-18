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
    public partial class CreateUserDialog : Window
    {

        public string? Login { get; private set; }
        public string? Password { get; private set; }


        public CreateUserDialog()
        {
            InitializeComponent();
        }

        private void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            Login = loginTextBox.Text;
            Password = passwordTextBox.Password;
            
            if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show(
                $"Empty Login or Password",
                "Invalid input",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            } else
            {
                DialogResult = true;
            }
        }

        private void Cancel_Clicked(object sender, RoutedEventArgs e)
        {
            Login = null;
            Password = null;
            DialogResult = false;
        }
    }
}
