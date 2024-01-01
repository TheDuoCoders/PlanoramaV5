using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class NotificationDTO
    {
        public int Id { get; set; }

        [Required]
        public string NotificationMessage { get; set; }

        [Required]
        public string NotifiedUser { get; set; }

        [Required]
        public DateTime NotificationTime { get; set; }
    }
}
