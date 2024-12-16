using FitnessApp.Model;
using Microsoft.EntityFrameworkCore;
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
                var members = context.Members.ToList();
                var lessons = context.Lessons.Include(l => l.Reservations).ToList();
                var availableLessons = new List<Lesson>();
                foreach (var lesson in lessons)
                {
                    int currentCount = context.Reservations.Include(r => r.Lesson).Where(r => r.Lesson.Id == lesson.Id).Count();
                    if (currentCount < lesson.Capacity)
                    {
                        availableLessons.Add(lesson);
                    }
                }
                memberComboBox.ItemsSource = members;
                memberComboBox.SelectedIndex = 0;
                lessonComboBox.ItemsSource = availableLessons;
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
