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

var world = new WorldBuilder()
    .AddGameManager()
        .AddEquipment()
            .FromRange([gun, kage])
            .FromFolder("/home/smallbenji/school/hf2/HF2-peopleville/PeopleVille.Extension.Mod1/bin/Debug/net10.0")
        .AddLocations()
            .FromRange(locationBuilder.CreateLocations(15))
        .AddPersons()
            .FromRange(peopleBuilder.CreatePeople(15))
            .WithRandomItems(1)
        .EndWorldBuilding()
        .Build();

await world.manager.StartClock();