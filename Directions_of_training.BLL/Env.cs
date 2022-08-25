using Directions_of_training.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directions_of_training.BLL
{
    public class Env
    {
        static Env EnvInstance = null;
        UserManager userManager;
        Catalog catalog;
        Cart cart;
        UnitOfWork uof;

        private Env() { }
        public static void Init()
        {
            if(EnvInstance == null)
            {
                EnvInstance = new();
                EnvInstance.uof = new UnitOfWork();
                EnvInstance.userManager = new UserManager();
                EnvInstance.catalog = new Catalog();
                EnvInstance.catalog.Load();
                EnvInstance.cart = new Cart();
               
            }
        }
        public static Env Current
        {
            get
            {
                if (EnvInstance is null)
                    throw new NullReferenceException();
                return EnvInstance;
            } 
        }
        internal UnitOfWork UnitOfWork => uof;
        public UserManager UserManager => userManager;
        public Catalog Catalog => catalog;  
        public Cart Cart => cart;
    }
}
