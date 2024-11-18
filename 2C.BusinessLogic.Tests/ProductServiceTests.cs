using _2C.BusinessLogic.Services;
using _2C.DataAccess;
using _2C.DataAccess.Models;
using Bogus;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _2C.BusinessLogic.Tests
{
	[TestFixture]
	public class ProductServiceTests
	{
		private Mock<IProductService> productService;
		private Faker<Product> faker = new Faker<Product>()
			.RuleFor(x => x.Id, _ => new Guid())
			.RuleFor(x => x.Name, f => f.Commerce.Product())
			.RuleFor(x => x.Quantity, f => (int)f.Random.UInt())
			.RuleFor(x => x.Price, f => f.Random.Double())
			.RuleFor(x => x.StorageId, f => (long)f.Random.ULong());

		[SetUp]
		public void SetUp()
		{
			productService = new Mock<IProductService>(new Mock<_2CDbContext>().Object);
		}
		[Test]
		public async Task GetById_WhenNonExistentId_ReturnsNull()
		{
			// Arrange
			var products = GenerateProducts(5);
			Guid nonExistentId = Guid.NewGuid();
			// Act
			productService.Setup(m => m.GetById(nonExistentId)).Returns(Task.FromResult<Product>(null));
			// Assert
			productService.VerifyAll();
		}

		private List<Product> GenerateProducts(int count)
		{
			return faker.Generate(count);
		}

		private void SetupGetById(Product product)
		{
			var productId = new Guid("b94f1989-c4e7-4878-ac86-21c4a402fb43");

			productService.Setup(
				p => p.GetById(productId))
				.ReturnsAsync(product);
        }
	}
}
