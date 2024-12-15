using FitnessApp.Model;
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
    public partial class ReservationsAddDialog : Window
    {
        private Member? member;

        public Member? Member { get; private set; }
        public Lesson? Lesson { get; private set; }
        public DateTime? CreatedOn { get; private set; }


        public ReservationsAddDialog()
        {
            InitializeComponent();
            
            using (var context = new FitnessAppContext())
            {
                memberComboBox.ItemsSource = context.Members.ToList();
                memberComboBox.SelectedIndex = 0;
                lessonComboBox.ItemsSource = context.Lessons.ToList();
                lessonComboBox.SelectedIndex = 0;
            }
        }

        private void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            Member = memberComboBox.SelectedItem as Member;
            Lesson = lessonComboBox.SelectedItem as Lesson;
            CreatedOn = DateTime.Now;
            DialogResult = true;
        }

        private void Cancel_Clicked(object sender, RoutedEventArgs e)
        {
            Member = null;
            Lesson = null;
            CreatedOn = null;
            DialogResult = false;
        }
    }
}
