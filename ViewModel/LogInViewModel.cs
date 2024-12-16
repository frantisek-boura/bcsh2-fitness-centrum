using FitnessApp.Model;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FitnessApp.ViewModel
{
    public class LogInViewModel 
    {

        private bool _loggedIn;
        public bool LoggedIn
        {
            get => _loggedIn;
            set
            {
                if (_loggedIn != value)
                {
                    _loggedIn = value;
                    OnLoggedInChanged();
                }
            }
        }

        public event Action<bool> LoggedInChanged;

        protected void OnLoggedInChanged() 
        {
            LoggedInChanged?.Invoke(_loggedIn);
        }

        internal bool LogIn(string login, string password)
        {
            using (var context = new FitnessAppContext())
            {
                User? user = context.Users.FirstOrDefault(u => u.Login == login);
                if (user == null)
                {
                    return false;
                }

                string userHash = user.PasswordBcrypt;
                if (!BCrypt.Net.BCrypt.Verify(password, userHash))
                {
                    return false;
                }

                LoggedIn = true;
                return true;
            }
        }
    }
}
