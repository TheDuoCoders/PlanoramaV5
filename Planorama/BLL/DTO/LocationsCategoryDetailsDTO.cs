using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class LocationsCategoryDetailsDTO : LocationsCategoryDTO
    {
        public List<LocationDTO> Locations { get; set; }

        public LocationsCategoryDetailsDTO()
        {

            Locations = new List<LocationDTO>();
        }
    }
}
