namespace PeopleVille.Persons
{
    public class AdultCitizen : Person
    {
        public AdultCitizen()
        {
            Age = RNG.Range(20, 85);
        }
    }
}