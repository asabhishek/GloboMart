using GloboMart.Data;
using System.ComponentModel.Composition.Hosting;
using GloboMart.Business.Bootstrapper;
namespace GloboMart.Business.Bootstrapper
{
    public static class MefLoader
    {
        
        public static CompositionContainer Init()
        {
            AggregateCatalog catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(ProductRepository).Assembly));

            CompositionContainer container = new CompositionContainer(catalog);
            return container;
        }
    }
}
