using _2C.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2C.BusinessLogic.Services
{
	public interface IProductService
	{
		public Task Create(Product product);
		public Task<IEnumerable<Product>> GetAll();
		public Task<Product?> GetById(Guid id);
		public Task Update(Guid id, string name, double price, int quantity, long storageId);
		public Task Delete(Guid id);
	}
}
