using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Playground.Entity.Database;
using Playground.Entity.Database.Entities;

namespace Playground.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class PersonControllerBase<TContext> : ControllerBase where TContext : BaseDbContext
    {
        public TContext Context { get; }

        protected PersonControllerBase(TContext context)
        {
            this.Context = context;
        }

        [HttpPost]
        public virtual ActionResult Create()
        {
            this.Context.Person.Add(new Person
            {
                Firstname = "Hans",
                Lastname = "Muster",
                Middlename = "",
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
            var person = this.Context.Person.Include(e => e.House).ToList();
            return Ok(person);
        }
    }
}
