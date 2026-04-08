using PeopleVille.Persons;

namespace PeopleVille.Equipment
{
    public class Gun : IEquipment
    {
        public required string Name { get; set; }
        public int Damage { get; set; }

        public void Equip()
        {
            Console.WriteLine("");
        }

        public void Unequip()
        {
            Console.WriteLine("");
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
                Console.WriteLine($"{target.Name} er blevet skudt af {shooterName} med {Name} og mistede {Damage} liv");
            }
            catch
            {
                Console.WriteLine($"{target.Name} prøvede at skyde, men det virkede ikke, øv bøv");
            }
        }
    }
}
