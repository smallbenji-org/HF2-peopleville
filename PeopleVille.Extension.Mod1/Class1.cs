using PeopleVille.Equipment;
using PeopleVille.Persons;

namespace PeopleVille.Extension.Mod1;

public class Snake : IEquipment
{

    public void Equip()
    {
        throw new NotImplementedException();
    }

    public void Unequip()
    {
        throw new NotImplementedException();
    }

    public void Use(Person person)
    {
        Console.WriteLine($"{person.Name} brugte en slange, lol");
    }
}