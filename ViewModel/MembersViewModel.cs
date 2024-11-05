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
        public Member? Selected { get; set; }

        public MembersViewModel()
        {
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            try
            {
                var ctx = new FitnessAppContext();
                var members = await ctx.Members.Include(m => m.Reservations).ToListAsync();
                Members = new ObservableCollection<Member>(members);
            } catch
            {
                Trace.WriteLine("Chyba DB");
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

            using (var ctx = new FitnessAppContext())
            {
                var memberEntry = ctx.Members.Add(member);
                ctx.SaveChanges();

                var addedMember = memberEntry.Entity;

                Members.Add(addedMember);
            }

        }

        internal void RemoveMember(Member member)
        {
            using (var ctx = new FitnessAppContext())
            {
                var memberEntry = ctx.Members.Remove(member);
                if (memberEntry == null) return;

                var removedMember = memberEntry.Entity;
                ctx.SaveChanges();

                Members.Remove(removedMember);
            }
        }

        internal void EditMember(Member member, string firstName, string lastName)
        {
            using (var ctx = new FitnessAppContext())
            {
                var editedMember = ctx.Members.FirstOrDefault(m => m.Id == member.Id);

                if (editedMember == null) return;

                editedMember.FirstName = firstName;
                editedMember.LastName = lastName;
                ctx.SaveChanges();

                Members.Remove(member);
                Members.Add(editedMember);
            }
        }
    }
}
