using PeopleVille.WorldBuilder;

var world = new WorldBuilder()
    .AddGameManager()
        .AddEquipment()
            .FromFile("/path/to/file")
        .AddLocations()
            .FromFolder("/path/to/folder")
        .AddPersons()
            .FromFile("/path/to/file")
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