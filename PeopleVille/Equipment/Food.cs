using PeopleVille.Persons;

namespace PeopleVille.Equipment
{
    public class Food : IEquipment
    {
        public required string Name { get; set; }
        public int HealthPoints { get; set; }

        public void Equip()
        {
            Console.WriteLine("");
        }

        public void Unequip()
        {
            Console.WriteLine("");
        }

        public void Use(Person person)
        {
            person.Health += HealthPoints;
            Console.WriteLine($"{person.Name} spiste og healede {HealthPoints}");
            person.Inventory.Remove(this);
        }
    }
}
