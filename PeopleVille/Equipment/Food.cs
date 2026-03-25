using PeopleVille.Person;

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

        public void Consume(Person.Person person)
        {
            person.Health += HealthPoints;
            Console.WriteLine($"");
            person.Inventory.Remove(this);
        }
    }
}
