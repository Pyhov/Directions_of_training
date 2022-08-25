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
    public class CartDirectionReposytory : IRepository<CartDirection>
    {
        private DalContext db;

        internal CartDirectionReposytory(DalContext db)
        {
            this.db = db;
        }

        public void Create(CartDirection item)
        {
            db.CartDirections.Add(item);
        }

        public void Delete(int id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
        }

        public IEnumerable<CartDirection> Find(Func<CartDirection, bool> predicate)
        {
           return db.CartDirections.Include(o => o.User).Where(predicate);
        }

        public CartDirection Get(int id)
        {
            return db.CartDirections.Find(id);
        }

        public IEnumerable<CartDirection> GetAll()
        {
            return db.CartDirections;
        }

        public void Update(CartDirection item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
