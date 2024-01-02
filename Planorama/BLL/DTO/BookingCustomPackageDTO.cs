using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class BookingCustomPackageDTO : BookingDTO
    {
        public PackageDTO Package { get; set; }

        public BookingCustomPackageDTO()
        {

            Package = new PackageDTO();
        }
    }
}
