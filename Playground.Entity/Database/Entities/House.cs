using System.Collections.Generic;

namespace Playground.Entity.Database.Entities
{
    public class House
    {
        public House()
        {
            this.Persons = new HashSet<Person>();
        }

        public int Id { get; set; }
        public int AgeInYears { get; set; }

        public ICollection<Person> Persons { get; set; }
    }
}
