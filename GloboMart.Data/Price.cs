using GloboMart.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboMart.Data
{
    public class Price : IIdentityEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public double ActualPrice { get; set; }
        public double OfferPrice { get; set; }
    }
}
