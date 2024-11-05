using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.ViewModel
{
    public class MembersViewModel
    {

        public IEnumerable<Member> Members;

        public MembersViewModel(DbSet<Member> dbset)
        {
            Members = dbset;
        }

    }
}
