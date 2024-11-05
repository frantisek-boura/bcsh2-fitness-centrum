using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FitnessApp
{
    public class FitnessAppContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonType> LessonTypes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public string DbPath { get; }

        public FitnessAppContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "fitness.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

    }
}
