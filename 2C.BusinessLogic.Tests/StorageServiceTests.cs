using _2C.BusinessLogic.Services;
using _2C.BusinessLogic.Tests.Generators;
using _2C.DataAccess;
using _2C.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2C.BusinessLogic.Tests
{
	[TestFixture]
	public class StorageServiceTests
	{
		private IStorageService storageService;
		private Mock<IStorageService> mockStorageService;

		[SetUp]
		public void SetUp()
		{
			mockStorageService = new Mock<IStorageService>();
			storageService = mockStorageService.Object;
		}
		[Test]
		public async Task Delete_WhenNonExistentId_ThrowsNullReferenceException()
		{
			// Arrange
			Storage storage = StorageGenerator.Generate();
			mockStorageService.Setup(m => m.Delete(storage.Id)).Throws<NullReferenceException>();

			// Assert
			Assert.ThrowsAsync<NullReferenceException>(
				// Act
				async () =>
				{
					await storageService.Delete(storage.Id);
				}
			);
		}
		[Test]
		public async Task Update_WhenNonExistentId_ThrowsNullReferenceException()
		{
			// Arrange
			Storage storage = StorageGenerator.Generate();
			mockStorageService.Setup(m => m.Update(storage.Id, storage.Address)).Throws<NullReferenceException>();

			// Assert
			Assert.ThrowsAsync<NullReferenceException>(
				// Act
				async () =>
				{
					await storageService.Update(storage.Id, storage.Address);
				}
			);
		}
	}
}
