using PeopleVille.Equipment;

namespace PeopleVille.Persons
{
    public class AdultCitizen : Person
    {
        public AdultCitizen()
        {
            Age = RNG.Range(20, 85);

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
            //
        }

        private void EatFood()
        {
            //
        }
    }
}