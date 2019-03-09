namespace Playground.Entity.Database.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }

        public virtual House House { get; set; }
    }
}
