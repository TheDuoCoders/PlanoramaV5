using BLL.DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StatsService
    {
        public static StatsDTO Get()
        {
            var stats = new StatsDTO();

            var TotalUsers = DataAccessFactory.UserData().Read();
            stats.TotalUsers = TotalUsers.Count();

            var TotalBookings = DataAccessFactory.BookingData().Read();
            stats.TotalBookings = TotalBookings.Count();

            var TotalDecorations = DataAccessFactory.DecorationData().Read();
            stats.TotalDecorations = TotalDecorations.Count();

            var TotalLocations = DataAccessFactory.LocationData().Read();
            stats.TotalLocations = TotalLocations.Count();

            var TotalFoodItems = DataAccessFactory.FoodData().Read();
            stats.TotalFoodItems = TotalFoodItems.Count();

            var TotalPackages = DataAccessFactory.PackageData().Read();
            stats.TotalPackages = TotalPackages.Count();

            var TotalCustomPackages = DataAccessFactory.CustomPackageData().Read();
            stats.TotalCustomPackages = TotalCustomPackages.Count();

            var TotalDecorationsCategory = DataAccessFactory.DecorationsCategoryData().Read();
            stats.TotalDecorationsCategory = TotalDecorationsCategory.Count();

            var TotalLocationsCategory = DataAccessFactory.LocationsCategoryData().Read();
            stats.TotalLocationsCategory = TotalLocationsCategory.Count();

            var TotalFoodCategory = DataAccessFactory.FoodsCategoryData().Read();
            stats.TotalFoodCategory = TotalFoodCategory.Count();


            var maxSelectedFood = DataAccessFactory.FoodData().Read().OrderByDescending(food => food.TimesSelected).FirstOrDefault();

            if (maxSelectedFood != null)
            {
                stats.MaxSelectedFood = maxSelectedFood.Name;
            }
            else
            {
                stats.MaxSelectedFood = "No food items available";
            }

            var maxSelectedLocation = DataAccessFactory.LocationData().Read().OrderByDescending(location => location.TimesSelected).FirstOrDefault();
            if (maxSelectedLocation != null)
            {
                stats.MaxSelectedLocation = maxSelectedLocation.Name;
            }
            else
            {
                stats.MaxSelectedLocation = "No locations available";
            }

            var maxSelectedDecoration = DataAccessFactory.DecorationData().Read().OrderByDescending(decoration => decoration.TimesSelected).FirstOrDefault();
            if (maxSelectedDecoration != null)
            {
                stats.MaxSelectedDecoration = maxSelectedDecoration.Name;
            }
            else
            {
                stats.MaxSelectedDecoration = "No decorations available";
            }

            return stats;

        }
    }
}
