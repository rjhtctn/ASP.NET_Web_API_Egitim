﻿using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        void IEntityTypeConfiguration<Book>.Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                    new Book { Id = 1, Title = "Karagöz ve Hacivat", Price = 75 },
                    new Book { Id = 2, Title = "Mesnevi", Price = 175 },
                    new Book { Id = 3, Title = "Devlet", Price = 375 }
                );
        }
    }
}