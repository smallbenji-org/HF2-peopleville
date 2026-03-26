using PeopleVille.Equipment;
using PeopleVille.Locations;
using PeopleVille.Persons;

namespace PeopleVille.WorldBuilder
{
    public interface IWorldBuilder
    {
        IGameManagerBuilder AddGameManager();
        World Build();
    }

    public interface IGameManagerBuilder
    {
        IEquipmentBuilder AddEquipment();
    }

    public interface IEquipmentBuilder
    {
        IEquipmentBuilder FromFolder(string pathToFolder);
        IEquipmentBuilder FromFile(string pathToFile);
        IEquipmentBuilder FromRange(IEnumerable<IEquipment> equipment);
        ILocationBuilder AddLocations();
    }

    public interface ILocationBuilder
    {
        ILocationBuilder FromFolder(string pathToFolder);
        ILocationBuilder FromFile(string pathToFile);
        ILocationBuilder FromRange(IEnumerable<Location> locations);
        IPersonBuilder AddPersons();
    }

    public interface IPersonBuilder
    {
        IPersonBuilder FromFolder(string pathToFolder);
        IPersonBuilder FromFile(string pathToFile);
        IPersonBuilder FromRange(IEnumerable<Person> people);
        IPersonBuilder WithRandomItems(int number);
        IWorldBuilder EndWorldBuilding();
    }
}
