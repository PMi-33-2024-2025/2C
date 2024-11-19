using _2C.BusinessLogic.Services;
using _2C.DataAccess;
using _2C.DataAccess.DTO;
using _2C.DataAccess.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2C.BusinessLogic.Tests
{
	[TestFixture]
	public class UserServiceTests
	{
		private IUserService userService;
		private Mock<IUserService> mockUserService;

		[SetUp]
		public void SetUp()
		{
			mockUserService = new Mock<IUserService>();
			userService = mockUserService.Object;
		}
		[Test]
		public async Task Login_WhenIncorrectLogin_ReturnsFalse()
		{
			// Arrange
			string email = "someone@gmail.com";
			string incorrectPassword = "iadf1";
			LoginDto login = new LoginDto() { Email = email, Password = incorrectPassword };

			mockUserService.Setup(m => m.Login(login)).ReturnsAsync(false);

			// Assert
			bool signedIn = await userService.Login(login);
			// Act
			signedIn.Should().BeFalse();
		}
		[Test]
		public async Task Login_WhenCorrectLogin_ReturnsFalse()
		{
			// Arrange
			string email = "someone@gmail.com";
			string password = "12345678";
			LoginDto login = new LoginDto() { Email = email, Password = password };

			mockUserService.Setup(m => m.Login(login)).ReturnsAsync(true);
			// Assert
			bool signedIn = await userService.Login(login);
			// Act
			signedIn.Should().BeTrue();
		}
	}
}
