using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp
{
    internal class Lesson
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public DateTime HappeningOn { get; set; }

        public int LessonTypeId { get; set; }
        public LessonType LessonType { get; set; } = null!;

        public ICollection<Reservation> Reservations { get; } = new List<Reservation>();

    }
}
