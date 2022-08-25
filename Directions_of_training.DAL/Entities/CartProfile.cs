using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directions_of_training.DAL.Entities
{
    public class CartProfile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int Priority { get; set; }
        public int? ProfileId { get; set; }
        public Profile? Profile { get; set; }
    }
}
