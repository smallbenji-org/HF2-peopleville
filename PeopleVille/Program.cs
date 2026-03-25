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