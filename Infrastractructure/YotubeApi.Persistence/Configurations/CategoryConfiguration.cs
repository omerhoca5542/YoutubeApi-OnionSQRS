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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            Category category1 = new()
            {
                Id = 1,
                Name = "Elektronik",
                Priority = 1,//  burası elektronik gibi menülerin sırasını gösterir örneğin elektronik ile alt kategorisi olan bilgisayar aynı priority numarasında olur
                ParentId = 0,//sitemizde menülerin sırasını göstermek için kullandık  örneğin en üst menüde elektronik menüsü var bunun ParentId si 0 olur altında ise bilgisayar yazıcılar var diyelim bunun parentId si de 1 olur .
                IsDeleted = false,
                CreatedDate = DateTime.Now,

            };
            Category category2 = new()
            {
                Id = 2,
                Name = "Moda",
                Priority = 2,// priority menülerin dikeyde sırası gibi düşünülebilir de .
                ParentId = 0,// parent id ise menülerin yatayda sırası gibi de düşünülebilir
                IsDeleted = false,
                CreatedDate = DateTime.Now,

            };
            Category parent1 = new()
            {

                Id = 3,
                Name = "Bilgisayar",
                Priority = 1,// prioritysi elektronik menüsünün altında yer alacağından elektronikle aynı
                ParentId = 1,// parent id ise elektronik menüsünün alt kategorisi alt menüsü olduğundan 0 rakamından sonraki 1 rakamı olur
                IsDeleted = false,
                CreatedDate = DateTime.Now,

            };
            Category parent2 = new()
            {

                Id = 4,
                Name = "Kadın",
                Priority = 2,// prioritysi elektronik menüsünün altında yer alacağından elektronikle aynı
                ParentId = 1,// parent id ise elektronik menüsünün alt kategorisi alt menüsü olduğundan 0 rakamından sonraki 1 rakamı olur
                IsDeleted = false,
                CreatedDate = DateTime.Now,

            };
            builder.HasData(category1, category2,parent1,parent2);

        }
    }
}
