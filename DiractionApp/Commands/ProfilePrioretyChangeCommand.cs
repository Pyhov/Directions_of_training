using DiractionApp.ViewModels;
using Directions_of_training.BLL;
using Directions_of_training.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DiractionApp.Commands
{
    public class ProfilePrioretyChangeCommand : ICommand
    {
        CartProfileViewModel profileVM;

        public ProfilePrioretyChangeCommand(CartProfileViewModel profileVM)
        {
            this.profileVM = profileVM;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
           
            var Priority = (PriorityEnum)parameter;
            var profile = Env.Current.Cart.Directions.SelectMany(x => x.Profiles).FirstOrDefault(p=>p.Id==profileVM.Id);
            if (profile != null)
            {
               
                Env.Current.Cart.ProfileChangePriority(profile, Priority);
            }
        }
    }
}
