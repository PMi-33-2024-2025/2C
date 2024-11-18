using _2C.DataAccess;
using _2C.DataAccess.DTO;
using _2C.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

		public async Task<bool> Login(LoginDto login)
		{
			User? user = await context.Users.FirstOrDefaultAsync(x => x.Email == login.Email).ConfigureAwait(false);
			if (user != null && user.Password == login.Password)
			{
				CurrentUser = user;
				return true;
			}
			return false;
		}

        public async Task<bool> Register(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            // Check if the user already exists based on the unique Email
            var existingUser = await context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (existingUser != null)
            {
                return false; // User already exists, return false
            }

            // Add the new user and save changes
            context.Users.Add(user);
            var result = await context.SaveChangesAsync();

            return result > 0; // Returns true if the user was successfully added
        }
        public void Logout()
        {
            CurrentUser = null; // Clear the current user session
        }
    }
}
