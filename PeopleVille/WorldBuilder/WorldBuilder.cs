using PeopleVille.Equipment;
using PeopleVille.Locations;
using PeopleVille.Persons;
using System;
using System.Collections.Generic;
using System.Text;
using static PeopleVille.WorldBuilder.WorldInterfaces;

namespace PeopleVille.WorldBuilder
{
    public class CitizenBuilder : ICitizenBuilder
    {
        Person person;
        List<Person> Citizens = new List<Person>();

        public ICitizenBuilder CreateAdult(string name, int health)
        {
            person = new AdultCitizen { Name = name, Health = health, Inventory = new List<Equipment.IEquipment>() };
            Citizens.Add(person);
            return this;
        }

        public ICitizenBuilder CreateChild(string name, int health)
        {
            person = new ChildCitizen { Name = name, Health = health, Inventory = new List<Equipment.IEquipment>() };
            Citizens.Add(person);
            return this;
        }

        public ICitizenBuilder WithGun(string name, int damage)
        {
            person.Inventory.Add(new Gun { Name = name, Damage = damage });
            return this;
        }

        public ICitizenBuilder WithFood(string name, int healthPoints)
        {
            person.Inventory.Add(new Food { Name = name, HealthPoints = healthPoints });
            return this;
        }

        public List<Person> BuildCitizens()
        {
            return Citizens;
        }
    }

    public class TownBuilder : ITownBuilder
    {
        List<Location> locations = new List<Location>();

        public ITownBuilder AddGunStore(string name)
        {
            locations.Add(new GunStore { Name = name, Inventory = new Dictionary<object, int>() });
            return this;
        }

        public ITownBuilder AddEggStore(string name)
        {
            locations.Add(new EggStore { Name = name, Inventory = new Dictionary<object, int>() });
            return this;
        }

        public ITownBuilder AddBank(string name)
        {
            locations.Add(new Bank { Name = name });
            return this;
        }

        public List<Location> BuildTown()
        {
            return locations;
        }
    }
}
