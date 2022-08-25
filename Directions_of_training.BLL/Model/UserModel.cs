using Directions_of_training.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directions_of_training.BLL.Model
{
    public class UserModel
    {
        User user;    
        public UserModel(User user)
        {
            this.user = user;
        }
        public int Id => user.Id;
        public string Name => user.Name;
       
    }
}
