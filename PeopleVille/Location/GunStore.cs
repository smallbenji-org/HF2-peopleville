using PeopleVille.Equipment;
using PeopleVille.Persons;

namespace PeopleVille.Locations
{
    public class GunStore : Store
    {
        public GunStore()
        {
            Inventory = new Dictionary<object, int>
            {
                { new Gun { Name = "Pistol",  Damage = 15 }, 200 },
                { new Gun { Name = "Riffel",  Damage = 30 }, 500 },
                { new Gun { Name = "Shotgun", Damage = 50 }, 800 },
            };
        }

        public override void UseLocation(Person person)
        {
            /*if (person.Inventory.OfType<Gun>().Any())
                return;*/

            if (person.Money >= 800 && person.Inventory.Count < 5)
            {
                person.Money -= 800;
                person.TryAddToInventory(new Gun { Name = "Shotgun", Damage = 50 });
                var message = $"Købte Shotgun for 800 kr. i {Name}";
                person.World?.globalLogger.LogEvent(person, message);
            }
            else if (person.Money >= 500 && person.Inventory.Count < 5)
            {
                person.Money -= 500;
                person.TryAddToInventory(new Gun { Name = "Riffel", Damage = 30 });
                var message = $"Købte Riffel for 500 kr. i {Name}";
                person.World?.globalLogger.LogEvent(person, message);
            }
            else if (person.Money >= 200 && person.Inventory.Count < 5)
            {
                person.Money -= 200;
                person.TryAddToInventory(new Gun { Name = "Pistol", Damage = 15 });
                var message = $"Købte Pistol for 200 kr. i {Name}";
                person.World?.globalLogger.LogEvent(person, message);
            }
        }
    }
}