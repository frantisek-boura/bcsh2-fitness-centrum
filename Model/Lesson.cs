using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Model
{
    public class Lesson : INotifyPropertyChanged, IComparable
    {

        private string _name;
        private int _capacity;
        private DateTime _date;
        private string _type;

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        [Required]
        public int Capacity 
        {
            get => _capacity;
            set
            {
                if (_capacity != value)
                {
                    _capacity = value;
                    OnPropertyChanged();
                }
            }
        }

        [Required]
        public DateTime Date 
        {
            get => _date;
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged();
                }
            }
        }

        [Required]
        public string Type 
        {
            get => _type;
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICollection<Reservation> Reservations { get; } = new List<Reservation>();

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string? ToString()
        {
            return $"{_name} ({_type}) {Reservations.Count()}/{_capacity} {_date.ToString("MM-dd-yyyy")}";
        }

        public int CompareTo(object? other)
        {
            if (other == null) return 1;

            return string.Compare(this.Name, (other as Lesson).Name, StringComparison.OrdinalIgnoreCase);
        }
    }
}
