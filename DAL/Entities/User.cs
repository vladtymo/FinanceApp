using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(100), MinLength(5), Required]
        public string Name { get; set; }
        [MaxLength(100), MinLength(5), Required]
        public string Surname { get; set; }
        [MaxLength(100), MinLength(5), Required]
        public string Email { get; set; }
        [MaxLength(20), MinLength(6), Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
