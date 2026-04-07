using PeopleVille;
using PeopleVille.Equipment;
using PeopleVille.Locations;
using PeopleVille.Persons;
using PeopleVille.WorldBuilder;

var peopleBuilder = new PeopleBuilder();
var locationBuilder = new LocationBuilder();

var gun = new Gun()
{
    Name = "Glock-18",
    Damage = 20
};

var kage = new Food()
{
    Name = "Kage",
    HealthPoints = 20
};

var modFolder = Path.GetFullPath(
    Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", 
                 "PeopleVille.Extension.Mod1", "bin", "Debug", "net10.0"));


var world = new WorldBuilder()
    .AddGameManager()
        .AddEquipment()
            .FromRange([gun, kage])
            .FromFolder(modFolder)
        .AddLocations()
            .FromRange(locationBuilder.CreateLocations(15))
        .AddPersons()
            .FromRange(peopleBuilder.CreatePeople(15))
            .WithRandomItems(1)
        .EndWorldBuilding()
        .Build();

await world.manager.StartClock();
//var tui = new TUI(world);
//tui.StartApp();