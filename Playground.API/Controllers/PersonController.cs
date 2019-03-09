using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Playground.API.Database;
using Playground.Controllers;

namespace Playground.API.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : PersonControllerBase<FemaleDbContext>
    {
        public PersonController(FemaleDbContext context) : base(context) { }
    }
}
