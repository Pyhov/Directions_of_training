using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directions_of_training.BLL.Model
{
    public class ProfileModel : ICloneable
    {
        public ProfileModel(int id, string name, string faculty)
        {
            Id = id;
            Name = name;
            Faculty = faculty;
        }
        public int Id { get; }
        public string Name { get; }
        public string Faculty { get; }

        public object Clone()
        {
            return new ProfileModel(Id, Name, Faculty);
        }
    }
}
