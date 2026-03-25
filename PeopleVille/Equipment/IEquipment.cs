using PeopleVille.Persons;

namespace PeopleVille.Equipment
{
    interface IEquipment
    {
        public void Equip();
        public void Unequip();
        public void Use(Person person);
    }
}