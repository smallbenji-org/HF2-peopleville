using PeopleVille.Persons;

namespace PeopleVille.Equipment
{
    public class Gun : IEquipment
    {
        public required string Name { get; set; }
        public int Damage { get; set; }

        public void Equip()
        {
        }

        public void Unequip()
        {
        }

        public void Use(Person user, Person target)
        {
            try
            {
                target.Health -= this.Damage;
                var message = $"Skød {target.Name} med {Name} og mistede {Damage} liv";
                target.World?.globalLogger.LogEvent(user, message);
            } catch
            {
                var message = $"Prøvede at skyde, men det virkede ikke, øv bøv";
                target.World?.globalLogger.LogEvent(user, message);
            }
        }
    }
}
