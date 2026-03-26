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
            if (person.Inventory.OfType<Gun>().Any())
                return;

            if (person.Money >= 800)
            {
                person.Money -= 800;
                person.Inventory.Add(new Gun { Name = "Shotgun", Damage = 50 });
                Console.WriteLine($"{person.Name} køber Shotgun for 800 kr. i {Name}");
            }
            else if (person.Money >= 500)
            {
                person.Money -= 500;
                person.Inventory.Add(new Gun { Name = "Riffel", Damage = 30 });
                Console.WriteLine($"{person.Name} køber Riffel for 500 kr. i {Name}");
            }
            else if (person.Money >= 200)
            {
                person.Money -= 200;
                person.Inventory.Add(new Gun { Name = "Pistol", Damage = 15 });
                Console.WriteLine($"{person.Name} køber Pistol for 200 kr. i {Name}");
            }
        }
    }
}