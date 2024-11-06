﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using FitnessApp.Model;

namespace FitnessApp.Converters
{
    [ValueConversion(typeof(ICollection<Reservation>), typeof(int))]
    public class MemberReservationsCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ICollection<Reservation> collection)
            {
                return collection.Count();
            }

            return -1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("ConvertBack is not implemented because it's not needed.");
        }
    }
}