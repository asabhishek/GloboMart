using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboMart.Data
{
    public class ProductDataContext : DbContext
    {
        //public ProductDataContext()
        //    : base("name=MyContext")
        //{
        //    Database.SetInitializer<ProductDataContext>(null);
        //}

        public ProductDataContext()
        {
            Database.SetInitializer<ProductDataContext>(new ProductInitializer());
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }

    public class ProductInitializer :  DropCreateDatabaseIfModelChanges<ProductDataContext>
    {
        protected override void Seed(ProductDataContext context)
        {
            IList<Category> categories = new List<Category>();
            categories.Add(new Category()
            {
                Id = 1,
                Name = "Clothing",
                Products = new List<Product>
               {
                   new Product()
                   {
                       Id = 1, Name="Jeans", CategoryId=1, Price=400
                       
                   }
               }
            });

            foreach (Category ctr in categories)
                context.Categories.Add(ctr);
            base.Seed(context);
        }
    }
}
