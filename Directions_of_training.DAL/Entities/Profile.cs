using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directions_of_training.DAL.Entities
{
    public class Profile
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }
        public int? DirectionId { get; set; }
      
        public Direction? Direction { get; set; }
    }
}
