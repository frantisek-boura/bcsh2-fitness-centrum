﻿using System;
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
    public partial class MembersAddDialog : Window
    {

        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }


        public MembersAddDialog()
        {
            InitializeComponent();
        }

        private void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            FirstName = firstNameTextBox.Text;
            LastName = lastNameTextBox.Text;
            
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
            {
                MessageBox.Show(
                $"Empty First Name or Last Name",
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
            FirstName = null;
            LastName = null;
            DialogResult = false;
        }
    }
}
