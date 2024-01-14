using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Domain.Common;

namespace YoutubeApi.Domain.Entities
{
    public class Product:EntitityBase// ürün entitysi
    {
        public string  Title { get; set; }          
        public string Description { get; set; }
        public int  BrandId { get; set; }// her ürünün bir markası olacağından bu kısmı kullandık
        public decimal Price { get; set; }// ürünün fiyat bilgisi
        public int Discount { get; set; }// ürünün indirim kısmı
        public Brand Brand { get; set; }// marka ile bire bir ilişki kurduk
        public ICollection<Category> Categories { get; set; }// category ile çoka çok ilişki kurduk aynısını Category entitysindede yapıcaz . burda örnel bir tablet arıcaz tableti hem elektronik hem de bilgisayar kategorisinde bulabilmeliyim. o yüzden bir ürünün birdden fazla kategorisi olabilmeli
    }
}
