using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directions_of_training.DAL.Entities
{
    public class User
    {
        public User(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<CartDirection> CartDirections { get; set; } = new();
        public List<CartProfile> CartProfiles { get; set; } = new();

    }
}
