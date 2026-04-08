using PeopleVille.Persons;

namespace PeopleVille.Equipment
{
    public class Food : IEquipment
    {
        public required string Name { get; set; }
        public int HealthPoints { get; set; }

        public void Equip()
        {
        }

        public void Unequip()
        {
        }

        public void Use(Person person)
        {
            person.Health += HealthPoints;
            var message = $"{person.Name} spiste og healede {HealthPoints}";
            person.World?.globalLogger.LogEvent(person, message);
            person.Inventory.Remove(this);
        }
    }
}
