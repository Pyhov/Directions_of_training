using DiractionApp.Commands;
using Directions_of_training.BLL.Model;
using Directions_of_training.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DiractionApp.ViewModels
{
    public class DirectionViewModel : INotifyPropertyChanged
    {
        private protected DirectionModel diraction;
        ObservableCollection  <ProfileViewModel> profiles;
       
        int position;
        private protected DirectionViewModel()
        {

        }
        public DirectionViewModel(DirectionModel diraction)
        {
            this.diraction = diraction;                     
            FillProfiles();
        }
        public void FillProfiles()
        {
            profiles = profiles ?? new();
            profiles.Clear();
            diraction.Profiles.ForEach(p => profiles.Add(new ProfileViewModel(p)));
        }
        public int Id=>diraction.Id;
        public int Position
        {
            get => position;
            set
            {
                position = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Position"));
            }
        }
        public string Title => diraction.Title;
        public string Code=>diraction.Code;
        public  ObservableCollection<ProfileViewModel> Profiles => profiles;


        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
