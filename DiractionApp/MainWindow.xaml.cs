using DiractionApp.ViewModels;
using DiractionApp.Views;
using Directions_of_training.BLL;
using Directions_of_training.BLL.Model;
using System;
using System.Collections.Generic;
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


namespace DiractionApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        UserModel userNameSelected;

        public MainWindow()
        {
            
            InitializeComponent();
            Env.Init();
            Env.Current.UserManager.UserChanged += UserManager_UserChanged;
            Catalog = new CatalogViewModel();
            this.CatalogView.DataContext = Catalog;
        }



        private void UserManager_UserChanged(UserModel? User)
        {
            
            if (User == null)
            {
                this.cartContent.Content = null;           
            }
            else
            {
                this.cartContent.Content = new CartView();
            }
        }
        
 

        CatalogViewModel Catalog;

        public event PropertyChangedEventHandler? PropertyChanged;
        
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var userView = new UserManagerView();
            userView.ShowDialog();
        }

        private void Button_GotMouseCapture(object sender, MouseEventArgs e)
        {
            object buttonDataContext = (sender as Button).DataContext;
            var lbi = CatalogView.ItemContainerGenerator.ContainerFromItem(buttonDataContext);
              
            (lbi as ListBoxItem).IsSelected = true;
        }
    }
}
