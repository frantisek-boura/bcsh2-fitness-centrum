using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Model
{
    public class Member : INotifyPropertyChanged, IComparable
    {

        private string _firstName;
        private string _lastName;

        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged();
                }
            }
        }

        [Required]
        public string LastName 
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public ICollection<Reservation> Reservations { get; } = new List<Reservation>();

        public string FullName => $"{_firstName} {_lastName}";

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string? ToString()
        {
            return FullName;
        }

        public int CompareTo(object? other)
        {
            if (other == null) return 1;

            return string.Compare(this.LastName, (other as Member).LastName, StringComparison.OrdinalIgnoreCase);
        }
    }
}
