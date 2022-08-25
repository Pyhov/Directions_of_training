using DiractionApp.Commands;
using Directions_of_training.BLL;
using Directions_of_training.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DiractionApp.ViewModels
{
    internal class CatalogViewModel : INotifyPropertyChanged
    {
        ObservableCollection<DirectionViewModel> directions = new();
        DirectionViewModel directionSelect;
        DirectionAddCommand directionAddCommand;
        public CatalogViewModel()
        {
            Env.Current.Catalog.Items.ToList().ForEach(o => {
                var directionVM = new DirectionViewModel(o);
                directions.Add(directionVM);
                directionVM.Position = directions.Count();
                }) ;
        }

        public DirectionViewModel DirectionSelect
        {
            get { return directionSelect; }
            set
            {
                directionSelect = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DirectionSelect"));               
            }
        }
        public DirectionAddCommand DirectionAddCommand
        {
            get
            {
                directionAddCommand = directionAddCommand ?? new DirectionAddCommand();
                return directionAddCommand;
            }
        }

        public ObservableCollection<DirectionViewModel> Diractions=>directions;

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
