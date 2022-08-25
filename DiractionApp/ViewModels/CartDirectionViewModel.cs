using DiractionApp.Commands;
using Directions_of_training.BLL.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiractionApp.ViewModels
{
    public class CartDirectionViewModel : DirectionViewModel
    {
        DirectionPrioretyChangeCommand propertyChange;
        ObservableCollection<CartProfileViewModel> profiles;
      
        public CartDirectionViewModel(DirectionModel diraction) 
        {
            base.diraction = diraction;
           
            FillProfiles();
        }
        public new void FillProfiles()
        {
            profiles = profiles ?? new();
            profiles.Clear();
            diraction.Profiles.ForEach(p => profiles.Add(new (p)));
        }
        public new ObservableCollection<CartProfileViewModel> Profiles =>profiles;
        public DirectionPrioretyChangeCommand DirectionPrioretyChangeCommand
        {
            get
            {
                propertyChange = propertyChange ?? new (this);
                return propertyChange;
            }
        }
    }
}
