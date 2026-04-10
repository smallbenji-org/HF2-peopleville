using PeopleVille.Equipment;
using PeopleVille.Persons;

namespace PeopleVille.Locations
{
    public class EggStore : Store
    {
        public override void UseLocation(Person person)
        {
            if (person.Money >= 100 && person.Inventory.Count < 5)
            {
                person.Money -= 100;
                person.TryAddToInventory(new Food { Name = "Bakke Æg", HealthPoints = 60 });
                var message = $"Købte Bakke Æg for 100 kr. i {Name}";
                person.World?.globalLogger.LogEvent(person, message);
            }
            else if (person.Money >= 20 && person.Inventory.Count < 5)
            {
                person.Money -= 20;
                person.TryAddToInventory(new Food { Name = "Æg", HealthPoints = 10 });
                var message = $"Købte Æg for 20 kr. i {Name}";
                person.World?.globalLogger.LogEvent(person, message);
            }
        }
    }
}