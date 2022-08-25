using DiractionApp.Commands;
using Directions_of_training.BLL;
using Directions_of_training.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiractionApp.ViewModels
{
    public class CartProfileViewModel : ProfileViewModel
    {
        ProfilePrioretyChangeCommand propertyChange;
        int index;
        public CartProfileViewModel(ProfileModel profile) : base(profile)
        {
           
        }
        

        public ProfilePrioretyChangeCommand ProfilePrioretyChangeCommand
        {
            get
            {
                propertyChange = propertyChange ?? new(this);
                return propertyChange;
            }
        }
    }
}
