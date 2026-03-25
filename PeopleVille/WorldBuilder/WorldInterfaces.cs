using PeopleVille.Locations;
using PeopleVille.Persons;

namespace PeopleVille.WorldBuilder
{
    public class WorldInterfaces
    {
        public interface IWorldBuilder
        {

        }

        public interface ITownBuilder
        {
            ITownBuilder AddGunStore(string name);
            ITownBuilder AddEggStore(string name);
            ITownBuilder AddBank(string name);
            List<Location> BuildTown();
        }

        public interface ICitizenBuilder
        {
            ICitizenBuilder CreateAdult(string name, int health);
            ICitizenBuilder CreateChild(string name, int health);
            ICitizenBuilder WithGun(string name, int damage);
            ICitizenBuilder WithFood(string name, int healthPoints);
            List<Person> BuildCitizens();
        }
    }
}
