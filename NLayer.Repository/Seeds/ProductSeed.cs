using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasData(new Product
			{
				Id = 1,
				CategoryId = 1,
				Name = "Defter1",
				Price = 100,
				Stock = 20,
				CreatedDate = DateTime.Now,

			}, new Product
			{
				Id = 2,
				CategoryId = 1,
				Name = "Defter2",
				Price = 200,
				Stock = 30,
				CreatedDate = DateTime.Now,

			}, new Product
			{
				Id = 3,
				CategoryId = 1,
				Name = "Defter3",
				Price = 400,
				Stock = 10,
				CreatedDate = DateTime.Now,

			},
			new Product
			{
				Id = 4,
				CategoryId = 2,
				Name = "Kalem1",
				Price = 600,
				Stock = 60,
				CreatedDate = DateTime.Now,

			},
			new Product
			{
				Id = 5,
				CategoryId = 2,
				Name = "Kalem2",
				Price = 400,
				Stock = 40,
				CreatedDate = DateTime.Now,

			},
			new Product
			{
				Id = 6,
				CategoryId = 2,
				Name = "Kalem3",
				Price = 800,
				Stock = 80,
				CreatedDate = DateTime.Now,

			}
			);
		}
	}
}
