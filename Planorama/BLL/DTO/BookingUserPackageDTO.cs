using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class BookingUserPackageDTO : BookingDTO
    {
        public UserDTO User { get; set; }
        public PackageDTO Package { get; set; }
        public BookingUserPackageDTO()
        {

            Package = new PackageDTO();
            User = new UserDTO();
        }
    }
}
