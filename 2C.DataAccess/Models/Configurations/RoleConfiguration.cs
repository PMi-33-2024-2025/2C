using _2C.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2C.DataAccess.Configurations
{
	public class RoleConfiguration : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder.HasKey(x => x.Id);

			builder.HasMany(x => x.Users)
				.WithOne(x => x.Role);

			builder.HasData(new Role() { Id = 1, Name = "Admin" },
				new Role() { Id = 2, Name = "User" });
		}
	}
}
