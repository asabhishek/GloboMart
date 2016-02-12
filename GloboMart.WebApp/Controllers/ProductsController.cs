using GloboMart.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Formatting;
using Newtonsoft.Json;

namespace GloboMart.WebApp.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50357/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/product");
                if (response.IsSuccessStatusCode)
                {
                    List<Product> product = await response.Content.ReadAsAsync<List<Product>>();
                    return View(product);
                }
            }

            return View();

        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50357/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(string.Format("api/product/{0}",id));
                if (response.IsSuccessStatusCode)
                {
                  
                    Product product = await response.Content.ReadAsAsync<Product>();

                    using (var aclient = new HttpClient())
                    {
                        aclient.BaseAddress = new Uri("http://localhost:50357/");
                        aclient.DefaultRequestHeaders.Accept.Clear();
                        aclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        HttpResponseMessage aresponse = await aclient.GetAsync(string.Format("api/price/{0}", id));
                        if (aresponse.IsSuccessStatusCode)
                        {

                            Price price = await aresponse.Content.ReadAsAsync<Price>();
                            product.price = price;
                        }
                    }

                    
                    return View(product);
                }
            }
            return View();
        }
        [HttpPost]
    public async Task<ActionResult> RefreshItems(int id) {
        try 
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50357/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(string.Format("api/price/{0}", id));
                if (response.IsSuccessStatusCode)
                {

                    Price price = await response.Content.ReadAsAsync<Price>();
                    return PartialView("_Price", price);
                }
            }
            
        }
        catch (Exception ex) {

            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }

        // GET: Products/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50357/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PostAsJsonAsync("api/product",product);
                    if (response.IsSuccessStatusCode)
                    {
                        Uri gizmoUrl = response.Headers.Location;
                       return RedirectToAction("Index");
                    }
                }
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50357/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync("api/product/"+ id);
                if (response.IsSuccessStatusCode)
                {
                    Uri gizmoUrl = response.Headers.Location;
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
