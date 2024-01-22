using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Application.Interfaces.Repositories;
using YoutubeApi.Domain.Common;

namespace YotubeApi.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext dbContext;

        public WriteRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        private DbSet<T> Table { get => dbContext.Set<T>(); }// bizim dbcontexten gelen metotlara ulaşmamızı kolaylaştırmak için Table adında nesne tanımladık her metotu get yaptığımızda yani çağırdığımızda dbcontexten set olacak yani metotlar direk karşıma gelecek

        public async  Task AddAsync(T entity)// burada ekleme işlemini saveasync ten sonra yapmadığımız için unitofwork yapısını kullanacağımızdan tasktan sonra <int> kullanamayız
        {
           await Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        public async Task<T> UpdateAsync(T entity)// update işleminde async yani assenkron yapısını kullanamayız çünkü güncelleme işlemi sırasında arka planda assenkron çalışabilcek bi işlem yok.onun yerine assenkron yapıya uygun yapıda bi yapı oluşturuyoruz. unutmadan Task<T> işlemindeki T değeri geri dönen bir değer olduğunu gösterir. örnek void int dediğimizde de bir integer değer döndüğünü göstermesi gibi
        {
            await Task.Run(()=>Table.Update(entity));// assenkron yapıya uygun yapı oluşturduk??
            return entity;
        }
        public async Task HardDeleteAsync(T entity)// silme işleminde herhangi bir geri değer döndürme olmaz
        {
            await Task.Run(() => Table.Remove(entity));
        }

        public Task<T> SoftDeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
