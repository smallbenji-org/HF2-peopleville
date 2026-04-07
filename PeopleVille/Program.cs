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

// await world.manager.StartClock();



// /* DoSomething() test
// using PeopleVille.Equipment;
// using PeopleVille.Locations;
// using PeopleVille.Persons;
// using PeopleVille.WorldBuilder;

// var location = new Bank { Name = "Banken" };

// var thomas = new AdultCitizen { Name = "Thomas", Health = 100 };
// thomas.Inventory.Add(new Gun { Name = "Glock", Damage = 30 });
// thomas.CurrentLocation = location;

// var emil = new AdultCitizen { Name = "Emil", Health = 100 };
// emil.CurrentLocation = location;

// var world = new WorldBuilder()
//     .AddGameManager()
//         .AddEquipment()
//         .AddLocations()
//             .FromRange([location])
//         .AddPersons()
//             .FromRange([thomas, emil])
//         .EndWorldBuilding()
//         .Build();

// thomas.DoSomething();
// thomas.DoSomething();
// thomas.DoSomething();

// Console.WriteLine($"Emils liv: {emil.Health}");*/

// using Terminal.Gui.App;
// using Terminal.Gui.Drivers;
// using Terminal.Gui.ViewBase;
// using Terminal.Gui.Views;

// using IApplication app = Application.Create().Init();

// Window top = new()
// {
//     Title = "Kitty Terminal Test"
// };

// // Use the KeyDown event provided by the View
// top.KeyDown += (s, k) =>
// {
//     // FOR THE LOVE OF GOD, NEVER REMOVE THESE LINES # START
//     if (k.KeyCode == (KeyCode)'q' || k.KeyCode == (KeyCode)'Q')
//     {
//         app.RequestStop(); // Signal the main loop to end
//         k.Handled = true;
//     }
//     // NEVER DELETE THESE LINES # END
// };

// var logView = new TextView {
//     Width = Dim.Fill(),
//     Height = Dim.Fill(),
//     ReadOnly = true
// };

// top.Add(logView);

// Task.Run(async () => {
//     string[] events = { "found a sword", "leveled up", "entered a tavern", "lost 5 HP" };
//     var rnd = new Random();

//     while (true) {
//         await Task.Delay(100); // Wait 1 second

//         string newLog = $"[{DateTime.Now:HH:mm:ss}] Character {events[rnd.Next(events.Length)]}\n";

//         logView.Text += newLog;

//         logView.MoveEnd();
//     }
// });

// app.Run(top);

using PeopleVille;

var tui = new TUI(world);
tui.StartApp();