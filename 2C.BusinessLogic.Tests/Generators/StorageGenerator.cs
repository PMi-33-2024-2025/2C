using _2C.DataAccess.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2C.BusinessLogic.Tests.Generators
{
    public static class StorageGenerator
    {
        public static readonly Faker<Storage> faker = new Faker<Storage>()
            .RuleFor(x => x.Id, f => f.Random.Long(1, 100))
            .RuleFor(x => x.Address, f => f.Address.StreetAddress());

        public static Storage Generate() => faker.Generate();

        public static List<Storage> Generate(int count) => faker.Generate(count);

        public static Storage WithProducts(this Storage storage)
        {
            storage.Products = ProductsGenerator.Generate(new Random().Next(1, 4))
                .WithStorage(storage).ToList();
            return storage;
        }
    }
}
