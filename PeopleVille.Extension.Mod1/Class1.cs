using PeopleVille.Equipment;
using PeopleVille.Persons;

namespace PeopleVille.Extension.Mod1;

public class Snake : IEquipment
{
    public string Name { get; set; } = "Snake";
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
        var message = $"Brugte en slange, lol";
        person.World?.globalLogger.LogEvent(person, message);
    }
}

public class Trumpet : IEquipment
{
    public string Name { get; set; } = "Trumpet med 90 grader";

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
        var message = $"Brugte en trumpet, musik lyder i {person.CurrentLocation.Name}";
        person.World?.globalLogger.LogEvent(person, message);
    }
}