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
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>// burda brand entitysini vermek için Persistence katmanında sağ tık yapıp referans olarak domaini vermemiz lazım
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x=>x.Name).HasMaxLength(256);//Name propertysini 256 karakteri geçmicek şekilde aldık
            Faker faker = new("tr");//Bogus adında bir kütüphaneyi nugete olarak ekledi . burda ise türkçe içerikler  oluşturmak için kullanıcağız

            Brand brand1 = new()
            {
                Id = 1,
                Name = faker.Commerce.Department(),// departman bilgisi aldık
                CreatedDate = DateTime.Now,//zaman bilgisi aldık
                IsDeleted = false,// dosyanın silinme bilgisini false aldık
            };
            Brand brand2 = new()
            {
                Id = 2,
                Name = faker.Commerce.Department(),
                IsDeleted = false,
                CreatedDate = DateTime.Now,
            };
            Brand brand3 = new()
            {
                Id = 3,
                Name = faker.Commerce.Department(),
                CreatedDate = DateTime.Now,
                IsDeleted = true// burda ise silinen dosya varsa onun bilgisini görebilmek için true aldık
            };
            builder.HasData(brand1, brand2, brand3);// bu bilgileri burada alıp test edicez.builder nesnesinin HasData metodu üzeriden bu verileri veritabanına ekliyoruz
        }
    }
}
