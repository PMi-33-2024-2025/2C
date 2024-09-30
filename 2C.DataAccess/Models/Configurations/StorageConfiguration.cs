﻿using _2C.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2C.DataAccess.Configurations
{
    public class StorageConfiguration : IEntityTypeConfiguration<Storage>
    {
        public void Configure(EntityTypeBuilder<Storage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Users)
                .WithOne(x => x.Storage);

            builder.HasMany(x => x.Products)
                .WithOne(x => x.Storage);
        }
    }
}