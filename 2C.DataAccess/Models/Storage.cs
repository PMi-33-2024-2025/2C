using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2C.DataAccess.Models
{
	public class Storage
	{
		[Key]
		public long Id { get; set; }
		public string? Address { get; set; }

		public ICollection<User> Users { get; set; }

		public ICollection<Product> Products { get; set; }
	}
}
