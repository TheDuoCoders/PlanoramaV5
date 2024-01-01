using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Package
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Photo { get; set; }

        [Required] 
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        [ForeignKey("Food")]
        public int FoodId { get; set; }
        
        [Required]
        [ForeignKey("Decoration")]
        public int DecorationId { get; set; }


        [Required]
        [ForeignKey("Location")]
        public int LocationId { get; set; }

        [Required]
        public int GuestAmount { get; set; }

        public virtual Food Food { get; set; }
        public virtual Decoration Decoration { get; set; }
        public virtual Location Location { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        public Package()
        {
            Bookings = new List<Booking>();
        }
    }
}
