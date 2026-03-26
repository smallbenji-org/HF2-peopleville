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
            // 50/50 om vi gør noget eller ej
            if (RNG.ThrowDice(Dices.D2) == 1)
                return;

            bool hasGun = Inventory.OfType<Gun>().Any();
            bool hasUnder100 = Health < 100;

            if (hasGun && hasUnder100)
            {
                if (RNG.ThrowDice(Dices.D2) == 1)
                    ShootRandomPerson();
                else
                    EatFood();
            }
            else if (hasGun)
            {
                ShootRandomPerson();
            }
            else if (hasUnder100)
            {
                EatFood();
            }
        }

        private void ShootRandomPerson()
        {
            var targets = World.People.Where(x => x != this && x.CurrentLocation == CurrentLocation).ToList();
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