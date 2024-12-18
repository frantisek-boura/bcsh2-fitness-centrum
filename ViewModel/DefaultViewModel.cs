using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FitnessApp.ViewModel
{
    public class DefaultViewModel 
    {

        public string? Login { get; set; }
        public string UILogin
        {
            get
            {
                if (Login == null) {
                     return "";
                }
                return $"Logged in as {Login}";
            }
        }

        public DefaultViewModel(string? login) 
        {
            Login = login;
        }
    }
}
