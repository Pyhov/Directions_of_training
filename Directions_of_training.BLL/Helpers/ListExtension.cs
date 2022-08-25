using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directions_of_training.BLL.Helpers
{
    public static class ListExtension
    {
        public static bool Swap<T>(this IList<T> list, int IndexA, int IndexB )
        {
            var inRangeA = 0 <= IndexA && IndexA <= list.Count - 1;
            var inRangeB = 0 <= IndexB && IndexB <= list.Count - 1;
            if (inRangeA && inRangeB)
            {
              
                var temp = list[IndexA];
                list[IndexA]= list[IndexB];
                list[IndexB]= temp;
                return true;
            }
            return false;
        }
    }
}
