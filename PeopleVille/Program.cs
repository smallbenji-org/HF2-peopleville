using PeopleVille;
using PeopleVille.Equipment;
using PeopleVille.Persons;
using PeopleVille.WorldBuilder;

var gameManager = new GameManager();

await gameManager.StartClock();

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


/* burde i teorien virke?
var testCitizen = new AdultCitizen { Name = "", Health = 100 };
testCitizen.Inventory.Add(new Gun { Name = "Glock", Damage = 50 }); */

/* builder?
var builder = new CitizenBuilder();

builder
    .CreateAdult("Lars", 100).WithGun("Glock", 20)
    .CreateAdult("Thomas", 100).WithGun("AK", 40).WithFood("Hvid Monster", 0)
    .CreateChild("Troels", 60).WithFood("Apple", 10);

var borgere = builder.Build(); */