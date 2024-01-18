using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Domain.Common;

namespace YoutubeApi.Domain.Entities
{
    public class Category:EntitityBase
    {
        public Category()
        {
                
        }
        public Category(int parentid, string name, int priority)
        {
            Name = name;
            Priority = priority;
            ParentId = parentid;
        }
        public required int ParentId { get; set; }// sitemizde menülerin sırasını göstermek için kullandık  örneğin en üst menüde elektronik menüsü var bunun ParentId si 0 olur altında ise bilgisayar yazıcılar var diyelim bunun parentId si de 1 olur .
        public required string Name { get; set; }
        public required int Priority { get; set; }//  burasıda elektronik gibi menülerin sırasını gösterir örneğin elektronik ile alt kategorisi olan bilgisayar aynı priority numarasında olur
        public ICollection<Detail> Details { get; set; }// bir kategorinin birden çok detayı olacağı için bire çok ilişki kurduk
        public ICollection<Product> Products { get; set; }// product entity si ile çoka çok ilşki kurduk. hem bazı product yani ürünlerde birden çok kategori var hem de bir kategoride birden  fazla ürün olduğundan
    }
}
