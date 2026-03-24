using PeopleVille.Equipment;

namespace PeopleVille.Location
{
    public class Store : Location
    {
        public Dictionary<object, int> Inventory { get; set; }
    }
}