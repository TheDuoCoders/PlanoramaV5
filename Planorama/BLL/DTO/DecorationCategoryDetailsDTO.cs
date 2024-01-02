using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class DecorationCategoryDetailsDTO : DecorationsCategoryDTO
    {
        public List<DecorationDTO> Decorations { get; set; }

        public DecorationCategoryDetailsDTO()
        {

            Decorations = new List<DecorationDTO>();
        }
    }
}
