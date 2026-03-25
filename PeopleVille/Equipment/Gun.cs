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
            target.Health -= this.Damage;
            Console.WriteLine($"");
        }
    }
}
