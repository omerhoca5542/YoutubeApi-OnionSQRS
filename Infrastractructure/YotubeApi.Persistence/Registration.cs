using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YotubeApi.Persistence.Context;

namespace YotubeApi.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services,IConfiguration configuration)// bu yöntemle AddPersistence IServiceCollection nın uzantısı gibi çalışır yani IServiceCollection.AddPersistence 
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString ("DefaultConnection")));// sql server kullanarak appsettings.Development.json dosyasında bulunan DefaultConnection a karşılık gelen connectionstringi seçtik."ConnectionStrings": {
            // tam olarak kodu bu= "DefaultConnection": "Server=PC;Database=YotubeApi;Trusted_Connection=True; "

        }


    }
}
