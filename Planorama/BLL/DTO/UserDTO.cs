using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class UserDTO
    {
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

        
    }
}
