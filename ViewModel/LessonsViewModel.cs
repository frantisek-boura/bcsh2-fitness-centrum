using FitnessApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace FitnessApp.ViewModel
{
    public class LessonsViewModel
    {

        public ObservableCollection<Lesson> Lessons { get; set; }

        public LessonsViewModel()
        {
            using (var context = new FitnessAppContext())
            {
                var lessons = context.Lessons.Include(l => l.Reservations).ToList();
                Lessons = new ObservableCollection<Lesson>(lessons);
                foreach (var lesson in Lessons)
                {
                    lesson.PropertyChanged += Lesson_PropertyChanged;
                }
                Lessons.CollectionChanged += Lessons_CollectionChanged;
            }
        }

        private void Lesson_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender is Lesson lesson)
            {
                using (var context = new FitnessAppContext())
                {
                    context.Lessons.Update(lesson);
                    context.SaveChanges();
                }
            }
        }

        private void Lessons_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            using (var context = new FitnessAppContext())
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (Lesson lesson in e.NewItems)
                    {
                        context.Lessons.Add(lesson);
                        lesson.PropertyChanged += Lesson_PropertyChanged;
                    }
                }
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                {
                    foreach (Lesson lesson in e.OldItems)
                    {
                        context.Lessons.Remove(lesson);
                        lesson.PropertyChanged -= Lesson_PropertyChanged;
                    }
                }
                context.SaveChanges();
            }
        }

        internal void AddLesson(string name, string type, int capacity, DateTime date)
        {
            var lesson = new Lesson
            {
                Name = name,
                Capacity = capacity,
                Date = date,
                Type = type
            };

            Lessons.Add(lesson);
        }

        internal void RemoveLesson(Lesson lesson)
        {
            Lessons.Remove(lesson);
        }
    }
}
