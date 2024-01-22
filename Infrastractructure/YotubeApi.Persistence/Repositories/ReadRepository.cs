using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Application.Interfaces.Repositories;
using YoutubeApi.Domain.Common;

namespace YotubeApi.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class ,IEntityBase, new()
    {
        private readonly DbContext dbContext;

        public ReadRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        private DbSet<T> Table { get=> dbContext.Set<T>(); }// bizim dbcontexten gelen metotlara ulaşmamızı kolaylaştırmak için Table adında nesne tanımladık her metotu get yaptığımızda yani çağırdığımızda dbcontexten set olacak yani metotlar direk karşıma gelecek
                                                            // 
        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
        {
           IQueryable<T> queryable = Table;
            
            //  Table ile dbcontextten gelen verileri IQuaryable türünde yani sorgu olarak aldık
            // Entity Framework, bir sorgu neticesinde döndürülen tüm nesneleri izlemeye almakta ve bu nesneler üzerindeki tüm değişiklikleri bu şekilde takip edebilmektedir. İşte bu takip sayesinde ilgili nesneler üzerinde yapılan tüm değişiklikleri “SaveChanges” metodu sayesinde veritabanına yansıtabilmektedir.takip işlemine tracking diyoruz. 
            if(!enableTracking) queryable= queryable.AsNoTracking();//eğer güncelleme silme gibi işlemler yapmıcaksak takip işlemini projenin performansı azalmasın diyeasnotracking ile sonlandırıyoruz 
            if (include is not null) queryable = include(queryable);
            if(predicate is not null) queryable = queryable.Where(predicate);// predicate den veri geliyosa getir
            if(orderBy is not null)// orderby yani sıralamadan veri geliyosa
            
                return await orderBy(queryable).ToListAsync();// onu return etmemiz yani döndürmemiz ve göndermemiz gerekir ve bunu liste halinde göndericez
                return await queryable.ToListAsync();// diğer türlü quaryble dan gelenleri listeleticez

            


        }
        public async Task<IList<T>> GetAllByPaggingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();//eğer güncelleme silme gibi işlemler yapmıcaksak takip işlemini projenin performansı azalmasın diyeasnotracking ile sonlandırıyoruz 
            if (include is not null) queryable = include(queryable);
            if (predicate is not null) queryable = queryable.Where(predicate);// predicate den veri geliyosa getir
            if (orderBy is not null)// orderby yani sıralamadan veri geliyosa

                return await orderBy(queryable).Skip((currentPage-1)*pageSize).Take(pageSize).ToListAsync();// sayfaya göre listeleme yapan bir komut . bakılması lazım
            return await queryable.Skip((currentPage-1)*pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>>? predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();//eğer güncelleme silme gibi işlemler yapmıcaksak takip işlemini projenin performansı azalmasın diyeasnotracking ile sonlandırıyoruz 
            if (include is not null) queryable = include(queryable);
            //queryable = queryable.Where(predicate);// predicate çoğul olarak alınmadığından getasync ile bu yüzden predicate not null mu diye bakılmaz o yüzden gelen predicati direk alıyoruz
            
               
            return await queryable.FirstOrDefaultAsync();// yukarıda tek bir veri alacağımızdan firstordefault kullandık burda ilk yada default olan veriyi getiricek ve onu döndürecek
        }
        public async  Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            Table.AsNoTracking().CountAsync(predicate);// gelen verilerde izleme istemiyoruz 
            if (Table is not null) Table.Where(predicate);// predicate boş değilse predicate i getir
            return await Table.CountAsync();// table ile gelen countasync metodunu  direk gönder
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking=false)
        {

            if (!enableTracking) Table.AsNoTracking();
            return Table.Where(predicate);

        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
