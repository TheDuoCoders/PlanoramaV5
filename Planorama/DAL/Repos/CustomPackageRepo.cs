using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CustomPackageRepo : Repos, IRepo<CustomPackage, int, bool>
    {
        public bool Create(CustomPackage obj)
        {
            db.CustomPackages.Add(obj);

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
            db.CustomPackages.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<CustomPackage> Read()
        {
            return db.CustomPackages.ToList();
        }

        public CustomPackage Read(int id)
        {
            return db.CustomPackages.Find(id);
        }

        public bool Update(CustomPackage obj)
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
