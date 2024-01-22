using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Domain.Common;

namespace YoutubeApi.Application.Interfaces.Repositories
{
    public interface IReadRepository<T> where T : class,IEntityBase,new()// bu interface in bir classtan T yani entity almasını istiyorum yine IEntityBase i de kullanmasını istiyorum ve new lenebilir bir yapısı olmasını da ekledim. IEntityBase altı çizili gelirse eğer bu şundan olur. bizim persistance katmanı ile domain katmanı arasında bağ kurmamız için referans olarak domain katmanını vermemiz lazım 
    {
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate= null , Func<IQueryable<T>, IIncludableQueryable<T, object>>? include=null,Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy=null, bool enableTracking=false);// OERDER BYE DA İSTENİLEN alana göre veri tabanından sıralama yapmak için kullanılır
        Task<IList<T>> GetAllByPaggingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false, int currentPage=1, int pageSize=3 );// int currentPage=1, int pageSize=3 kod ile mevcut sayfadan ilk 3 veriyi alır

        Task<T> GetAsync(Expression<Func<T, bool>>? predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false);// predicate  alanını boş bırakmadık çünkü burda GetAsync ile sadece bir veri alacağımızdan ıd değerine göre mesela. bu yüzden predicate boş bırakılamaz
        IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false);// IQueryable veri tabanından verileri geniş kapsamlı sorgulamak için kullanılır.IQueryable arayüzü IEnumarable arayüzünü implement etmektedir. Bu sayede IQuaryable IEnumarable özelliklerinin hepsini barındıracaktır.IQueryable kullanıldığında sorgu alınırken öncelikle filtrelendirme yapılıp sorgu gönderilir.
        Task<int> CountAsync(Expression<Func<T, bool>>? predicate=null);// herhangi bir entity nin sayısını almak için kullanıcaz bu alan boş da bırakılabilir
        // readrepository de ıreadrepository yi kalıtım alabilmek için youtubeapi.persestensa sağ tık yapıp youtubeapi.application nı referans olarak göstermek lazım
    }
}
