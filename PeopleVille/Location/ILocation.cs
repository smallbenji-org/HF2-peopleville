using PeopleVille.Persons;

namespace PeopleVille.Locations
{
    public abstract class Location
    {
        public string Name { get; set; }

        public virtual void UseLocation(Person person) {}
    }
}