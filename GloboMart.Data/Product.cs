using GloboMart.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboMart.Data
{
   public  class Product : IIdentityEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
       
    }
}
