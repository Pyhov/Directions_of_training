using DiractionApp.ViewModels;
using Directions_of_training.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DiractionApp.Commands
{
    public class DirectionPrioretyChangeCommand : ICommand
    {
        private CartDirectionViewModel dirVM;

        public DirectionPrioretyChangeCommand(CartDirectionViewModel cartDirectionViewModel)
        {
            this.dirVM = cartDirectionViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {

            var Priority = (PriorityEnum)parameter;
            var direction = Env.Current.Cart.Directions.FirstOrDefault(x => x.Id == dirVM.Id);
            if (direction != null)
            {
                Env.Current.Cart.DirectionChangePriority(direction, Priority);
            }

        }
    }
}
