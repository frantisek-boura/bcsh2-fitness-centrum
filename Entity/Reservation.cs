using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp
{
    public class Reservation
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; } = null!;

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; } = null!;
    }
}
