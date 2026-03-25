namespace PeopleVille.Persons
{
    public class ChildCitizen : Person
    {
        public ChildCitizen()
        {
            Age = RNG.Range(2, 19);
        }
    }
}