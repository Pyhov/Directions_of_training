using Directions_of_training.DAL.EF;
using Directions_of_training.DAL.Entities;
using Directions_of_training.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Directions_of_training.DAL.Repositories
{
    public class ProfileReposytory : IRepository<Profile>
    {
        private DalContext db;

        internal ProfileReposytory(DalContext db)
        {
            this.db = db;
        }

        public void Create(Profile item)
        {
            this.db.Profiles.Add(item);
        }

        public void Delete(int id)
        {
            Profile profile = db.Profiles.Find(id);
            if (profile != null)
                db.Profiles.Remove(profile);
        }

        public IEnumerable<Profile> Find(Func<Profile, bool> predicate)
        {
            return db.Profiles.Where(predicate);
        }

        public Profile Get(int id)
        {
           return db.Profiles.Find(id);
        }

        public IEnumerable<Profile> GetAll()
        {
            return db.Profiles.Include(o=>o.Direction);
        }

        public void Update(Profile item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
