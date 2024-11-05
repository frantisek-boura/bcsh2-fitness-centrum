using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessApp
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string PasswordMD5 { get; set; }
    }
}
