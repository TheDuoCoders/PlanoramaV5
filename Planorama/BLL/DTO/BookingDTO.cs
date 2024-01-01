using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class BookingDTO
    {
        public int Id { get; set; }

        [Required]
        public int PackageId { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string OrderedBy { get; set; }

        public int CouponId { get; set; }

        [Required]
        public DateTime OrderTime { get; set; }
    }
}
