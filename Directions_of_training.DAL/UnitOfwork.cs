using Directions_of_training.DAL.EF;
using Directions_of_training.DAL.Entities;
using Directions_of_training.DAL.Interfaces;
using Directions_of_training.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Directions_of_training.DAL
{
    public class UnitOfWork
    {
        DalContext context;
        DirectionReposytory directionReposytory;
        ProfileReposytory profileReposytory;
        UserReposytory userReposytory;
        CartDirectionReposytory cartDirectionReposytory;//репозиторий приоритетов каталога
        CartProfileRepository cartProfileRepository;//репозиторий приоритетов профилей
        public UnitOfWork()
        {
            this.context = new();

        }

        public IRepository<User> Users
        {
            get
            {
                this.userReposytory = this.userReposytory ?? new(context);
                return userReposytory;
            }
        }
        public IRepository<Direction> Directions
        {
            get
            {
                this.directionReposytory = this.directionReposytory ?? new(context);
                return directionReposytory;
            }
        }
        public IRepository<Profile>  Profiles
        {
            get
            {
                this.profileReposytory = this.profileReposytory ?? new(context);
                return profileReposytory;
            }
        }
        public IRepository<CartDirection> CartDirections
        {
            get
            {
                this.cartDirectionReposytory = this.cartDirectionReposytory ?? new(context);
                return cartDirectionReposytory;
            }
        }
        public IRepository<CartProfile> CartProfiles
        {
            get
            {
                this.cartProfileRepository = this.cartProfileRepository ?? new(context);
                return cartProfileRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
        

    }
}