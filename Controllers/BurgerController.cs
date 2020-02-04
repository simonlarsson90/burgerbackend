using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backendproject.Context;
using backendproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace backendproject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BurgerController : ControllerBase
    {
        private readonly ILogger<BurgerController> _logger;

        public BurgerController(ILogger<BurgerController> logger)
        {
            _logger = logger;
        }

        
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            using (BurgerContext context = new BurgerContext())
            {
                return context.Products.ToList();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product newProduct)
        {
            using (BurgerContext context = new BurgerContext())
            {
                context.Products.Add(newProduct);
                context.SaveChanges();
            }

            return Created("/burger", newProduct);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product p)
        {
            using (BurgerContext context = new BurgerContext())
            {
                Product toUpdate = context.Products.First(p => p.Id == id);

                toUpdate.Price = p.Price;
                toUpdate.Burger = p.Burger;

                context.SaveChanges();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (BurgerContext context = new BurgerContext())
            {
                Product toRemove = context.Products.First(p => p.Id == id);

                context.Products.Remove(toRemove);

                context.SaveChanges();
            }

            return Ok();
        }
    }
}