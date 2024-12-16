using FitnessApp.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FitnessApp.View
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class LogInView : UserControl
    {
        public LogInView()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var viewmodel = (LogInViewModel) DataContext;
            if (!viewmodel.LogIn(loginTextBox.Text, passwordTextBox.Password))
            {
                MessageBox.Show($"Incorrect login or password", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
