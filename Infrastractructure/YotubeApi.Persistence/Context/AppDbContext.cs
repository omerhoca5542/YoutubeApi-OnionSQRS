using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Domain.Entities;

namespace YotubeApi.Persistence.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {
                
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//bizim persistense katmanında yani assemmlysinde tanımladığımız brand category gibi configuration sayfalarımız var onları burada almak için bu kodu kullandık. .net core o dosyaları otomatik alacaktır.
            // persistense katmanına manage nuggetstan entityframework sql ve tool katmanlarını 
//yüklememiz


        }
    }
}
