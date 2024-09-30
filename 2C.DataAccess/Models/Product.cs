using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace _2C.DataAccess.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Enter the ProductName!")]
        public required string Name { get; set; }
        public double Price { get; set; }

        [Range(0, 1000000)]
        public int Quantity {  get; set; }
        public Guid StorageId { get; set; }
        public Storage Storage { get; set; }
    }
}
