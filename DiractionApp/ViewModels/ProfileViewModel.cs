using Directions_of_training.BLL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DiractionApp.ViewModels
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        ProfileModel profile;
        public ProfileViewModel(ProfileModel profile)
        {
            this.profile = profile;
        }
        public int Id =>profile.Id;
        public string Name =>profile.Name;
        public string Faculty =>profile.Faculty;
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
