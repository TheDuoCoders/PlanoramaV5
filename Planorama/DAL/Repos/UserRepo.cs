using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repos, IRepo<User, string, bool> , IAuth<bool>
    {
            public bool Authenticate(string username, string password)
            {
                var data = db.Users.FirstOrDefault(u => u.Uname.Equals(username) && password.Equals(password));
                if (data != null)
                {
                    return true;
                }
                return false;
            }

        //-----------------------------USER REPO----------------------------

        public bool Create(User obj)
        {
            db.Users.Add(obj);
            if (db.SaveChanges() > 0)
            {
                Notification notification = new Notification();
                notification.Id = db.Notifications.Count() + 1;
                notification.NotificationMessage = "New User Added";
                notification.NotificationTime = DateTime.Now;
                notification.NotifiedUser = "User-1";
                db.Notifications.Add(notification);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(string id)
        {
            var ex = Read(id);
            db.Users.Remove(ex);
            if (db.SaveChanges() > 0)
            {
                Notification notification = new Notification();
                notification.Id = db.Notifications.Count() + 1;
                notification.NotificationMessage = id + "User Deleted";
                notification.NotificationTime = DateTime.Now;
                notification.NotifiedUser = "User-1";
                db.Notifications.Add(notification);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<User> Read()
        {
            return db.Users.ToList();
        }

        public User Read(string id)
        {
            return db.Users.Find(id);
        }

        public bool Update(User obj)
        {
            var ex = Read(obj.Uname);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
            {
                Notification notification = new Notification();
                notification.Id = db.Notifications.Count() + 1;
                notification.NotificationMessage = obj.Uname + "User Updated";
                notification.NotificationTime = DateTime.Now;
                notification.NotifiedUser = "User-1";
                db.Notifications.Add(notification);
                db.SaveChanges();
                return true;
            }
            return false;
        }


    }
}
