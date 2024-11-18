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
			.RuleFor(x => x.Name, _ => )
		[SetUp]
		public void SetUp()
		{
			service = new Mock<ProductService>(new Mock<_2CDbContext>().Object);
		}
		[Test]
		public async Task GetById_WhenNonExistentId_ReturnsNull()
		{
			// Arrange
			var products = GenerateProducts();
			Guid nonExistentId = Guid.NewGuid();
			// Act
			service.Setup(m => m.GetById(nonExistentId)).Returns(Task.FromResult<Product>(null));
			// Assert
			service.VerifyAll();
		}

		private List<Application> GenerateApplicationsForSameWorkshop()
		{

		}
	}
}
