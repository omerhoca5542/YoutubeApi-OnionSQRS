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
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            Faker faker = new("tr");
            Detail detail1 = new Detail()
            {
                Id = 1,
                CategoryId = 1,
                Title = faker.Lorem.Sentence(1),// başlık için faker ile rastgele bir yazı oluşturduk
                Description = faker.Lorem.Sentence(5),
                IsDeleted = false,
                CreatedDate = DateTime.Now,


            };
            Detail detail2 = new Detail()
            {
                Id = 2,
                CategoryId = 3,
                Title = faker.Lorem.Sentence(1),// başlık için faker ile rastgele bir yazı oluşturduk
                Description = faker.Lorem.Sentence(5),
                IsDeleted = true,
                CreatedDate = DateTime.Now,


            };
            Detail detail3 = new Detail()
            {
                Id = 3,
                CategoryId = 4,
                Title = faker.Lorem.Sentence(1),// başlık için faker ile rastgele bir yazı oluşturduk
                Description = faker.Lorem.Sentence(5),
                IsDeleted = false,
                CreatedDate = DateTime.Now,


            };
            builder.HasData(detail1, detail2, detail3);
           
        }
    }
}
