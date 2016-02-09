using GloboMart.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboMart.Data
{
    public class ProductRepository : DataRepositoryBase<Product, ProductDataContext>, IProductRepository
    {
        protected override Product AddEntity(ProductDataContext entityContext, Product entity)
        {
            return entityContext.Products.Add(entity);
        }

        protected override Product UpdateEntity(ProductDataContext entityContext, Product entity)
        {
            return (from e in entityContext.Products
                    where e.Id == entity.Id
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Product> GetEntities(ProductDataContext entityContext)
        {
            return from e in entityContext.Products
                   select e;
        }

        protected override Product GetEntity(ProductDataContext entityContext, int id)
        {
            var query = (from e in entityContext.Products
                         where e.Id == id
                         select e);

            var result = query.FirstOrDefault();

            return result;
        }
    }
}
