﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp
{
    internal class LessonType
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Lesson> Lessons { get; } = new List<Lesson>();

    }
}
