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
            .WithRandomItems(20)
        .EndWorldBuilding()
        .Build();

await world.manager.StartClock();



/* DoSomething() test
using PeopleVille.Equipment;
using PeopleVille.Locations;
using PeopleVille.Persons;
using PeopleVille.WorldBuilder;

var location = new Bank { Name = "Banken" };

var thomas = new AdultCitizen { Name = "Thomas", Health = 100 };
thomas.Inventory.Add(new Gun { Name = "Glock", Damage = 30 });
thomas.CurrentLocation = location;

var emil = new AdultCitizen { Name = "Emil", Health = 100 };
emil.CurrentLocation = location;

var world = new WorldBuilder()
    .AddGameManager()
        .AddEquipment()
        .AddLocations()
            .FromRange([location])
        .AddPersons()
            .FromRange([thomas, emil])
        .EndWorldBuilding()
        .Build();

thomas.DoSomething();
thomas.DoSomething();
thomas.DoSomething();

Console.WriteLine($"Emils liv: {emil.Health}");*/