using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWithVue.Models.Advertistment
{
    public class SQLAdvertistment : IAdvertistment
    {
        private readonly AppDbContext context;
        public SQLAdvertistment(AppDbContext context)
        {
            this.context = context;
        }

        
        public IEnumerable<Categories> GetAllCategories()
        {
            return context.Categories;
        }

        public IEnumerable<AdvertistmentModel> GetAllAdvertistments()
        {
            return context.Advertistment;
        }

        public AdvertistmentModel Add(AdvertistmentModel advertistment)
        {
            context.Add(advertistment);
            context.SaveChanges();
            return advertistment;
        }
    }
}
