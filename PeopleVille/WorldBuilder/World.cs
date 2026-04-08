using PeopleVille.Equipment;
using PeopleVille.Locations;
using PeopleVille.Persons;

namespace PeopleVille.WorldBuilder
{
    public class World
    {
        public GameManager manager = new();
        public List<IEquipment> Equipment = [];
        public List<Person> People = [];
        public List<Location> Locations = [];
        public GlobalLogger globalLogger = new();
    }
}