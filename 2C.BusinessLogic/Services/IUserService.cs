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
        User CurrentUser { get; set; }

        Task<bool> Login(LoginDto login);
        void Logout();
        Task<bool> Register(User user);
	}
}
