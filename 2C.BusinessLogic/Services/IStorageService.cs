using _2C.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2C.BusinessLogic.Services
{
	public interface IStorageService
	{
		public Task Create(Storage storage);
		public Task<IEnumerable<Storage>> GetAll();
		public Task<Storage> GetById(long id);
		public Task Update(long id, string address);
		public Task Delete(long id);
	}
}
