namespace PeopleVille.Persons
{
    public class AdultCitizen : Person
    {
        public AdultCitizen(GameManager gameManager)
        {
            Age = RNG.Range(20, 85);

            gameManager.TickDone += DoSomething;
        }

        public void DoSomething()
        {

        }
    }
}