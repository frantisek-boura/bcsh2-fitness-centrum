using FitnessApp.Model;
using FitnessApp.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Printing.IndexedProperties;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FitnessApp.ViewModel
{

    public class ReservationsViewModel
    {

        public ObservableCollection<Reservation> Reservations { get; set; }
        private ActiveFilters activeFilters;

        public ReservationsViewModel()
        {
            using (var context = new FitnessAppContext())
            {
            }
            var reservations = Init();
            Reservations = new ObservableCollection<Reservation>(reservations);
            Reservations.CollectionChanged += Reservations_CollectionChanged;
            activeFilters = new ActiveFilters
            {
                FirstName = null,
                LastName = null,
                Type = null,
                CreatedOn = null
            };
        }

        internal List<Reservation> Init()
        {
            using (var context = new FitnessAppContext())
            {
                var reservations = context.Reservations
                    .Include(r => r.Member)
                    .Include(r => r.Lesson)
                    .ToList();
                return reservations;
            }
        }

        private void Reservations_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            using (var context = new FitnessAppContext())
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add) {
                    foreach (Reservation reservation in e.NewItems)
                    {
                        context.Reservations.Add(reservation);
                    }
                }
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                {
                    foreach (Reservation reservation in e.OldItems)
                    {
                        context.Reservations.Remove(reservation);
                    }
                }
                context.SaveChanges();
            }
        }

        internal void EditReservation(Reservation reservation, Member member, Lesson lesson)
        {
            var existing = Reservations.FirstOrDefault(x => x.Id == reservation.Id);
            var newReservation = new Reservation
            {
                MemberId = member.Id,
                LessonId = lesson.Id,
                CreatedOn = existing.CreatedOn,
            };

            Reservations.Remove(existing);
            Reservations.Add(newReservation);
        }

        internal void AddReservation(Member member, Lesson lesson, DateTime createdOn)
        {
            var reservation = new Reservation
            {
                MemberId = member.Id,
                LessonId = lesson.Id,
                CreatedOn = createdOn
            };

            Reservations.Add(reservation);
        }

        internal void RemoveReservation(Reservation reservation)
        {
            Reservations.Remove(reservation);
        }

        internal void ResetFilter()
        {
            activeFilters = new ActiveFilters
            {
                FirstName = null,
                LastName = null,
                Type = null,
                CreatedOn = null
            };
            RefreshGrid();
        }

        internal void FilterReservations()
        {
            List<Reservation> reservations = Init();
            Reservations.CollectionChanged -= Reservations_CollectionChanged;
            List<Reservation> filteredReservations = reservations.ToList();

            if (activeFilters.FirstName != null)
            {
                filteredReservations = filteredReservations.Where(r => r.Member.FirstName.Equals(activeFilters.FirstName, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (activeFilters.LastName != null)
            {
                filteredReservations = filteredReservations.Where(r => r.Member.LastName.Equals(activeFilters.LastName, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (activeFilters.Type != null)
            {
                filteredReservations = filteredReservations.Where(r => r.Lesson.Type.Equals(activeFilters.Type, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (activeFilters.CreatedOn != null)
            {
                filteredReservations = filteredReservations.Where(r => r.CreatedOn.Date == activeFilters.CreatedOn.Value.Date).ToList();
            }

            Reservations.Clear();
            foreach (var item in filteredReservations)
            {
                Reservations.Add(item);
            }
            Reservations.CollectionChanged += Reservations_CollectionChanged;
        }

        internal void ApplyFilter(string firstName, string lastName, string lessonType, DateTime? createdOn)
        {
            var filters = new ActiveFilters();

            if (!string.IsNullOrWhiteSpace(firstName))
            {
                filters.FirstName = firstName;
            }
            if (!string.IsNullOrWhiteSpace(lastName))
            {
                filters.LastName = lastName;
            }
            if (!string.IsNullOrWhiteSpace(lessonType))
            {
                filters.Type = lessonType;
            }
            if (createdOn.HasValue)
            {
                filters.CreatedOn = createdOn;
            }
            activeFilters = filters;

            FilterReservations();
        }

        internal void RefreshGrid()
        {
            FilterReservations();
        }
    }
}
