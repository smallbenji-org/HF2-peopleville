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

    public bool NeedsTarget()
    {
        return false;
    }

    public void Unequip()
    {
        throw new NotImplementedException();
    }

    public void Use(Person user, Person target)
    {
        var message = $"Brugte en slange, lol";
        user.World?.globalLogger.LogEvent(user, message);
    }
}

public class Trumpet : IEquipment
{
    public string Name { get; set; } = "Trumpet med 90 grader";

    public void Equip()
    {
        throw new NotImplementedException();
    }

    public bool NeedsTarget()
    {
        return false;
    }

    public void Unequip()
    {
        throw new NotImplementedException();
    }

    public void Use(Person user, Person target)
    {
        var message = $"Brugte en trumpet, musik lyder i {user.CurrentLocation.Name}";
        user.World?.globalLogger.LogEvent(user, message);
    }
}

public class Svupper : IEquipment
{
    public void Equip()
    {
        throw new NotImplementedException();
    }

    public bool NeedsTarget()
    {
        return true;
    }

    public void Unequip()
    {
        throw new NotImplementedException();
    }

    public void Use(Person user, Person target)
    {
        var message = $"Brugte en svupper på {target.Name}, øv bøv";
        user.World?.globalLogger.LogEvent(user, message);

        var targetMessage = $"AD! {user.Name} svuppede dig";
        user.World?.globalLogger.LogEvent(target, targetMessage);
    }
}