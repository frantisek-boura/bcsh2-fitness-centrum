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
        public MainWindow()
        {
            /*
            using (var ctx = new FitnessAppContext())
            {
                ctx.Add<User>(new User { Login = "Admin", PasswordMD5 = "MD5Hash" });

                ctx.Add<Member>(new Member { FirstName = "Frantisek", LastName = "Boura", RegisteredOn = DateTime.Now});
                ctx.Add<Member>(new Member { FirstName = "Jakub", LastName = "Lemberk", RegisteredOn = DateTime.Now});
                ctx.Add<Member>(new Member { FirstName = "Michal", LastName = "Pazderka", RegisteredOn = DateTime.Now});
                ctx.Add<LessonType>(new LessonType { Name = "Kalistenika" }); 
                ctx.Add<LessonType>(new LessonType { Name = "Kardio" }); 
                ctx.SaveChanges();

                ctx.Add<Lesson>(new Lesson { Name = "Hodina Kalisteniky", Capacity = 20, LessonType = ctx.LessonTypes.Single(lt => lt.Name == "Kalistenika"), HappeningOn = new DateTime(2024, 11, 5, 18, 0, 0) });
                ctx.Add<Lesson>(new Lesson { Name = "TRX Cviceni", Capacity = 10, LessonType = ctx.LessonTypes.Single(lt => lt.Name == "Kalistenika"), HappeningOn = new DateTime(2024, 11, 6, 16, 0, 0) });
                ctx.Add<Lesson>(new Lesson { Name = "Svihadlo", Capacity = 30, LessonType = ctx.LessonTypes.Single(lt => lt.Name == "Kardio"), HappeningOn = new DateTime(2024, 11, 5, 14, 0, 0) });
                ctx.SaveChanges();

                ctx.Add<Reservation>(new Reservation { CreatedOn = DateTime.Now, Member = ctx.Members.Single(m => m.LastName == "Boura"), Lesson = ctx.Lessons.Single(l => l.Name == "Svihadlo")});
                ctx.Add<Reservation>(new Reservation { CreatedOn = DateTime.Now, Member = ctx.Members.Single(m => m.LastName == "Boura"), Lesson = ctx.Lessons.Single(l => l.Name == "TRX Cviceni")});
                ctx.Add<Reservation>(new Reservation { CreatedOn = DateTime.Now, Member = ctx.Members.Single(m => m.LastName == "Lemberk"), Lesson = ctx.Lessons.Single(l => l.Name == "Hodina Kalisteniky")});
                ctx.Add<Reservation>(new Reservation { CreatedOn = DateTime.Now, Member = ctx.Members.Single(m => m.LastName == "Pazderka"), Lesson = ctx.Lessons.Single(l => l.Name == "Hodina Kalisteniky")});
                ctx.SaveChanges();

                var hodinaKalisteniky = ctx.Lessons.Single(l => l.Name == "Hodina Kalisteniky");
                var trxCviceni = ctx.Lessons.Single(l => l.Name == "TRX Cviceni");
                var svihadlo = ctx.Lessons.Single(l => l.Name == "Svihadlo");
                Trace.WriteLine("Pocet rezervaci na hodine kalisteniky: " + hodinaKalisteniky.Reservations.Count());
                Trace.WriteLine("Pocet rezervaci na trxku: " + trxCviceni.Reservations.Count());
                Trace.WriteLine("Pocet rezervaci na svihadle: " + svihadlo.Reservations.Count());

                var frantisek = ctx.Members.Single(m => m.FirstName == "Frantisek");
                var jakub = ctx.Members.Single(m => m.FirstName == "Jakub");
                var michal = ctx.Members.Single(m => m.FirstName == "Michal");
                Trace.WriteLine("Pocet rezervaci Frantiska: " + frantisek.Reservations.Count());
                Trace.WriteLine("Pocet rezervaci Jakuba: " + jakub.Reservations.Count());
                Trace.WriteLine("Pocet rezervaci Michala: " + michal.Reservations.Count());

                string[] frantiskovyRezervace = (from r in frantisek.Reservations select r.Lesson.Name).ToArray<string>();
                foreach (var item in frantiskovyRezervace)
                {
                    Trace.WriteLine(item);
                }
            }
            */
        }
    }
}