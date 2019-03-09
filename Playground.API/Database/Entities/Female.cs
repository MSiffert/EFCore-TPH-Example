using Playground.Entity.Database.Entities;

namespace Playground.API.Database.Entities
{
    public class Female : Person
    {
        public bool? IsPregnant { get; set; }
    }
}
