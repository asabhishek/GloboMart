using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GloboMart.WebApp.Models
{
    public class Price 
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public double ActualPrice { get; set; }
        public double OfferPrice { get; set; }
    }
}