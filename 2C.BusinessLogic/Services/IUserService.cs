using _2C.DataAccess.DTO;
using _2C.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2C.BusinessLogic.Services
{
	public interface IUserService
	{
		Task<bool> Login(LoginDTO login);
		Task<bool> Register(User user);
	}
}
