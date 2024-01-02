using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CustomPackageFullDTO : PackageDTO
    {
        public FoodDTO Food { get; set; }
        public DecorationDTO Decoration { get; set; }
        public LocationDTO Location { get; set; }

        public CustomPackageFullDTO()
        {
            Food = new FoodDTO();
            Decoration = new DecorationDTO();
            Location = new LocationDTO();
        }
    }
}
