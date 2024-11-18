using _2C.BusinessLogic.Services;
using _2C.BusinessLogic.Tests.Generators;
using _2C.DataAccess;
using _2C.DataAccess.Models;
using FluentAssertions;
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

		[SetUp]
		public void SetUp()
		{
			productService = new Mock<IProductService>(new Mock<_2CDbContext>().Object);
		}
		[Test]
		public async Task GetById_WhenNonExistentId_ReturnsNull()
		{
			// Arrange
			var storage = StorageGenerator.Generate();
			var products = ProductsGenerator.Generate(5).WithStorage(storage);
			Guid nonExistentId = Guid.NewGuid();
			// Act
			productService.Setup(m => m.GetById(nonExistentId)).Returns(Task.FromResult<Product>(null));
			// Assert
			products.Should().BeNull();

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
