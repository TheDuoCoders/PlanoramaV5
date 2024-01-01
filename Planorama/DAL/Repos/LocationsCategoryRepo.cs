using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class LocationsCategoryRepo : Repos, IRepo<LocationsCategory, int, bool>
    {
        public bool Create(LocationsCategory obj)
        {
            db.LocationsCategories.Add(obj);

            if (db.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.LocationsCategories.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<LocationsCategory> Read()
        {
            return db.LocationsCategories.ToList();

        }

        public LocationsCategory Read(int id)
        {
            return db.LocationsCategories.Find(id);

        }

        public bool Update(LocationsCategory obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
