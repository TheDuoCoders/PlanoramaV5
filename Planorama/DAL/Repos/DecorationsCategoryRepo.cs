using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class DecorationsCategoryRepo : Repos, IRepo<DecorationsCategory, int, bool>
    {
        public bool Create(DecorationsCategory obj)
        {
            db.DecorationsCategories.Add(obj);

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
            db.DecorationsCategories.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<DecorationsCategory> Read()
        {
            return db.DecorationsCategories.ToList();

        }

        public DecorationsCategory Read(int id)
        {
            return db.DecorationsCategories.Find(id);

        }

        public bool Update(DecorationsCategory obj)
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
