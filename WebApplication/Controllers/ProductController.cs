using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.Models;
using WebApplication.Helper;
using WebApplication.Models;
using Product = WebApplication.Models.Product;

namespace WebApplication.Controllers
{
    public class ProductController : Controller
    {
        ProductAPI _productapi = new ProductAPI();
        // GET: /<controller>/
        public async Task<IActionResult> ProductList()
        {
            List<Product> product = new List<Product>();
            HttpClient client = _productapi.Initial();
            HttpResponseMessage res = await client.GetAsync("/api/product");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<List<Product>>(result);
            }
            return View(product);
        }
    }
}
