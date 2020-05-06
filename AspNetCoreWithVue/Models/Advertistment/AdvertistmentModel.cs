using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWithVue.Models.Advertistment
{
    public class AdvertistmentModel
    {
        public int Id { get; set; }
        public String Item { get; set; }
        public String Price { get; set; }
        public String MainCategory { get; set; }
        public String SubCategory { get; set; }
        public String CreatorId { get; set; }
    }
}
