namespace PeopleVille.Locations
{
    public class LocationBuilder
    {
        readonly string[] bankNames = ["Nationalbanken", "Borgernes Bank", "Den Store Bank"];
        readonly string[] gunStoreNames = ["Våben Salg", "Bangbang Butikken", "SkyderButikken"];
        readonly string[] eggStoreNames = ["Gårdens Æg", "Æggehuset", "Byens Æg"];

        public List<Location> CreateLocations(int number)
        {
            List<Location> locations = [];

            for (var i = 0; i < number; i++)
            {
                switch (RNG.ThrowDice(Dices.D3))
                {
                    case 1:
                        locations.Add(new Bank()
                        {
                            Name = bankNames[RNG.Range(0, bankNames.Length)]
                        });
                        break;
                    case 2:
                        locations.Add(new GunStore()
                        {
                            Name = gunStoreNames[RNG.Range(0, gunStoreNames.Length)]
                        });
                        break;
                    case 3:
                        locations.Add(new EggStore()
                        {
                            Name = eggStoreNames[RNG.Range(0, eggStoreNames.Length)]
                        });
                        break;
                }
            }

            return locations;
        }
    }
}
