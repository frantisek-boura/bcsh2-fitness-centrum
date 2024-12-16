using FitnessApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
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
    public partial class ReservationsEditDialog : Window
    {

        private Member originalM;
        private Lesson originalL;
        public Member? Member { get; private set; }
        public Lesson? Lesson { get; private set; }

        private int FindMemberIndex(Member m, List<Member> list)
        {
            int count = 0;
            foreach (Member item in list)
            {
                if (item.Id == m.Id)
                {
                    return count;
                }
                count++;
            }
            return -1;
        }

        private int FindLessonIndex(Lesson l, List<Lesson> list)
        {
            int count = 0;
            foreach (Lesson item in list)
            {
                if (item.Id == l.Id)
                {
                    return count;
                }
                count++;
            }
            return -1;
        }

        public ReservationsEditDialog(Member m, Lesson l)
        {
            InitializeComponent();
            originalM = m;
            originalL = l;
            using (var context = new FitnessAppContext())
            {
                List<Member> mList = context.Members.ToList();
                int mIndex = FindMemberIndex(m, mList); // mList.IndexOf(m) vraci -1, proto vlastni implementace
                memberComboBox.ItemsSource = mList;
                memberComboBox.SelectedIndex = mIndex;

                List<Lesson> lList = context.Lessons.Include(l => l.Reservations).ToList();
                List<Lesson> availableLessons = new List<Lesson>();
                foreach (var lesson in lList)
                {
                    if (lesson.Id == l.Id) continue;
                    int currentCount = context.Reservations.Include(r => r.Lesson).Where(r => r.Lesson.Id == lesson.Id).Count();
                    if (currentCount < lesson.Capacity)
                    {
                        availableLessons.Add(lesson);
                    }
                }
                availableLessons.Add(l);
                int lIndex = FindLessonIndex(l, availableLessons);
                lessonComboBox.ItemsSource = availableLessons;
                lessonComboBox.SelectedIndex = lIndex;
            }
        }

        private void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            Member = memberComboBox.SelectedItem as Member;
            Lesson = lessonComboBox.SelectedItem as Lesson;
            DialogResult = true;
        }

        private void Cancel_Clicked(object sender, RoutedEventArgs e)
        {
            Member = null;
            Lesson = null;
            DialogResult = false;
        }
    }
}
