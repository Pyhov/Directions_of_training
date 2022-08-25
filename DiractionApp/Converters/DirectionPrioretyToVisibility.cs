using Directions_of_training.BLL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace DiractionApp.Converters
{
    public class DirectionPrioretyToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is int)
            {
                int id = (int)value;
                var dir = Env.Current.Cart.Directions.First(d =>d.Id ==id);
                int index = Env.Current.Cart.Directions.IndexOf(dir);
                var priorety = (PriorityEnum)parameter;
                if ((priorety == PriorityEnum.Downgrade && index < Env.Current.Cart.Directions.Count() - 1) || (priorety == PriorityEnum.Increase && index > 0))
                {
                    return Visibility.Visible;
                }


            }
            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
