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
    public class IngridientController : ControllerBase
    {
        private readonly ILogger<BurgerController> _logger;

        public IngridientController(ILogger<BurgerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Ingridient> Get()
        {
            using (BurgerContext context = new BurgerContext())
            {
                return context.Ingridients.ToList();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Ingridient newIngridient)
        {
            using (BurgerContext context = new BurgerContext())
            {
                context.Ingridients.Add(newIngridient);
                context.SaveChanges();
            }

            return Created("/ingridient", newIngridient);
        }

    }

}