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

        public bool NeedsTarget()
        {
            return false;
        }

        public void Unequip()
        {
        }

        public void Use(Person user, Person target)
        {
            target.Health += HealthPoints;
            var message = $"{target.Name} spiste og healede {HealthPoints}";
            target.World?.globalLogger.LogEvent(user, message);
            target.Inventory.Remove(this);
        }
    }
}
