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
        IWorldBuilder EndWorldBuilding();
    }

    // public interface ITownBuilder
    // {
    //     ITownBuilder AddGunStore(string name);
    //     ITownBuilder AddEggStore(string name);
    //     ITownBuilder AddBank(string name);
    //     List<Location> BuildTown();
    // }

    // public interface ICitizenBuilder
    // {
    //     ICitizenBuilder CreateAdult(string name, int health);
    //     ICitizenBuilder CreateChild(string name, int health);
    //     ICitizenBuilder WithGun(string name, int damage);
    //     ICitizenBuilder WithFood(string name, int healthPoints);
    //     List<Person> BuildCitizens();
    // }
}
