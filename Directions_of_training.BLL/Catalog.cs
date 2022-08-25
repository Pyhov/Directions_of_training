using Directions_of_training.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Directions_of_training.BLL
{
    public class Catalog
    {
        List<DirectionModel> items = new List<DirectionModel>();

        public DirectionModel[] Items => items.ToArray();
        public void Load()
        {
            items.Clear();
            var diractions = Env.Current.UnitOfWork.Directions.GetAll();
            foreach (var diraction in diractions)
            {
                items.Add(DiractionFactory.CatalogItemCreate(diraction));
            }
        }

    }
}

