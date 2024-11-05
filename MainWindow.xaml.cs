using FitnessApp.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FitnessApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public FitnessAppContext dbCtx { get; init; }

        public MainWindow()
        {
            dbCtx = new FitnessAppContext();


                dbCtx.Add<User>(new User { Login = "Admin", PasswordMD5 = "MD5Hash" });

                dbCtx.Add<Member>(new Member { FirstName = "Frantisek", LastName = "Boura", RegisteredOn = DateTime.Now});
                dbCtx.Add<Member>(new Member { FirstName = "Jakub", LastName = "Lemberk", RegisteredOn = DateTime.Now});
                dbCtx.Add<Member>(new Member { FirstName = "Michal", LastName = "Pazderka", RegisteredOn = DateTime.Now});
                dbCtx.Add<LessonType>(new LessonType { Name = "Kalistenika" }); 
                dbCtx.Add<LessonType>(new LessonType { Name = "Kardio" }); 
                dbCtx.SaveChanges();

                dbCtx.Add<Lesson>(new Lesson { Name = "Hodina Kalisteniky", Capacity = 20, LessonType = dbCtx.LessonTypes.Single(lt => lt.Name == "Kalistenika"), HappeningOn = new DateTime(2024, 11, 5, 18, 0, 0) });
                dbCtx.Add<Lesson>(new Lesson { Name = "TRX Cviceni", Capacity = 10, LessonType = dbCtx.LessonTypes.Single(lt => lt.Name == "Kalistenika"), HappeningOn = new DateTime(2024, 11, 6, 16, 0, 0) });
                dbCtx.Add<Lesson>(new Lesson { Name = "Svihadlo", Capacity = 30, LessonType = dbCtx.LessonTypes.Single(lt => lt.Name == "Kardio"), HappeningOn = new DateTime(2024, 11, 5, 14, 0, 0) });
                dbCtx.SaveChanges();

                dbCtx.Add<Reservation>(new Reservation { CreatedOn = DateTime.Now, Member = dbCtx.Members.Single(m => m.LastName == "Boura"), Lesson = dbCtx.Lessons.Single(l => l.Name == "Svihadlo")});
                dbCtx.Add<Reservation>(new Reservation { CreatedOn = DateTime.Now, Member = dbCtx.Members.Single(m => m.LastName == "Boura"), Lesson = dbCtx.Lessons.Single(l => l.Name == "TRX Cviceni")});
                dbCtx.Add<Reservation>(new Reservation { CreatedOn = DateTime.Now, Member = dbCtx.Members.Single(m => m.LastName == "Lemberk"), Lesson = dbCtx.Lessons.Single(l => l.Name == "Hodina Kalisteniky")});
                dbCtx.Add<Reservation>(new Reservation { CreatedOn = DateTime.Now, Member = dbCtx.Members.Single(m => m.LastName == "Pazderka"), Lesson = dbCtx.Lessons.Single(l => l.Name == "Hodina Kalisteniky")});
                dbCtx.SaveChanges();

                var hodinaKalisteniky = dbCtx.Lessons.Single(l => l.Name == "Hodina Kalisteniky");
                var trxCviceni = dbCtx.Lessons.Single(l => l.Name == "TRX Cviceni");
                var svihadlo = dbCtx.Lessons.Single(l => l.Name == "Svihadlo");
                Trace.WriteLine("Pocet rezervaci na hodine kalisteniky: " + hodinaKalisteniky.Reservations.Count());
                Trace.WriteLine("Pocet rezervaci na trxku: " + trxCviceni.Reservations.Count());
                Trace.WriteLine("Pocet rezervaci na svihadle: " + svihadlo.Reservations.Count());

                var frantisek = dbCtx.Members.Single(m => m.FirstName == "Frantisek");
                var jakub = dbCtx.Members.Single(m => m.FirstName == "Jakub");
                var michal = dbCtx.Members.Single(m => m.FirstName == "Michal");
                Trace.WriteLine("Pocet rezervaci Frantiska: " + frantisek.Reservations.Count());
                Trace.WriteLine("Pocet rezervaci Jakuba: " + jakub.Reservations.Count());
                Trace.WriteLine("Pocet rezervaci Michala: " + michal.Reservations.Count());

                string[] frantiskovyRezervace = (from r in frantisek.Reservations select r.Lesson.Name).ToArray<string>();
                foreach (var item in frantiskovyRezervace)
                {
                    Trace.WriteLine(item);
                }
        }

        private void MembersButton_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new MembersViewModel(dbCtx.Members);
        }

        private void LessonsButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new LessonsViewModel();
        }

        private void ReservationsButton_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new ReservationsViewModel();
        }

        private void UserProfileButton_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new UserViewModel();
        }
    }
}