using _2C.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data.SqlClient;

string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=EnterpriseDB;timeout=300;CommandTimeout=300;";

static void SeedStorages(string connectionString)
{
	using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
	{
		connection.Open();
		IEnumerable<string> addresses = new List<string>()
	{
		"Birmingham",
		"London",
		"Berlin",
		"Paris"
	};
		foreach (var address in addresses)
		{
			using (NpgsqlCommand command = new NpgsqlCommand($"INSERT INTO public.\"Storages\"(\"Address\") VALUES ('{address}')", connection))
			{
				int result = command.ExecuteNonQuery();
				Console.WriteLine($" record with address {address} was inserted into Storages");
			}
		}
	}
}

static void SeedUsers(string connectionString)
{
	using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
	{
		connection.Open();
		IEnumerable<User> users = new List<User>()
	{
		new User(){Id=new Guid("CC208782-1F6D-4E93-9DED-B191B09B6684"), Name="John", LastName="Peters", Email="john123@gmail.com", Password="ab123123", StorageId=1, RoleId=1},
		new User(){Id=new Guid("E516C018-6D67-4D0D-91C0-601A98A91636"), Name="Jack", LastName="Adams", Email="jackAdm@gmail.com", Password="1bc4e123", StorageId=1, RoleId=2},
		new User(){Id=new Guid("B9037EC7-C13D-47DD-AEC6-6670300A1A6A"), Name="Peter", LastName="Parker", Email="petpark@gmail.com", Password="ab2de123", StorageId=2, RoleId=2},
		new User(){Id=new Guid("CBD695E9-CC5F-40A9-A020-C60643314B64"), Name="Thomas", LastName="Jeferson", Email="thmjef@gmail.com", Password="1bcde123",StorageId=1, RoleId=1},
		new User(){Id=new Guid("CD72CC53-3AEB-4064-B348-2F4CA252ECF8"), Name="George", LastName="Washinghton",  Email="washinghton@gmail.com",Password="abcde123", StorageId=2, RoleId=1},
	};
		foreach (var user in users)
		{
			using (NpgsqlCommand command = new NpgsqlCommand($"INSERT INTO public.\"Users\" VALUES ('{user.Id}', '{user.Name}', '{user.LastName}', '{user.Email}', '{user.Password}', {user.StorageId}, {user.RoleId})", connection))
			{
				int result = command.ExecuteNonQuery();
				Console.WriteLine($"record with Guid {user.Id} was inserted into Users");
			}
		}
	}
}

static void SeedProducts(string connectionString)
{
	using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
	{
		connection.Open();
		IEnumerable<Product> products = new List<Product>()
	{
		new Product(){Id=new Guid("20B2D510-4F04-45BF-A6E5-303E08D7CC5E"), Name="Avocado", Price=70, Quantity=100_000, StorageId=2 },
		new Product(){Id=new Guid("0C119000-528F-4405-9B1F-891EDC41AF3A"), Name="Cherry", Price=50, Quantity=300_000, StorageId=1 },
		new Product(){Id=new Guid("89EF7A78-613B-4B09-8115-F05541F9BC18"), Name="Orange", Price=45, Quantity=200_000, StorageId=2 },
		new Product(){Id=new Guid("5715D418-D7D4-4160-86ED-BE5F099D4716"), Name="Grapes", Price=30, Quantity=150_000, StorageId=1 },
		new Product(){Id=new Guid("B794D4BB-096F-4363-B8C1-9EC2AE9DC8F4"), Name="Blackberry", Price=40, Quantity=240_000, StorageId=1 },
		new Product(){Id=new Guid("A40CBB31-643D-4D91-9758-46E46EC75ECB"), Name="Melon", Price=80, Quantity=400_000, StorageId=2 }
	};
		foreach (var product in products)
		{
			using (NpgsqlCommand command = new NpgsqlCommand($"INSERT INTO public.\"Products\" VALUES ('{product.Id}', '{product.Name}', {product.Price}, {product.Quantity}, {product.StorageId})", connection))
			{
				int result = command.ExecuteNonQuery();
				Console.WriteLine($"record with Guid {product.Id} was inserted into Products");
			}
		}
	}
}

static void OutputTable(string connectionString, string table)
{
	using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
	{
		connection.Open();
		using (NpgsqlCommand command = new NpgsqlCommand($"SELECT * FROM public.\"{table}\" ", connection))
		{
			using (NpgsqlDataReader reader = command.ExecuteReader())
			{
				string columns = string.Join(" | ", reader.GetColumnSchema().Select(x => x.ColumnName));
				Console.WriteLine(columns);
				while (reader.Read())
				{
					for (int i = 0; i < reader.GetColumnSchema().Count - 1; i++)
					{
						Console.Write(reader.GetValue(i) + " | ");
					}
					Console.WriteLine(reader.GetValue(reader.GetColumnSchema().Count - 1));
				}
			}
		}
	}
}

static void OutputProducts(string connectionString)
{
	OutputTable(connectionString, "Products");
}

static void OutputStorages(string connectionString)
{
	OutputTable(connectionString, "Storages");
}

static void OutputRoles(string connectionString)
{
	OutputTable(connectionString, "Roles");
}

static void OutputUsers(string connectionString)
{
	OutputTable(connectionString, "Users");
}

///Uncomment this to seed Data
///
//SeedStorages(connectionString);
//SeedUsers(connectionString);
//SeedProducts(connectionString);

OutputStorages(connectionString);
OutputProducts(connectionString);
OutputUsers(connectionString);
OutputRoles(connectionString);


