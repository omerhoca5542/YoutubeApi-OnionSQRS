using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Domain.Common;

namespace YoutubeApi.Application.Interfaces.Repositories// eklenen verilerin kontrolünün yapıldığı repository yapısı
{
    public interface IWriteRepository<T> where T : class, IEntityBase, new()
    {
        Task AddAsync(T entity);// t yi entity olarak kullanmak için yukarda t yi class olarak tanımladık
        Task AddRangeAsync(IList<T> entities);// EKLEME İŞLEMİNİ ARALIKTA BİR DEĞERDEKİ ELEMANLAR İÇİN YAPACAK
        Task<T> UpdateAsync(T entity);// update ettiğimiz veriyi geri döndürmek için bu yapıyı kullanıcaz

        Task<T> HardDeleteAsync(T entity);// bi veriyi tamamen silmek için 

        

    }
}
