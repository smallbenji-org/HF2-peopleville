using PeopleVille.Equipment;
using PeopleVille.Persons;

namespace PeopleVille.Locations
{
    public class EggStore : Store
    {
        public override void UseLocation(Person person)
        {
            if (person.Money >= 100)
            {
                person.Money -= 100;
                person.TryAddToInventory(new Food { Name = "Bakke Æg", HealthPoints = 60 });
                Console.WriteLine($"{person.Name} køber Bakke Æg for 100 kr. i {Name}");
            }
            else if (person.Money >= 20)
            {
                person.Money -= 20;
                person.TryAddToInventory(new Food { Name = "Æg", HealthPoints = 10 });
                Console.WriteLine($"{person.Name} køber Æg for 20 kr. i {Name}");
            }
        }
    }
}