using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.Remoting.Contexts;

namespace DAL.Models
{
    public class Notification
    {
        public int Id { get; set; }

        [Required]
        public string NotificationMessage { get; set; }

        [Required]
        [ForeignKey("User")]
        public string NotifiedUser { get; set; }

        [Required]
        public DateTime NotificationTime { get; set; }

        public virtual User User { get; set; }
    }
}
