using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class LocationRepo : Repos, IRepo<Location, int, bool>
    {
        public bool Create(Location obj)
        {
            db.Locations.Add(obj);

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
            db.Locations.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Location> Read()
        {
            return db.Locations.ToList();

        }

        public Location Read(int id)
        {
            return db.Locations.Find(id);

        }

        public bool Update(Location obj)
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
