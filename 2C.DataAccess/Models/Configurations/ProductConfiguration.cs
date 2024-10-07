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
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasKey(x => x.Id);

			builder.HasOne(x => x.Storage)
				.WithMany(x => x.Products);

			builder.HasData(new Product() { Id = new Guid("27D3FA15-7A6D-4F5A-8436-1F0B2FCED642"), Name = "Banana", Price = 40, Quantity = 100_000, StorageId = 1 });

			builder.HasData(new Product() { Id = new Guid("926CA070-AF63-4474-8D07-439B5EA17B43"), Name = "Apple", Price = 25, Quantity = 200_000, StorageId = 2 });

			builder.HasData(new Product() { Id = new Guid("883CF1EF-E8F0-46C2-826F-F08A32BFCAE6"), Name = "Tomato", Price = 70, Quantity = 40_000, StorageId = 1 });

			builder.HasData(new Product() { Id = new Guid("F25798A4-0111-4070-A872-E5092FEDB435"), Name = "Cucumber", Price = 60, Quantity = 250_000, StorageId = 2 });
		}
	}
}
