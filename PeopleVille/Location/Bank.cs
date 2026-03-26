using PeopleVille.Persons;

namespace PeopleVille.Locations
{
    public class Bank : Location
    {
        public override void UseLocation(Person person)
        {
            int amount = RNG.Range(100, 501);
            person.Money += amount;
            Console.WriteLine($"{person.Name} hæver {amount} kr. i {Name}");
        }
    }
}