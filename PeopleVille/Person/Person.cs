using PeopleVille.Equipment;
using PeopleVille.Locations;

namespace PeopleVille.Persons
{
    public abstract class Person
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public List<IEquipment> Inventory { get; set; } = new List<IEquipment>(); // hellere at de starter med tomt inventory end et inventory der ikke eksisterer.
        public object Location { get; set; }
        public int Money { get; set; }
        public int Age { get; set; }
        public Location CurrentLocation { get; set; }
       

        public void Walk(Location newLocation)
        {
            this.CurrentLocation = newLocation;
        }
    }
}