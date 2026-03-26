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

        public override void Initialize()
        {
            Manager.TickDone += DoSomething;
        }

        public void DoSomething()
        {
            if (this.Health <= 0 && !Dead)
            {
                this.Dead = true;

                Console.WriteLine($"RIP: {this.Name} døde...");

                return;
            }

            // 50/50 om vi gør noget eller ej
            if (RNG.ThrowDice(Dices.D3) == 1)
                return;
            switch (RNG.ThrowDice(Dices.D3))
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
                    Console.WriteLine($"{Name} Gik hen til {CurrentLocation.Name}");
                    break;
                case 3:
                    //Do nothing
                break;
            }
        }

        private void ShootRandomPerson()
        {
            var targets = World.People.Where(x => x != this && x.CurrentLocation == CurrentLocation && !x.Dead).ToList();
            if (targets.Count == 0)
                return;

            var target = targets[RNG.ThrowDice(new Die(targets.Count)) - 1];
            var gun = Inventory.OfType<Gun>().First();
            gun.Use(target);
        }

        private void EatFood()
        {
            var food = Inventory.OfType<Food>().First();
            if (food == null)
                return;

            food.Use(this);
        }
    }
}