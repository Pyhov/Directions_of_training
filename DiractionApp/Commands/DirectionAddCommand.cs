using DiractionApp.ViewModels;
using Directions_of_training.BLL;
using Directions_of_training.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DiractionApp.Commands
{
    public class DirectionAddCommand : ICommand
    {


        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter != null)
            {
                int id = (parameter as DirectionViewModel).Id;
                var diraction = Env.Current.Catalog.Items.FirstOrDefault(x => x.Id == id);

                if (diraction != null)
                {
                    Env.Current.Cart.Add(diraction);
                }
            }

        }
    }
}
