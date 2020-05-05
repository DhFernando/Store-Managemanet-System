using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWithVue.Models.Advertistment
{
    public class Advertistment
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public DateTime BirthDay { get; set; }
        public String Department { get; set; }
    }
}
