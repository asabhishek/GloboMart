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
        public DbSet<Price> Prices { get; set; }
    }

    public class ProductInitializer :  DropCreateDatabaseAlways<ProductDataContext>
    {
        //protected override void Seed(ProductDataContext context)
        //{
        //    IList<Category> categories = new List<Category>();
        //    categories.Add(new Category()
        //    {
        //        Id = 1,
        //        Name = "Mobile",
        //        Products = new List<Product>
        //       {
        //           new Product()
        //           {
        //               Id = 1, Name="Samsung Note 2", CategoryId=1, Description="Smart Phone with 2 gb ram and android operating system",
        //               Prices= new List<Price>
        //               {new Price(){
        //                   Id=1, ProductId=1, ActualPrice=30000, OfferPrice=25000
        //               }
        //               }
        //           }
        //       }
        //    });

        //    foreach (Category ctr in categories)
        //        context.Categories.Add(ctr);
        //    base.Seed(context);
        }
    }

