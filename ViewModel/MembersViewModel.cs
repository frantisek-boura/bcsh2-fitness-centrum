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
    public class MembersViewModel
    {

        public ObservableCollection<Member> Members { get; set; }

        public MembersViewModel()
        {
            using (var context = new FitnessAppContext())
            {
                var members = context.Members.Include(m => m.Reservations).ToList();
                Members = new ObservableCollection<Member>(members);
                foreach (var member in Members)
                {
                    member.PropertyChanged += Member_PropertyChanged;
                }
                Members.CollectionChanged += Members_CollectionChanged;
            }
        }

        private void Member_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender is Member member)
            {
                using (var context = new FitnessAppContext())
                {
                    context.Members.Update(member);
                    context.SaveChanges();
                }
            }
        }

        private void Members_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            using (var context = new FitnessAppContext())
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add) {
                    foreach (Member member in e.NewItems)
                    {
                        context.Members.Add(member);
                        member.PropertyChanged += Member_PropertyChanged;
                    }
                }
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                {
                    foreach (Member member in e.OldItems)
                    {
                        context.Members.Remove(member);
                        member.PropertyChanged -= Member_PropertyChanged;
                    }
                }
                context.SaveChanges();
            }
        }

        internal void AddMember(string firstName, string lastName)
        {
            var member = new Member
            {
                FirstName = firstName,
                LastName = lastName,
                RegisteredOn = DateTime.Now
            };

            Members.Add(member);
        }

        internal void RemoveMember(Member member)
        {
            Members.Remove(member);
        }
    }
}
