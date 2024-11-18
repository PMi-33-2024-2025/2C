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
		private Mock<ProductService> service;
		private Faker<Product> faker = new Faker<Product>()
			.RuleFor(x => x.Id, _ => new Guid())
			.RuleFor(x => x.Name, f => f.Commerce.Product())
			.RuleFor(x => x.Quantity, f => (int)f.Random.UInt())
			.RuleFor(x => x.Price, f => f.Random.Double())
			.RuleFor(x => x.StorageId, f => (long)f.Random.ULong());

		[SetUp]
		public void SetUp()
		{
			service = new Mock<ProductService>(new Mock<_2CDbContext>().Object);
		}
		[Test]
		public async Task GetById_WhenNonExistentId_ReturnsNull()
		{
			// Arrange
			var products = GenerateProducts(5);
			Guid nonExistentId = Guid.NewGuid();
			// Act
			service.Setup(m => m.GetById(nonExistentId)).Returns(Task.FromResult<Product>(null));
			// Assert
			service.VerifyAll();
		}

		private List<Product> GenerateProducts(int count)
		{
			return faker.Generate(count);
		}
	}
}
