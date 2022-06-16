using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DemoAPI.Controllers
{
    public class HomeController: ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            var listaProdutos = new List<Product>
            {
                new Product { Id = 1, Name = "Celular Motorola" },
                new Product() { Id = 2, Name = "Celular Samsung" }
            };
            
            return Ok(listaProdutos);
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}