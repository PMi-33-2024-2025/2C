using _2C.BusinessLogic.Services;
using _2C.BusinessLogic.Tests.Generators;
using _2C.DataAccess;
using _2C.DataAccess.Models;
using Bogus;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
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
		private IProductService productService;
		private Mock<_2CDbContext> dbContext;

		[SetUp]
		public void SetUp()
		{
			dbContext = new Mock<_2CDbContext>();
			var products = new Mock<DbSet<Product>>();
			var storages = new Mock<DbSet<Storage>>();
			var users = new Mock<DbSet<User>>();
			var roles = new Mock<DbSet<Role>>();
			dbContext.Object.Products = products.Object;
			dbContext.Object.Storages = storages.Object;
			dbContext.Object.Users = users.Object;
			dbContext.Object.Roles = roles.Object;
			productService = new ProductService(dbContext.Object);
		}
		[Test]
		public async Task GetById_WhenNonExistentId_ReturnsNull()
		{
			// Arrange
			Guid nonExistentId = Guid.NewGuid();
			// Act
			var emptyProduct = await productService.GetById(nonExistentId);
			// Assert
			emptyProduct.Should().BeNull();
		}
		[Test]
		public async Task GetById_WhenIdExists_ReturnsProduct()
		{
			// Arrange
			Guid IdToAdd = Guid.NewGuid();
			dbContext.Setup(m => m.Products.Add(It.Is<Product>(p => p.Id == IdToAdd)));
			// Act
			var notEmptyProduct = await productService.GetById(IdToAdd);
			// Assert
			notEmptyProduct.Should().NotBeNull();
			Assert.True(notEmptyProduct.Id == IdToAdd);
		}
		[Test]
		public async Task Update_WhenIdExists_Ok()
		{
			// Arrange
			Guid IdToAdd = Guid.NewGuid();
			dbContext.Setup(m => m.Products.Add(It.Is<Product>(p => p.Id == IdToAdd)));
			// Act
			await productService.Update(IdToAdd, It.IsAny<string>(),
				It.Is<double>(x => x > 0), It.Is<int>(x => x > 0), It.Is<long>(x => x > 0));
		}
		[Test]
		public async Task Update_WhenNonExistentId_ThrowsNullReferenceException()
		{
			// Arrange
			Guid NonExistentId = Guid.NewGuid();
			// Act
			Assert.ThrowsAsync<NullReferenceException>(
				async () =>
				{
					await productService.Update(NonExistentId, It.IsAny<string>(),
						It.Is<double>(x => x > 0), It.Is<int>(x => x > 0), It.Is<long>(x => x > 0));
				});
		}
		[Test]
		public async Task Delete_WhenNonExistentId_ThrowsNullReferenceException()
		{
			// Arrange
			Guid NonExistentId = Guid.NewGuid();
			// Assert
			Assert.ThrowsAsync<NullReferenceException>(
				// Act
				async () =>
				{
					await productService.Delete(NonExistentId);
				}
			);
		}
	}
}
