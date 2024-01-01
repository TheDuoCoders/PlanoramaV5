using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Booking
    {   //need to fix
        public int Id { get; set; }

        [Required]
        [ForeignKey("Package")]
        public int PackageId { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        [ForeignKey("User")]
        public string OrderedBy { get; set; }

        [ForeignKey("Coupon")]
        public int CouponId { get; set; }

        [Required]
        public DateTime OrderTime { get; set; }

        public virtual User User { get; set; }
        public virtual Package Package { get; set; }
        public virtual Coupon Coupon { get; set; }

    }
}
