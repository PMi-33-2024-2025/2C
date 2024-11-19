using _2C.DataAccess;
using _2C.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2C.BusinessLogic.Services
{
	public class ProductService : IProductService
	{
		private readonly _2CDbContext context;

		public ProductService(_2CDbContext context)
		{
			this.context = context;
		}

		public async Task Create(Product product)
		{
			await context.AddAsync(product).ConfigureAwait(false);
			await context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Product>> GetAll()
		{
			return await context.Products.ToListAsync().ConfigureAwait(false);
		}

		public async Task<Product?> GetById(Guid id)
		{
			return await context.Products.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
		}

		public async Task Update(Guid id, string name, double price, int quantity, long storageId)
		{
			var productToUpdate = new Product { Id = id, Name = name, Price = price, Quantity = quantity };
			var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
			if (product == null)
				throw new NullReferenceException(nameof(product));

			product = productToUpdate;
			product.StorageId = storageId;
			await context.SaveChangesAsync().ConfigureAwait(false);
		}

		public async Task Delete(Guid id)
		{
			var productToRemove = await context.Products.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);

			if (productToRemove == null)
				throw new NullReferenceException(nameof(productToRemove));
			context.Products.Remove(productToRemove);

			await context.SaveChangesAsync().ConfigureAwait(false);
		}
	}
}
