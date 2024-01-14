using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Domain.Common;

namespace YoutubeApi.Domain.Entities
{
    public  class Detail:EntitityBase// detail entitysi satılan her ürünün kategorisine göre özllikleri farklı olacağından biz burda kategoriye göre özellik tanımlıcaz.örneğin bilgisayar için ram ekran kartı özellikse masa için en boy malzeme kısmı özelliktir
    {
        public Detail()
        {
                
        }
        public Detail(string title,string description,int categoryId)
        {
            Title = title;
            Description = description;
            CategoryId = categoryId;
        }
        public required string Title { get; set; }// ttitle ise  malın kategorisine ait özellik ismi olacak
        public required string Description { get; set; }// tanımlama kısmı 
        public required int CategoryId { get; set; }// mürünlerin kategorisini alıcaz ki ona göre özellikler gelsin 
        public Category Category { get; set; }//Bir detayın sadece bir tane kategorisi olacağı için bire bir ilişkilendirme yaptık
    }
}
