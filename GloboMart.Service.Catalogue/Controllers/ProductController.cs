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
    public class ProductController : ApiController
    {
        [Import]
        private IProductRepository _rep;
        public ProductController( )
        {
           // _rep = new ProductRepository();
            ObjectBase.Container.SatisfyImportsOnce(this);
        }
        public IEnumerable<Product> Get()
        {
            return _rep.Get();
        }

        // GET: api/Product/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
