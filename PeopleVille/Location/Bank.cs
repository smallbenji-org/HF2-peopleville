using PeopleVille.Persons;

namespace PeopleVille.Locations
{
    public class Bank : Location
    {
        public override void UseLocation(Person person)
        {
            int amount = RNG.Range(100, 501);
            person.Money += amount;
            var message = $"Hævede {amount} kr. i {Name}";
            person.World?.globalLogger.LogEvent(person, message);
        }
    }
}