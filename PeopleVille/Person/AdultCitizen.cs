using PeopleVille.Equipment;
using PeopleVille.WorldBuilder;

namespace PeopleVille.Persons
{
    public class AdultCitizen : Person
    {
        public AdultCitizen()
        {
            Age = RNG.Range(20, 85);
        }

        private void Log(string message)
        {
            World?.globalLogger.LogEvent(this, message);
        }

        public override void Initialize()
        {
            Manager.TickDone += DoSomething;


            //ingen lokationer? DØ.
            if (World.Locations.Count == 0)
                return;

            var randomLocation = World.Locations[RNG.Range(0, World.Locations.Count)];
            Walk(randomLocation);
        }

        public void DoSomething()
        {
            if (Dead)
                return;

            if (this.Health <= 0)
            {
                this.Dead = true;
                Log($"RIP: {this.Name} døde...");
                return;
            }

            if (RNG.ThrowDice(Dices.D3) == 1)
                return;
            switch (RNG.ThrowDice(Dices.D4))
            {
                case 1:
                    bool hasGun = Inventory.OfType<Gun>().Any();
                    bool hasUnder100 = Health < 100;
                    bool hasFood = Inventory.OfType<Food>().Any();

                    if (hasGun && hasUnder100)
                    {
                        if (RNG.ThrowDice(Dices.D2) == 1)
                            ShootRandomPerson();
                        else
                            if (hasFood)
                                EatFood();
                    }
                    else if (hasGun)
                    {
                        ShootRandomPerson();
                    }
                    else if (hasUnder100 && hasFood)
                    {
                        EatFood();
                    }
                    break;
                case 2:
                    //Move location
                    var otherLocations = World.Locations.Where(x => x != CurrentLocation).ToList();
                    if (otherLocations.Count > 0)
                        Walk(otherLocations[RNG.ThrowDice(new Die(otherLocations.Count)) - 1]);
                    Log($"Gik hen til {CurrentLocation.Name}");
                    CurrentLocation.UseLocation(this);
                    break;
                case 3:
                    try
                    {
                        var items = this.Inventory.Where(x => x is not Gun && x is not Food).ToList();
                        var randomItem = items[RNG.Range(0, items.Count)];
                        if (randomItem.NeedsTarget())
                        {
                            var peopleAtLocation = World.People.Where(x => x != this && x.CurrentLocation == CurrentLocation && !x.Dead).ToList();
                            if (peopleAtLocation.Count == 0)
                                return;

                            var randomPerson = peopleAtLocation[RNG.ThrowDice(new Die(peopleAtLocation.Count)) - 1];

                            randomItem.Use(this, randomPerson);
                        }
                        else
                        {
                            randomItem.Use(this, this);
                        }
                    } catch
                    {
                        Log($"Brugte ikke nogle items");
                    }
                    break;
                case 4:
                    //Do nothing
                    break;
            }
        }

        private void ShootRandomPerson()
        {
            var peopleAtLocation = World.People.Where(x => x != this && x.CurrentLocation == CurrentLocation && !x.Dead).ToList();
            if (peopleAtLocation.Count == 0)
                return;

            var randomPerson = peopleAtLocation[RNG.ThrowDice(new Die(peopleAtLocation.Count)) - 1];
            var gun = Inventory.OfType<Gun>().First();
            gun.Use(this, randomPerson);
        }

        private void EatFood()
        {
            var food = Inventory.OfType<Food>().FirstOrDefault();
            if (food == null)
                return;

            food.Use(this, this);
        }
    }
}