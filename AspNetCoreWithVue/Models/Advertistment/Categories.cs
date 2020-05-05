using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWithVue.Models.Advertistment
{
    public class Categories
    {
        public int Id { get; set; }
        public String CategoryType { get; set; }
        public String MainCategory { get; set; }
        public String CategoryName { get; set; }
        public String CreatorId { get; set; }
    }
}
