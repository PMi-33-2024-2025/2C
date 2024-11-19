using _2C.DataAccess;
using _2C.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace _2C.BusinessLogic.Services
{
	public class StorageService : IStorageService
	{
		private readonly _2CDbContext context;

		public StorageService(_2CDbContext context)
		{
			this.context = context;
		}
		public async Task Create(Storage storage)
		{
			await context.AddAsync(storage).ConfigureAwait(false);
			await context.SaveChangesAsync();
		}

		public async Task Delete(long id)
		{
			var storageToRemove = await context.Storages.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);

			if (storageToRemove == null)
				throw new NullReferenceException(nameof(storageToRemove));
			context.Storages.Remove(storageToRemove);

			await context.SaveChangesAsync().ConfigureAwait(false);
		}

		public async Task<IEnumerable<Storage>> GetAll()
		{
			return await context.Storages.ToListAsync().ConfigureAwait(false);
		}

		public async Task<Storage> GetById(long id)
		{
			return await context.Storages.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
		}

		public async Task Update(long id, string address)
		{
			var storage = await context.Storages.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);

			if (storage == null)
			{
				throw new ArgumentOutOfRangeException(nameof(id));
			}

			storage.Address = address;
			await context.SaveChangesAsync().ConfigureAwait(false);
		}
	}
}
