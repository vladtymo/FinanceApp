using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class User
    {
        public int Id { get; set; }
     
        [Index(IsUnique = true)]
        [MinLength(5)]
        public string Login { get; set; }

        [MinLength(5)]
        public string Password { get; set; }
    }
}
