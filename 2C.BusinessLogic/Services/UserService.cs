using _2C.DataAccess;
using _2C.DataAccess.DTO;
using _2C.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2C.BusinessLogic.Services
{
	public class UserService : IUserService
	{
		private readonly _2CDbContext context;
		public User CurrentUser { get; set; }

		public UserService(_2CDbContext context)
		{
			this.context = context;
		}

		public async Task<bool> Login(LoginDTO login)
		{
			User? user = await context.Users.FirstOrDefaultAsync(x => x.Email == login.Email).ConfigureAwait(false);
			if (user.Password == login.Password)
			{
				CurrentUser = user;
				return true;
			}
			return false;
		}

		public async Task<bool> Register(User user)
		{
			User? matchingUser = await context.Users.FirstOrDefaultAsync(x => x.Email == user.Email).ConfigureAwait(false);
			if (matchingUser != null)
			{
				return false;
			}
			CurrentUser = user;
			return true;
		}
	}
}
