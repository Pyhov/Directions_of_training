using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directions_of_training.BLL.Model
{
    public class DirectionModel : ICloneable
    {
        public DirectionModel(int id, string code, string title, List<ProfileModel> items)
        {
            Id = id;
            Code = code;
            Title = title;
            Profiles = items;
        }

        public int Id { get; }
        public string Code { get; }
        public string Title { get; }
        public List<ProfileModel> Profiles { get; }
        public object Clone()
        {
            var cloneProfiles = new List<ProfileModel>();
            Profiles.ForEach(p => cloneProfiles.Add((ProfileModel)p.Clone()));
            return new DirectionModel(Id, Code, Title, cloneProfiles); 
        }

     
    }
}
