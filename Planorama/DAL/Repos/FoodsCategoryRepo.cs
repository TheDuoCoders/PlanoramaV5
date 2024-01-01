using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class FoodsCategoryRepo : Repos, IRepo<FoodsCategory,int, bool> 
    {
        public bool Create(FoodsCategory obj)
        {
            db.FoodsCategories.Add(obj);

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
            db.FoodsCategories.Remove(ex);
            return db.SaveChanges()>0;

            
        }

        public List<FoodsCategory> Read()
        {
            return db.FoodsCategories.ToList();
        }

        public FoodsCategory Read(int id)
        {
            return db.FoodsCategories.Find(id);

        }

        public bool Update(FoodsCategory obj)
        {
            var ex = Read (obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if(db.SaveChanges() > 0)
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
