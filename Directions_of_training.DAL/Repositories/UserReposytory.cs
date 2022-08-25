using Directions_of_training.DAL.EF;
using Directions_of_training.DAL.Entities;
using Directions_of_training.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directions_of_training.DAL.Repositories
{
    public class UserReposytory : IRepository<User>
    {
        private DalContext db;

        internal UserReposytory(DalContext db)
        {
            this.db = db;
        }

        public void Create(User item)
        {
            db.Users.Add(item);
        }

        public void Delete(int id)
        {
            var user = db.Users.Find(id);

            db.Users.Remove(user);
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
           return db.Users.Include(o => o.CartDirections).Include(p=>p.CartProfiles).Where(predicate);
        }

        public User Get(int id)
        {

            return db.Users.Include(o => o.CartDirections).Include(p => p.CartProfiles).Where(u => u.Id == id).First();
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.Include(o => o.CartDirections).Include(o=>o.CartProfiles);
        }

        public void Update(User item)
        {
            db.Users.Update(item);
        }
    }
}
