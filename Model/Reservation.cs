using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Model
{
    public class Reservation 
    {

        private int _memberId;
        private int _lessonId;

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
