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

        public void Use(Person target)
        {
            Use(target, "");
        }

        public void Use(Person target, string shooterName)
        {
            try
            {
                target.Health -= this.Damage;
                var message = $"{target.Name} er blevet skudt af {shooterName} med {Name} og mistede {Damage} liv";
                target.World?.globalLogger.LogEvent(target, message);
            } catch
            {
                var message = $"{target.Name} prøvede at skyde, men det virkede ikke, øv bøv";
                target.World?.globalLogger.LogEvent(target, message);
            }
        }
    }
}
