using _2C.DataAccess.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2C.BusinessLogic.Tests
{
	public static class ProductsGenerator
	{
		private static readonly Faker<Product> faker = new Faker<Product>()
			.RuleFor(x => x.Id, _ => Guid.NewGuid())
			.RuleFor(x => x.Name, f => f.Commerce.ProductName())
			.RuleFor(x => x.Price, f => f.Random.Double(0, 10000))
			.RuleFor(x => x.Quantity, f => f.Random.Int(1, 1000));

		public static Product Generate() => faker.Generate();

		public static List<Product> Generate(int count) => faker.Generate(count);

		public static Product WithStorageId(this Product product, Storage storage)
		{
			_ = product ?? throw new ArgumentNullException(nameof(product));

			product.Storage = storage;
			product.StorageId = storage.Id;

			return product;
		}

		public static IEnumerable<Product> WithStorage(this List<Product> products, Storage storage)
		{
			_ = products ?? throw new ArgumentNullException(nameof(products));
			products.ForEach(t => t.WithStorageId(storage));

			return products;
		}
	}
}
