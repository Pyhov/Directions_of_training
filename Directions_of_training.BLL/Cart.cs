using Directions_of_training.BLL.Helpers;
using Directions_of_training.BLL.Model;
using Directions_of_training.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace Directions_of_training.BLL
{
    public class Cart
    {
        UserModel user = null;
        ObservableCollection<DirectionModel> direcions = new();

        public delegate void DirectionHandler(DirectionModel Direction);
        public delegate void CartClearHandler();
        public delegate void DirectionSwapHandler(DirectionModel direction, PriorityEnum priority);
        public delegate void ProfileSwapHandler(ProfileModel profile, DirectionModel direction, PriorityEnum priority);
        public event DirectionHandler DirectionAdded;
        public event DirectionHandler DirectionRemoved;
        public event DirectionSwapHandler DirectionSwaped;
        public event ProfileSwapHandler ProfileSwaped;
        public event CartClearHandler CartCleared;

        internal Cart()
        {
            Env.Current.UserManager.UserChanged += UserManager_UserChanged;
        }

        private void UserManager_UserChanged(UserModel? User)
        {
            if (User != null)
            {
                this.user = (UserModel)User;
                Load();
            }
            else
            {
                this.user = null;
                direcions.Clear();
            }
        }

        public ObservableCollection<DirectionModel> Directions => direcions;
        
        public void Add(DirectionModel direction)
        {
            try
            {
                var find_dir = direcions.FirstOrDefault(d => d.Id == direction.Id);
                if (find_dir == null)
                {
                    var cardiraction = (DirectionModel)direction.Clone();
                    direcions.Add(cardiraction);
                    DirectionAdded?.Invoke(cardiraction);

                }
                else
                {
                    throw new Exception("Направление уже добавленно");
                }

            }
            catch (Exception ex)
            {

            }
        }
        public void Delete(DirectionModel direction)
        {
            try
            {
                
                var cloneDiraction = (DirectionModel) direction.Clone();
                bool removeFlag = direcions.Remove(direction);
                if (removeFlag)
                    DirectionRemoved?.Invoke(direction);
            }
            catch
            {

            }
        }

        public void Load()
        {
            Clear();
            var userCart = Env.Current.UnitOfWork.Users.Get(user.Id);
            var carDirections = userCart.CartDirections.OrderBy(c => c.Priority);
            foreach (var carDirection in carDirections)
            {
                var profiles = userCart.CartProfiles.Where(d => d.Profile?.DirectionId == carDirection.Direction.Id)
                    .OrderBy(c => c.Priority);
                var profileModels = new List<ProfileModel>();
                profiles.ToList().ForEach(p =>
                {
                    profileModels.Add(new ProfileModel(p.Profile.Id, p.Profile.Name, p.Profile.Faculty));
                });
                direcions.Add(new DirectionModel(carDirection.Direction.Id, carDirection.Direction.Code, carDirection.Direction.Title, profileModels)
                {

                });
            }


        }
        public void Save()
        {
            var uof = Env.Current.UnitOfWork;
            var userCart = uof.Users.Get(user.Id);
            userCart.CartDirections.Clear();
            userCart.CartProfiles.Clear();

            int i = 0;
            foreach (var diracion in direcions)
            {
                var dir = uof.Directions.Get(diracion.Id);
                var cardiraction = new CartDirection()
                {
                    Priority = i,
                    UserId = user.Id,
                    User = userCart,
                    Direction = dir

                };

                i++;
                int j = 0;
                diracion.Profiles.ForEach(p =>
                {
                    var profile = uof.Profiles.Get(p.Id);
                    var cartprofile = new CartProfile()
                    {
                        Priority = j,
                        UserId = user.Id,
                        User = userCart,
                        Profile = profile
                    };
                    userCart.CartProfiles.Add(cartprofile);
                    j++;
                });
                userCart.CartDirections.Add(cardiraction);

            }
            Env.Current.UnitOfWork.Users.Update(userCart);

            Env.Current.UnitOfWork.Save();

        }
        public void Clear()
        {
            direcions.Clear();
            CartCleared?.Invoke();
        }
        
        public void DirectionChangePriority(DirectionModel direction, PriorityEnum priority )
        {       
            int index = direcions.IndexOf(direction);      
            if(index >=0)
            {
                bool swapResult = false;
                switch (priority)
                {
                    case PriorityEnum.Downgrade:
                        if(index<direcions.Count()-1)
                        {
                            swapResult= direcions.Swap(index, index + 1);
                        }
                        break;
                    case PriorityEnum.Increase:
                        if (index >=1)
                        {
                            swapResult = direcions.Swap(index, index - 1);
                        }
                        break;
                }
                if (swapResult)
                    DirectionSwaped?.Invoke(direction, priority);
            }
        }
        
        public void ProfileChangePriority(ProfileModel profile, PriorityEnum priority)
        {
            try
            {
                var dir = direcions.First(d => d.Profiles.Any(p => p.Id == profile.Id));
                int index = dir.Profiles.IndexOf(profile);
                if (index >= 0)
                {
                    bool swapResult = false;
                    switch (priority)
                    {
                        case PriorityEnum.Downgrade:
                            if (index < dir.Profiles.Count() - 1)
                            {
                                swapResult = dir.Profiles.Swap(index, index + 1);
                            }
                            break;
                        case PriorityEnum.Increase:
                            if (index >= 1)
                            {
                                swapResult = dir.Profiles.Swap(index, index - 1);
                            }
                            break;
                    }
                    if (swapResult)
                        ProfileSwaped?.Invoke(profile, dir, priority);
                }
            }
            catch
            {

            }
        }
    }
 
 
}
