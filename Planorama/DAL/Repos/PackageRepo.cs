using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PackageRepo : Repos, IRepo<Package, int, bool>
    {
        public bool Create(Package obj)
        {
            db.Packages.Add(obj);

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
            db.Packages.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Package> Read()
        {
            return db.Packages.ToList();
        }

        public Package Read(int id)
        {
            return db.Packages.Find(id);
        }

        public bool Update(Package obj)
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
