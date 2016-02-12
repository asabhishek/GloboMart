using GloboMart.Core.Common;
using GloboMart.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GloboMart.Service.Catalogue.Controllers
{
    public class PriceController : ApiController
    {
        [Import]
        private IPriceRepository _prep;
        public PriceController()
        {
           // _rep = new ProductRepository();
            ObjectBase.Container.SatisfyImportsOnce(this);
        }
        public Price Get(int id)
        {
            return _prep.Get(id);
        }
    }
}
