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
    public class ProductService: IProductService
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
    }
}
