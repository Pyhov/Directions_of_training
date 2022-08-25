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
    public class CartProfileRepository : IRepository<CartProfile>
    {
        private DalContext db;

        internal CartProfileRepository(DalContext db)
        {
            this.db = db;
        }

        public void Create(CartProfile item)
        {
            db.CartProfiles.Add(item);
        }

        public void Delete(int id)
        {
            var profile = db.CartProfiles.Find(id);
            db.CartProfiles.Remove(profile);
        }

        public IEnumerable<CartProfile> Find(Func<CartProfile, bool> predicate)
        {
            return db.CartProfiles.Include(o => o.User).Where(predicate);
        }

        public CartProfile Get(int id)
        {
            return db.CartProfiles.Find(id);
        }

        public IEnumerable<CartProfile> GetAll()
        {
            return db.CartProfiles;
        }

        public void Update(CartProfile item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
