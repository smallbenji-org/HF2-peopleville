using PeopleVille;
using PeopleVille.Equipment;
using PeopleVille.Persons;
using PeopleVille.WorldBuilder;
using System.Text.Json;

var gameManager = new GameManager();

//await gameManager.StartClock();

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


/* burde i teorien virke?
var testCitizen = new AdultCitizen { Name = "Lars", Health = 100 };
testCitizen.Inventory.Add(new Gun { Name = "Glock", Damage = 50 }); */

var cBuilder = new CitizenBuilder();
var tBuilder = new TownBuilder();

cBuilder
    .CreateAdult("Lars", 100).WithGun("Glock", 20)
    .CreateAdult("Thomas", 100).WithGun("AK", 40).WithFood("Hvid Monster", 0)
    .CreateChild("Troels", 60).WithFood("Apple", 10);

tBuilder
    .AddBank("PeopleVille Bank")
    .AddGunStore("Gun Store")
    .AddEggStore("Egg Store");

var borgere = cBuilder.BuildCitizens();

if (borgere[0].Inventory[0] is Gun)
{
    var gun = (Gun)borgere[0].Inventory[0];
    gun.Damage = 100;
}
var locations = tBuilder.BuildTown();

Console.WriteLine(borgere);

//Console.WriteLine(JsonSerializer.Serialize(borgere));