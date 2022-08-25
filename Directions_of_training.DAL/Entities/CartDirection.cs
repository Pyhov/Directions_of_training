using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directions_of_training.DAL.Entities
{
    public class CartDirection
    {


        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int Priority { get; set; }
        public int DirectionId { get; set; }
        public Direction Direction { get; set; }
    }
}
