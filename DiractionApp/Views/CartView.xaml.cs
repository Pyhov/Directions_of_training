using DiractionApp.Commands;
using DiractionApp.ViewModels;
using Directions_of_training.BLL;
using Directions_of_training.BLL.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiractionApp.Views
{
    /// <summary>
    /// Логика взаимодействия для CartView.xaml
    /// </summary>
    public partial class CartView : UserControl, INotifyPropertyChanged
    {
        CartSaveCommand cartSaveCommand;
        CartClearCommand cartClearCommand;
        DirectionRemoveCommand directionRemoveCommand;
        ObservableCollection<CartDirectionViewModel> directions = new();
        CartDirectionViewModel directionSelect;

        public event PropertyChangedEventHandler? PropertyChanged;

        public CartView()
        {
            InitializeComponent();
            this.DataContext = this;
            if (Env.Current.UserManager.UserSelected != null)
            {

                Cart cart = Env.Current.Cart;
                cart.DirectionAdded += Cart_DirectionAdded;
                cart.CartCleared += Cart_CartCleared;
                cart.DirectionRemoved += Cart_DirectionRemoved;
                cart.DirectionSwaped += Cart_DirectionSwaped;
                cart.ProfileSwaped += Cart_ProfileSwaped;
                fillDiractionList(cart);

            }
        }

        private void Cart_ProfileSwaped(ProfileModel profile, DirectionModel direction, PriorityEnum priority)
        {
            var dir = directions.FirstOrDefault(d => d.Id == direction.Id);
            if (dir != null)
            {
                dir.FillProfiles();
            }
        }

        private void Cart_DirectionSwaped(DirectionModel direction, PriorityEnum priority)
        {
            fillDiractionList(Env.Current.Cart);
        }

        private void fillDiractionList(Cart cart)
        {
            Directions.Clear();
          
            cart.Directions.ToList().ForEach(d =>
            {
                var directionVM = new CartDirectionViewModel(d);
                directions.Add(directionVM);
                directionVM.Position = directions.Count();
            });
        }

        private void Cart_DirectionRemoved(DirectionModel Direction)
        {
            fillDiractionList(Env.Current.Cart);
        }

        private void Cart_CartCleared()
        {
            Directions.Clear();
        }

        private void Cart_DirectionAdded(DirectionModel Direction)
        {
            fillDiractionList(Env.Current.Cart);

        }
        private void Button_GotMouseCapture(object sender, MouseEventArgs e)
        {
            object buttonDataContext = (sender as Button).DataContext;
            var lbi = CartItemsView.ItemContainerGenerator.ContainerFromItem(buttonDataContext);

            (lbi as ListBoxItem).IsSelected = true;
        }



        public CartDirectionViewModel DirectionSelect
        {
            get { return directionSelect; }
            set
            {
                directionSelect = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DirectionSelect"));
            }
        }
        public ObservableCollection<CartDirectionViewModel> Directions => directions;
        public CartSaveCommand CartSaveCommand
        {
            get
            {
                cartSaveCommand = cartSaveCommand ?? new CartSaveCommand();
                return cartSaveCommand;
            }
        }

        public CartClearCommand CartClearCommand
        {
            get
            {
                cartClearCommand = cartClearCommand ?? new CartClearCommand();
                return cartClearCommand;
            }
        }

        public DirectionRemoveCommand DirectionRemoveCommand
        {
            get
            {
                directionRemoveCommand = directionRemoveCommand ?? new DirectionRemoveCommand();
                return directionRemoveCommand;
            }
        }
    }
}
