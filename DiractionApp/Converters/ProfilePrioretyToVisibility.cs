using DiractionApp.ViewModels;
using Directions_of_training.BLL;
using Directions_of_training.BLL.Model;
using Directions_of_training.DAL.Entities;
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
    public class ProfilePrioretyToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           
            if (value != null && value is int)
            {
                int id = (int)value;
                var dir = Env.Current.Cart.Directions.First(d => d.Profiles.Any(p => p.Id ==id));
                var profile = dir.Profiles.FirstOrDefault(p => p.Id == id);
                int index = dir.Profiles.IndexOf(profile);
                var priorety = (PriorityEnum)parameter;
                if ( (priorety ==PriorityEnum.Downgrade && index < dir.Profiles.Count() - 1) || ( priorety == PriorityEnum.Increase && index>0))
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
