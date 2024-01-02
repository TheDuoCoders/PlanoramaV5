using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class BookingRepo : Repos, IRepo<Booking, int, bool>
    {
        public bool Create(Booking obj)
        {
            db.Packages.Add(obj.Package);
            db.Bookings.Add(obj);

            if (db.SaveChanges() > 0)
            {
                Notification notification = new Notification();
                notification.Id = db.Notifications.Count() + 1;
                notification.NotificationMessage = "New Booking Added by " + obj.OrderedBy.ToString();
                notification.NotificationTime = DateTime.Now;
                notification.NotifiedUser = "User-1";
                db.Notifications.Add(notification);
                db.SaveChanges();
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
            db.Bookings.Remove(ex);
            if (db.SaveChanges() > 0)
            {
                Notification notification = new Notification();
                notification.Id = db.Notifications.Count() + 1;
                notification.NotificationMessage = id + "Booking Deleted, Id=" + id;
                notification.NotificationTime = DateTime.Now;
                notification.NotifiedUser = "User-1";
                db.Notifications.Add(notification);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Booking> Read()
        {
            return db.Bookings.ToList();
        }

        public Booking Read(int id)
        {
            return db.Bookings.Find(id);
        }

        public bool Update(Booking obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
            {
                Notification notification = new Notification();
                notification.Id = db.Notifications.Count() + 1;
                notification.NotificationMessage = "Booking Updated, Id = " + obj.Id.ToString();
                notification.NotificationTime = DateTime.Now;
                notification.NotifiedUser = "User-1";
                db.Notifications.Add(notification);
                db.SaveChanges();
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
