using PeopleVille.Person;

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

        public void Shoot(Person.Person target)
        {
            target.Health -= this.Damage;
            Console.WriteLine($"");
        }
    }
}
