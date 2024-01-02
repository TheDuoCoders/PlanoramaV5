using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class FoodCategoryDetailsDTO : FoodsCategoryDTO
    {
        public List<FoodDTO> Foods { get; set; }

        public FoodCategoryDetailsDTO()
        {

            Foods = new List<FoodDTO>();
        }
    }
}
