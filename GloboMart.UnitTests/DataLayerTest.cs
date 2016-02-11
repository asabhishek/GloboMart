using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GloboMart.Data;
using System.Collections.Generic;
using GloboMart.Business.Bootstrapper;
using GloboMart.Core.Common;

namespace GloboMart.UnitTests
{
    [TestClass]
    public class DataLayerTest
    {
        [TestInitialize]
        public void Initialize()
        {

            ObjectBase.Container = MefLoader.Init();
        }

        [TestMethod]
        public void test_repository_usage()
        {
            RepositoryTestClass repositoryTest = new RepositoryTestClass();

            IEnumerable<Product> products = repositoryTest.GetProducts();

            Assert.IsTrue(products != null);
        }
    }

    public class RepositoryTestClass
    {
        public RepositoryTestClass()
        {
            ObjectBase.Container.SatisfyImportsOnce(this);

        }

        public RepositoryTestClass(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }
        [Import]
        IProductRepository _ProductRepository;
        
        public IEnumerable<Product> GetProducts()
        {
            IEnumerable<Product> products = _ProductRepository.Get();

            return products;
        }
    }
}
