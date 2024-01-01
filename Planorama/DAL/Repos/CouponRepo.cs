using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CouponRepo : Repos, IRepo<Coupon, int, bool>
    {
        public bool Create(Coupon obj)
        {
            db.Coupons.Add(obj);

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
            db.Coupons.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Coupon> Read()
        {
            return db.Coupons.ToList();
        }

        public Coupon Read(int id)
        {
            return db.Coupons.Find(id);
        }

        public bool Update(Coupon obj)
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
