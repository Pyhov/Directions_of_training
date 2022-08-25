using Directions_of_training.BLL.Model;
using Directions_of_training.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Directions_of_training.BLL
{
    public class UserManager
    {
        UserModel? userSelected;
        public delegate void UserHandler(UserModel? User);
        public event UserHandler? UserChanged;
        public UserModel? UserSelected 
        {
            get=>userSelected;
            private set
            {
                
                if ( value == userSelected)
                {
                    return;
                }
               
                userSelected = value;
                UserChanged?.Invoke(userSelected);
            }
        }
        public string[] UserNames
        {
            get => Env.Current.UnitOfWork.Users.GetAll().Select(u => u.Name).ToArray();
        }
        public bool UserSelect(string Name)
        {
            try
            {
                var find_users = Env.Current.UnitOfWork.Users.Find(u => u.Name == Name);
                var user=  find_users.Count()>=1?find_users.First():null;
              
                if (user!=null)
                {
                    UserSelected = new UserModel(user);
                    return true;
                }
                else
                {
                    throw new Exception("Пользователь не найден");
                }
            }
            catch
            {
                UserSelected = null;
                return false;
            }
            
        }
        public bool CreateUser(string Name )
        {
            try
            {
                var find_users = Env.Current.UnitOfWork.Users.Find(o => o.Name == Name);
                if (find_users is not null && find_users.Count() > 0)
                    throw new Exception("Такой пользователь уже есть");
                Env.Current.UnitOfWork.Users.Create(new User(Name));
                Env.Current.UnitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
