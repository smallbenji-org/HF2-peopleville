using PeopleVille.Persons;

namespace PeopleVille.Equipment
{
    public interface IEquipment
    {
        public void Use(Person user, Person target);
        public bool NeedsTarget();
    }
}