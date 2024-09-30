using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2C.DataAccess.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Enter the UserName!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter the UserLastName!")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage ="Enter the Email correctly!")]
        public string Email {  get; set; }

        [Required(ErrorMessage ="Enter the Password")]
        [Length(8, 32)]
        public string Password { get; set; }      

        [ForeignKey(nameof(Storage))]
        public long StorageId { get; set; }
        public Storage Storage { get; set; }

        [ForeignKey(nameof(Role))]
        public int RoleId { get; set; }
        public Role Role { get; set; } = new Role { Name = "User" };
    }
}
