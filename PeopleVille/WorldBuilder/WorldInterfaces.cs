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

        }

        public interface ICitizenBuilder
        {
            ICitizenBuilder CreateAdult(string name, int health);
            ICitizenBuilder CreateChild(string name, int health);
            ICitizenBuilder WithGun(string name, int damage);
            ICitizenBuilder WithFood(string name, int healthPoints);
            Person Build();
        }
    }
}
