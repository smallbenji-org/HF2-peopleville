namespace PeopleVille.Persons
{
    public class PeopleBuilder
    {
        readonly string[] maleNames = ["John", "Peter", "Mikkel", "Lars", "Benjamin"];
        readonly string[] femaleNames = ["Cirkeline", "Josefine", "Simone", "Gertrud", "Smilla"];
        readonly string[] lastNames = ["Petersen", "Rasmussen", "Madsen"];

        public List<Person> CreatePeople(int number)
        {
            List<Person> people = [];

            for (var i = 0; i < number; i++)
            {
                string name = String.Empty;
                switch (RNG.ThrowDice(Dices.D2))
                {
                    case 1:
                        name += maleNames[RNG.Range(0, maleNames.Length)];
                        break;
                    case 2:
                        name += femaleNames[RNG.Range(0, femaleNames.Length)];
                        break;
                    default:
                        throw new Exception("What happened?");
                }

                name += " " + lastNames[RNG.Range(0, lastNames.Length)];

                people.Add(new AdultCitizen()
                {
                    Name = name
                });
            }

            return people;
        }
    }
}