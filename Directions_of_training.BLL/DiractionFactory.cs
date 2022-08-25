using Directions_of_training.BLL.Model;
using Directions_of_training.DAL.Entities;
using Directions_of_training.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Directions_of_training.BLL
{
    internal class DiractionFactory
    {
        public static DirectionModel CatalogItemCreate(Direction direction)
        {
            List<ProfileModel> items = new List<ProfileModel>();
            direction.Profiles.ToList().ForEach(o => items.Add(ProfileItemCreate(o)));
            DirectionModel catalogItem = new DirectionModel(direction.Id,direction.Code, direction.Title,items);
            
            return catalogItem;
        }
        public static ProfileModel ProfileItemCreate(Profile profile)
        {
            return new ProfileModel(profile.Id,profile.Name,profile.Faculty);
        }
        
    }
}
