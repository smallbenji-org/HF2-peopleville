using PeopleVille.Equipment;
using PeopleVille.Locations;
using PeopleVille.WorldBuilder;

namespace PeopleVille.Persons
{
    public abstract class Person
    {
        public string Name { get; set; }
        public int Health { get; set; }

        // hellere at de starter med tomt inventory end et inventory der ikke eksisterer.
        public List<IEquipment> Inventory { get; set; } = [];

        public object Location { get; set; }
        public int Money { get; set; }
        public int Age { get; set; }
        public Location CurrentLocation { get; set; }

        public GameManager Manager { get; set; }
        public World World { get; set; }

        public virtual void Initialize() { }

        public void Walk(Location newLocation)
        {
            this.CurrentLocation = newLocation;
        }
    }
}