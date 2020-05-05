using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWithVue.Models.Advertistment
{
    public interface IAdvertistment
    {
        IEnumerable<Categories> GetAllCategories();
    }
}
