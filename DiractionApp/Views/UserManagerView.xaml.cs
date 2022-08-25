using Directions_of_training.BLL;
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
using System.Windows.Shapes;


namespace DiractionApp.Views
{
    /// <summary>
    /// Логика взаимодействия для UserView.xaml
    /// </summary>
    public partial class UserManagerView : Window, INotifyPropertyChanged
    {
        string message;
        public UserManagerView()
        {
            InitializeComponent();
            DataContext = this;
           
        }

   

        public string UserNameAdd { get; set; }

        public string UserNameSelect { get; set; }        

        public string Message
        {
            get => message;
            private set
            {
                message = value;
              
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Message"));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Button_Click_ADD(object sender, RoutedEventArgs e)
        {
            
            var result = Env.Current.UserManager.CreateUser(UserNameAdd);
            Message = result ? "Новый пользователь добавлен" : "Ошибка добавления";
           

        }

        private void Button_Click_Select(object sender, RoutedEventArgs e)
        {
            var result = Env.Current.UserManager.UserSelect(UserNameSelect);
            Message = result ? "Пользователь выбран" : "Ошибка выбора";
        }
    }
}
