using GloboMart.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboMart.Data
{
    [Export(typeof(IPriceRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PriceRepository : DataRepositoryBase<Price, ProductDataContext>, IPriceRepository
    {
        protected override Price AddEntity(ProductDataContext entityContext, Price entity)
        {
            return entityContext.Prices.Add(entity);
        }

        protected override Price UpdateEntity(ProductDataContext entityContext, Price entity)
        {
            return (from e in entityContext.Prices
                    where e.Id == entity.Id
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Price> GetEntities(ProductDataContext entityContext)
        {
            return from e in entityContext.Prices
                   select e;
        }

        protected override Price GetEntity(ProductDataContext entityContext, int id)
        {
            var query = (from e in entityContext.Prices
                         where e.ProductId == id
                         select e);

            var result = query.FirstOrDefault();

            return result;
        }

    }
}
