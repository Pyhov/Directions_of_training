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
    public class DirectionReposytory : IRepository<Direction>
    {
        private DalContext db;

        internal DirectionReposytory(DalContext db)
        {
            this.db = db;
        }

        public void Create(Direction item)
        {
             db.Directions.Add(item);
        }

        public void Delete(int id)
        {
            var direction = db.Directions.Find(id);
            db.Directions.Remove(direction);
        }

        public IEnumerable<Direction> Find(Func<Direction, bool> predicate)
        {
            return db.Directions.Include(o=>o.Profiles).Where(predicate);
        }

        public Direction Get(int id)
        {
            return db.Directions.Find(id);
        }

        public IEnumerable<Direction> GetAll()
        {
      
                return db.Directions.Include(o => o.Profiles).ToList();
        }

        public void Update(Direction item)
        {
           db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
