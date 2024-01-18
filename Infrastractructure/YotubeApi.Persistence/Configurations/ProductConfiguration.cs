using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Domain.Entities;

namespace YotubeApi.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
          
            Faker faker = new ("tr");
            Product product1 = new()
            {
            Id = 1,
            BrandId = 1,// brand yani marka entitys ile ilşkili
            Title=faker.Commerce.ProductName(),// fakerın productname özelliğini kullandık
            Description=faker.Commerce.ProductDescription(),
            CreatedDate = DateTime.Now,
            IsDeleted=false,

            };
            Product product2 = new()
            {
                Id = 2,
                BrandId = 3,// brand yani marka entitys ile ilşkili
                Title = faker.Commerce.ProductName(),// fakerın productname özelliğini kullandık
                Description = faker.Commerce.ProductDescription(),
                CreatedDate = DateTime.Now,
                IsDeleted = false,

            };
            builder.HasData(product1,product2);
        }
    }
}
