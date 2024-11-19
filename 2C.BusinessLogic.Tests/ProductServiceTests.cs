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
		private Mock<IProductService> mockProductService;

		[SetUp]
		public void SetUp()
		{
			mockProductService = new Mock<IProductService>();
			productService = mockProductService.Object;
		}
		[Test]
		public async Task GetById_WhenNonExistentId_ReturnsNull()
		{
			// Arrange
			Product productToGet = ProductsGenerator.Generate();
			mockProductService.Setup(m => m.GetById(productToGet.Id)).ReturnsAsync(null as Product);

			// Act
			Product? product = await productService.GetById(productToGet.Id);

			// Assert
			product.Should().BeNull();
		}
		[Test]
		public async Task GetById_WhenIdExists_ReturnsProduct()
		{
			// Arrange
			Product productToGet = ProductsGenerator.Generate();
			mockProductService.Setup(m => m.GetById(productToGet.Id)).ReturnsAsync(productToGet);

			// Act
			Product? product = await productService.GetById(productToGet.Id);

			// Assert
			product.Should().BeEquivalentTo(productToGet);
		}
		[Test]
		public async Task Update_WhenIdExists_Ok()
		{
			// Arrange
			var storageToAdd = StorageGenerator.Generate();
			var productToAdd = ProductsGenerator.Generate().WithStorageId(storageToAdd);

			mockProductService.Setup(m => m.Update(productToAdd.Id, productToAdd.Name, productToAdd.Price, productToAdd.Quantity, productToAdd.StorageId));

			// Act
			await productService.Update(productToAdd.Id, productToAdd.Name, productToAdd.Price, productToAdd.Quantity, productToAdd.StorageId);
		}
		[Test]
		public async Task Update_WhenNonExistentId_ThrowsNullReferenceException()
		{
			// Arrange
			Product nonExistentProduct = ProductsGenerator.Generate();

			mockProductService.Setup(m => m.Update(nonExistentProduct.Id, nonExistentProduct.Name, nonExistentProduct.Price, nonExistentProduct.Quantity, nonExistentProduct.StorageId)).Throws<NullReferenceException>();
			// Act
			Assert.ThrowsAsync<NullReferenceException>(
				async () =>
				{
					await productService.Update(nonExistentProduct.Id, nonExistentProduct.Name, nonExistentProduct.Price, nonExistentProduct.Quantity, nonExistentProduct.StorageId);
				}
			);
		}
		[Test]
		public async Task Delete_WhenNonExistentId_ThrowsNullReferenceException()
		{
			// Arrange
			Product nonExistentProduct = ProductsGenerator.Generate();

			mockProductService.Setup(m => m.Delete(nonExistentProduct.Id)).Throws<NullReferenceException>();
			// Assert
			Assert.ThrowsAsync<NullReferenceException>(
				// Act
				async () =>
				{
					await productService.Delete(nonExistentProduct.Id);
				}
			);
		}
	}
}
