using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2C.DataAccess.Models
{
    public class User
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Enter the UserName")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter the UserLastName")]
        public string LastName { get; set; }
    }
}
