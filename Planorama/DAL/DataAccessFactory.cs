using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<FoodsCategory,int,bool> FoodsCategoryData()
        {
            return new FoodsCategoryRepo();

        }

        public static IRepo<Food, int, bool> FoodData()
        {
            return new FoodRepo();

        }

        public static IRepo<DecorationsCategory, int, bool> DecorationsCategoryData()
        {
            return new DecorationsCategoryRepo();

        }

        public static IRepo<Decoration, int, bool> DecorationData()
        {
            return new DecorationRepo();

        }

        public static IRepo<LocationsCategory, int, bool> LocationsCategoryData()
        {
            return new LocationsCategoryRepo();

        }

        public static IRepo<Location, int, bool> LocationData()
        {
            return new LocationRepo();

        }

        public static IRepo<Booking, int, bool> BookingData()
        {
            return new BookingRepo();

        }

        public static IRepo<Coupon, int, bool> CouponData()
        {
            return new CouponRepo();

        }

        public static IRepo<Notification, int, bool> NotificationData()
        {
            return new NotificationRepo();

        }

        public static IRepo<Package, int, bool> PackageData()
        {
            return new PackageRepo();

        }

        public static IRepo<Review, int, bool> ReviewData()
        {
            return new ReviewRepo();

        }

        public static IRepo<User, string, bool> UserData()
        {
            return new UserRepo();

        }

        public static IRepo<CustomPackage, int, bool> CustomPackageData()
        {
            return new CustomPackageRepo();

        }

    }
}
