using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        public string ReviewText { get; set; }

        [Required]
        [ForeignKey("User")]
        public string PostedBy { get; set; }

        [Required]
        public DateTime PostedTime { get; set; }

        public virtual User User { get; set; }
    }
}
