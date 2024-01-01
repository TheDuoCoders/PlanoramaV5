using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CouponDTO
    {
        public int Id { get; set; }

        [Required]
        public string CouponText { get; set; }

        [Required]
        public int DiscountPercentage { get; set; }

        [Required]
        public DateTime Validity { get; set; }
    }
}
