using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class NotificationRepo : Repos, IRepo<Notification, int, bool>
    {
        public bool Create(Notification obj)
        {
            db.Notifications.Add(obj);

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
            db.Notifications.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Notification> Read()
        {
            return db.Notifications.ToList();
        }

        public Notification Read(int id)
        {
            return db.Notifications.Find(id);
        }

        public bool Update(Notification obj)
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
