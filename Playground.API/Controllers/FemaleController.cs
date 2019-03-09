using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Playground.API.Database;
using Playground.API.Database.Entities;
using Playground.Entity.Database.Entities;

namespace Playground.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FemaleController : ControllerBase
    {
        public FemaleDbContext Context { get; }

        public FemaleController(FemaleDbContext context)
        {
            this.Context = context;
        }

        [HttpPost]
        public ActionResult Create()
        {
            this.Context.Person.Add(new Female  
            {
                Firstname = "Hans",
                Lastname = "Muster",
                Middlename = "",
                IsPregnant = true,
                House = new House
                {
                    AgeInYears = 4
                }
            });

            this.Context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var females = this.Context.Female.Include(e => e.House).ToList();

            return Ok(females);
        }
    }
}
