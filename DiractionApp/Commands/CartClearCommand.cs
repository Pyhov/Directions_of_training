using Directions_of_training.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DiractionApp.Commands
{
    public class CartClearCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (Env.Current.UserManager.UserSelected != null)
            {
                var cart = Env.Current.Cart;
                cart.Clear();
            }
        }
    }
}
