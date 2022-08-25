using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directions_of_training.DAL.Entities
{
    public class Direction
    {
    

        public Direction(string title, string code, QualificationEnum qualification)
        {
            this.Title = title;
            this.Code = code;
            this.Qualification = qualification;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public QualificationEnum Qualification { get; set; }
        public List<Profile> Profiles { get; set; } = new();
    }
}
