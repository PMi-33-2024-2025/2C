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
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(x => x.Id);

			builder.HasOne(x => x.Role)
				.WithMany(x => x.Users);

			builder.HasOne(x => x.Storage)
				.WithMany(x => x.Users);

			builder.HasData(new User() { Id = new Guid("3F69ED69-4757-4875-BBD2-F2925F1AD4AB"), Email = "max@gmail.com", LastName = "Doe", Name = "Max", Password = "12345678", RoleId = 2, StorageId = 2 });
			builder.HasData(new User() { Id = new Guid("227A5A5C-98F6-45D5-8628-7B53240695E5"), Email = "andrii@gmail.com", LastName = "Shevchenko", Name = "Andrii", Password = "abcd1234", RoleId = 1, StorageId = 2 });
			builder.HasData(new User() { Id = new Guid("23C14957-7D7E-47E0-9CA4-7ABA886F2C4D"), Email = "pavlo@gmail.com", LastName = "Ivanov", Name = "Pavlo", Password = "abcdefgh", RoleId = 2, StorageId = 1 });
			builder.HasData(new User() { Id = new Guid("13AE9E21-62AE-4C89-8B48-318B9629714D"), Email = "bohdan@gmail.com", LastName = "Ostrovskyi", Name = "Bohdan", Password = "abcd1234", RoleId = 1, StorageId = 1 });

		}
	}
}
