using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        [Key]
        public string Uname { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [Required]
        public DateTime DOB { get; set; }                

        [Required]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        public int Points { get; set; }

        [Required]
        public string UserType { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }

        public User()
        {
            Bookings = new List<Booking>();
            Reviews = new List<Review>();
            Notifications = new List<Notification>();

        }
    }
}
